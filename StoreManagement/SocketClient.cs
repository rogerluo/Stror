using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using StoreManagement.Properties;


namespace StoreManagement
{
    internal class SocketClient : IDisposable
    {
        private SocketAsyncEventArgs _saea;
        private IPEndPoint _host;
        private byte[] _buffer;
        private StateObject _so;
        private Refresh _callback;
        private bool _connected { get; set; }
        public bool Connected { get; set; }
        public SocketClient()
        {
            Init();
        }
        private bool Init()
        {
            _host = new IPEndPoint(IPAddress.Parse(Settings.Default.ServerIP), Settings.Default.SvrPort);
            _buffer = new byte[Settings.Default.BufferSize * 2];
            _saea = new SocketAsyncEventArgs();
            _saea.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
            _saea.SetBuffer(_buffer, 0, Settings.Default.BufferSize);
            _saea.UserToken = new DataHoldingUserToken(0,
                                                       Settings.Default.BufferSize,
                                                       Settings.Default.BufferPrefixLen,
                                                       Settings.Default.BufferPrefixLen,
                                                       Settings.Default.CmdLen);
            return true;
        }
        private void IO_Completed(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            { 
                case SocketAsyncOperation.Connect:
                    ProcessConnect(e);
                    break;
                case SocketAsyncOperation.Disconnect:
                    ProcessDisconnectAndCloseSocket(e);
                    break;
                case SocketAsyncOperation.Receive:
                    ProcessReceive(e);
                    break;
                case SocketAsyncOperation.Send:
                    ProcessSend(e);
                    break;
            }
        }
        private void StartConnect(object state)
        {
            _so = state as StateObject;
            _saea.RemoteEndPoint = _host;
            _saea.AcceptSocket = new Socket(AddressFamily.InterNetwork,
                                            SocketType.Stream,
                                            ProtocolType.Tcp);
            bool willRaiseEvent = _saea.AcceptSocket.ConnectAsync(_saea);
            if (!willRaiseEvent)
            {
                ProcessConnect(_saea);
            }
        }

        public void StartConnect(Refresh callback)
        {
            _callback = callback;
            _saea.RemoteEndPoint = _host;
            _saea.AcceptSocket = new Socket(AddressFamily.InterNetwork,
                                            SocketType.Stream,
                                            ProtocolType.Tcp);
            bool willRaiseEvent = _saea.AcceptSocket.ConnectAsync(_saea);
            if (!willRaiseEvent)
            {
                ProcessConnect(_saea);
            }
        }

        private void ProcessConnect(SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                DataHoldingUserToken token = (DataHoldingUserToken)e.UserToken;
                // prepare the msg
                //byte[] sendCMD = BitConverter.GetBytes((int)_so._type);
                //byte[] sendLen = BitConverter.GetBytes(_so._sendMsg.Length);
                //token.byteArraySendAll = new byte[Settings.Default.BufferPrefixLen + _so._sendMsg.Length];
                //Buffer.BlockCopy(sendCMD, 0, token.byteArraySendAll, 0, Settings.Default.CmdLen);
                //Buffer.BlockCopy(sendLen, 0, token.byteArraySendAll, Settings.Default.CmdLen, Settings.Default.BufferPrefixLen - Settings.Default.CmdLen);
                //Buffer.BlockCopy(_so._sendMsg, 0, token.byteArraySendAll, Settings.Default.BufferPrefixLen, _so._sendMsg.Length);
                // 
                //_connected = true;
                //token.countSendAllDone = 0;
                //token.countSendAllRemain = _so._sendMsg.Length;
                //StartSend(e);
                if (_callback != null)
                {
                    Connected = _saea.AcceptSocket.Connected;
                    _callback(Connected);
                }
            }
            else
            {
                ProcessConnectionError(e);
            }
        }

        internal void ProcessConnectionError(SocketAsyncEventArgs connectEventArgs)
        {
            if ((connectEventArgs.SocketError != SocketError.ConnectionRefused) && (connectEventArgs.SocketError != SocketError.TimedOut) && (connectEventArgs.SocketError != SocketError.HostUnreachable))
            {
                CloseSocket(connectEventArgs.AcceptSocket);
            }      
        }

