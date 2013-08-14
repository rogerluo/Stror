using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using StoreManagement.Properties;


namespace StoreManagement
{
    public partial class ClientTest : Form
    {
        public ClientTest()
        {
            InitializeComponent();
            _client = new SocketClient();
        }


        private Socket _clientSocket;
        private SocketClient _client;
        
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPEndPoint hostEndPoint = new IPEndPoint(IPAddress.Parse(Settings.Default.ServerIP), Settings.Default.SvrPort);
            //IAsyncResult ar = _clientSocket.BeginConnect(hostEndPoint, ProcessConnect, _clientSocket);
            if(_client.Connected == false)
                _client.StartConnect(ConnectState);
        }

        private void ProcessConnect(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar);
                IPEndPoint localEndPoint = (IPEndPoint)client.LocalEndPoint;
                IPEndPoint hostEndPoint = (IPEndPoint)client.RemoteEndPoint;
                
                string msg = (string.Format("Successfully connect to host {0}:{1} by local: {2}:{3}",
                        hostEndPoint.Address, hostEndPoint.Port,
                        localEndPoint.Address, localEndPoint.Port));

                if (this.lblState.InvokeRequired == true)
                {
                    this.lblState.BeginInvoke((MethodInvoker)delegate {
                        lblState.Text = msg + "(Invoke)";
                        ConnectState(true);
                    });
                }
                else
                {
                    this.lblState.Text = msg;
                    ConnectState(false);
                }


            }
            catch (Exception anyExp)
            {
                MessageBox.Show(anyExp.Message);
            }
        }

        private void ProcessDisconnect(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = (Socket)ar.AsyncState;
                if (clientSocket != null)
                {
                    // wait until the 
                    clientSocket.EndDisconnect(ar);
                    //clientSocket.Close();
                    string msg = string.Format("Disconnect");
                    if (lblState.InvokeRequired == true)
                    {
                        lblState.BeginInvoke((MethodInvoker)(delegate {
                            lblState.Text = msg;
                            ConnectState(false);
                        }));
                    }
                    else
                    {
                        lblState.Text = msg;
                        ConnectState(false);
                    }
                }
            }
            catch (Exception anyExp)
            {
                MessageBox.Show(anyExp.Message);
            }
        }

        private void ConnectState(bool bConnected)
        {
            

            if (btnConnect.InvokeRequired == true)
            {
                btnConnect.BeginInvoke((MethodInvoker)delegate
                {
                    btnConnect.Enabled = !bConnected;
                    btnClose.Enabled = bConnected;
                });
            }
            else
                {
                btnConnect.Enabled = !bConnected;
            btnClose.Enabled = bConnected;
                }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (_clientSocket.Connected == true)
            //    {
            //        _clientSocket.Shutdown(SocketShutdown.Both);
            //        _clientSocket.BeginDisconnect(false, ProcessDisconnect, _clientSocket);
            //    }
            //    else
            //    {
            //        ConnectState(false);
            //    }
            //}
            //catch (Exception anyExp)
            //{
            //    MessageBox.Show(anyExp.Message);
            //}
            //===========
            if (_client.Connected == true)
            {
                _client.StartDisconnect(ConnectState);
            }
        }

        public void RefreshHistory(string msg)
        {
            if (rtbHistory.InvokeRequired == true)
            {
                rtbHistory.BeginInvoke((MethodInvoker)delegate
                {
                    rtbHistory.Text += string.Format("{0}\n\r", msg);
                });
            }
            else
                rtbHistory.Text += string.Format("{0}\n\r", msg);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            rtbHistory.Text += string.Format("{0}\n\r", rtbMessage.Text);
           // StateObject so = new StateObject(CMDTYPE.IMAGEREQ, rtbMessage.Text, RefreshHistory);
            //_client.StartInteract(so);
            //if (_clientSocket.Connected == true)
            //{
            //    rtbHistory.Text += string.Format("{0}\n\r", rtbMessage.Text);
            //    //byte[] content = Encoding.UTF8.GetBytes(tbxContent.Text.Trim());
            //    //try
            //    //{
            //    //    IAsyncResult ar = _clientSocket.BeginSend(content, 0, content.Length, SocketFlags.None, ProcessSend, _clientSocket);
            //    //    ResheshState("Start sending");
            //    //}
            //    //catch (Exception anyExp)
            //    //{
            //    //    MessageBox.Show(anyExp.Message);
            //    //}
            //}
            //else
            //{
            //    MessageBox.Show("Doesn't conntenct to host");
            //}
        }

        private void ProcessSend(IAsyncResult ar)
        {
            try
            {
                Socket socket = ar.AsyncState as Socket;
                socket.EndSend(ar);
                RefreshState("Send Successfully");
            }
            catch (Exception anyExp)
            {
                Console.Write(anyExp.Message);
            }
        }

        private void RefreshState(string msg)
        {
            if (lblState.InvokeRequired == true)
            {
                lblState.BeginInvoke((MethodInvoker)delegate
                {
                    lblState.Text = msg;
                });
            }
            else
                lblState.Text = msg;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ofd.Filter = "All Files|*.*";
            if (DialogResult.OK == ofd.ShowDialog())
            {
                if (_clientSocket.Connected == true)
                {
                    FileInfo info = new FileInfo(ofd.FileName);
                    _clientSocket.BeginSendFile(ofd.FileName,
                                                BitConverter.GetBytes(info.Length),
                                                null,
                                                TransmitFileOptions.UseDefaultWorkerThread,
                                                ProcessSendFile,
                                                _clientSocket);
                                                
                }
            }
        }

        private void ProcessSendFile(IAsyncResult ar)
        {
            try
            {
                Socket socket = ar as Socket;
                if (socket != null)
                {
                    socket.EndSendFile(ar);
                    RefreshState(string.Format("Successfull send {0}", ofd.FileName));
                }
            }
            catch (Exception anyExp)
            {
                MessageBox.Show(anyExp.Message);
            }
        }

        private void ClientTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_clientSocket != null && _clientSocket.Connected == true)
            {
                _clientSocket.Shutdown(SocketShutdown.Both);
                _clientSocket.Close();
            }
            _client.Dispose();
        }
    }

    internal delegate void Refresh1(string msg);
    internal delegate void Refresh(bool connected);
}