        private void StartSend(SocketAsyncEventArgs e)
        {
            DataHoldingUserToken token = (DataHoldingUserToken)e.UserToken;
            if (token.countSendAllRemain <= Settings.Default.BufferSize)
            {
                e.SetBuffer(token.bufOffsetSend, token.countSendAllRemain);

                Buffer.BlockCopy(token.byteArraySendAll,
                                    token.countReccMsgDone,
                                    e.Buffer,
                                    token.bufOffsetSend,
                                    token.countSendAllRemain);
            }
            else
            {
                e.SetBuffer(token.bufOffsetSend, Settings.Default.BufferSize);

                Buffer.BlockCopy(token.byteArraySendAll,
                                    token.countReccMsgDone,
                                    e.Buffer,
                                    token.bufOffsetSend,
                                    Settings.Default.BufferSize);
            }

            bool willRaiseEvent = e.AcceptSocket.SendAsync(e);
            if (!willRaiseEvent)
            {
                ProcessSend(e);
            }
        }

        private void ProcessSend(SocketAsyncEventArgs e)
        {
            DataHoldingUserToken token = (DataHoldingUserToken)e.UserToken;
            if (e.SocketError == SocketError.Success)
            {
                token.countSendAllRemain -= e.BytesTransferred;
                if (token.countSendAllRemain == 0)
                {
                    StartReceive(e);
                }
                else
                {
                    StartSend(e);
                }
            }
            else
            {
                token.Reset();
                StartDisconnect(e);
            }
        }

        private void StartReceive(SocketAsyncEventArgs e)
        {
            DataHoldingUserToken token = (DataHoldingUserToken)e.UserToken;
            e.SetBuffer(0, Settings.Default.BufferSize);
            bool willRaiseEvent = e.AcceptSocket.ReceiveAsync(e);
            if (!willRaiseEvent)
            {
                ProcessReceive(e);
            }
        }

        private void ProcessReceive(SocketAsyncEventArgs e)
        {
            DataHoldingUserToken token = (DataHoldingUserToken)e.UserToken;
            if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
            {
                int remainingBytesToProcess = e.BytesTransferred;
                if (token.countRecvPfxDone < token.PrefixLength)
                {
                    remainingBytesToProcess = PrefixHandler.HandlePrefix(e, token, remainingBytesToProcess);

                    if (remainingBytesToProcess == 0)
                    {
                       
                        StartReceive(e);
                        return;
                    }
                }

                bool incomingTcpMessageIsReady = MessageHandler.HandleMessage(e, token, remainingBytesToProcess);
                if (incomingTcpMessageIsReady == true)
                {
                    string msg = Encoding.UTF8.GetString(token.byteArrayRecvMsg);
                    _so._callback(Connected);
                    token.Reset();
                    StartDisconnect(e);
                    _connected = false;
                }
                else
                {
                    token.countRecvPfxDoneThisOp = 0;
                    StartReceive(e);
                }
            }
            else
            {
                token.Reset();
                StartDisconnect(e);
            }
        }

        private void StartDisconnect(SocketAsyncEventArgs e)
        {
            if (e.AcceptSocket.Connected == true)
            {
                e.AcceptSocket.Shutdown(SocketShutdown.Both);
                bool willRaiseEvent = e.AcceptSocket.DisconnectAsync(e);
                if (!willRaiseEvent)
                {
                    ProcessDisconnectAndCloseSocket(e);
                }
            }
        }

        public void StartDisconnect(Refresh callback)
        {
            _callback = callback;
            if (_saea.AcceptSocket.Connected == true)
            {
                _saea.AcceptSocket.Shutdown(SocketShutdown.Both);
                bool willRaiseEvent = _saea.AcceptSocket.DisconnectAsync(_saea);
                if (!willRaiseEvent)
                {
                    ProcessDisconnectAndCloseSocket(_saea);
                }
            }
        }

        private void ProcessDisconnectAndCloseSocket(SocketAsyncEventArgs e)
        {
            e.AcceptSocket.Close();
            Connected = e.AcceptSocket.Connected;
            if (_callback != null)
                _callback(Connected);
        }

        internal void StartInteract(StateObject state)
        {
            Thread t = new Thread(StartConnect);
            t.Start(state);
        }

        private void CloseSocket(Socket theSocket)
        {
            try
            {
                theSocket.Shutdown(SocketShutdown.Both);
            }
            catch
            {
            }
            theSocket.Close();
        }
        public void Dispose()
        {
            if (_connected == true)
            {
                _saea.AcceptSocket.Shutdown(SocketShutdown.Both);
                _saea.AcceptSocket.Close();
            }
        }
    }

    internal enum CMDTYPE
    { 
        NONE,
        IMAGEREQ = 10001,
        IMAGERES,
    }

    internal class StateObject
    {
        internal CMDTYPE _type;
        internal byte[] _sendMsg;
        internal Refresh _callback;
        public StateObject(CMDTYPE type, string msg, Refresh callback)
        {
            _type = type;
            _sendMsg = Encoding.UTF8.GetBytes(msg);
            _callback = callback;
        }
    }
}
