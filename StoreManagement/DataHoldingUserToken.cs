using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace StoreManagement
{
    internal class DataHoldingUserToken
    {
        // Client's feature
        public string ComputerName { get; set; }
        public string IPAddress { get; set; }
        public int IPPort { get; set; }
        public int SessionID { get; set; }

        // |---PrefixLength----|--------RecieveMessageLength------|----PrefixLength-----|------SendMessageLength-----|
        // |---------------Buffer Size 32KB-----------------------|---------------Buffer Size 32KB-------------------|
        // |---------------Recieve--------------------------------|----------------Send -----------------------------|
        internal readonly int bufOffsetRecv;
        internal readonly int bufOffsetSend; // equal to bufOffsetRecv + BufferSize(32KB)
        internal readonly int PrefixLength;

        internal byte[] byteArrayRecvPrefix;
        internal int countRecvPfxDone;
        internal int countRecvPfxDoneThisOp;

        internal byte[] byteArrayRecvMsg;
        internal int receiveMessageOffset;
        internal int countReccMsgDone;
        internal int lenRecvMsg;

        internal byte[] byteArraySendAll;
        internal int countSendAllDone;
        internal int countSendAllRemain;
        internal int lenSendMsg;

        internal CMDTYPE cmdType;
        internal readonly int lenCMD;
        internal byte[] byteArrayCMD;

        public DataHoldingUserToken(int rOffset, int sOffset, int rPrefixLen, int sPrefixLen, int cmdLen)
        {
            this.bufOffsetRecv = rOffset;
            this.PrefixLength = rPrefixLen;
            this.receiveMessageOffset = this.bufOffsetRecv + PrefixLength;

            this.bufOffsetSend = sOffset;

            this.lenCMD = cmdLen;
            cmdType = CMDTYPE.NONE;
            byteArrayCMD = new byte[lenCMD];
        }

        public void SetUserInfo(SocketAsyncEventArgs e, int sessionID)
        {
            this.SessionID = sessionID;
            IPEndPoint cltEP = e.AcceptSocket.RemoteEndPoint as IPEndPoint;
            this.IPAddress = (string)cltEP.Address.ToString().Clone();
            this.IPPort = cltEP.Port;
        }

        public void Reset()
        {
            IPAddress = "";
            IPPort = 0;
            countRecvPfxDone = 0;
            countReccMsgDone = 0;
            lenRecvMsg = 0;
            lenSendMsg = 0;
            countSendAllRemain = 0;
            countSendAllDone = 0;
            cmdType = CMDTYPE.NONE;
            byteArrayRecvMsg = null;
            byteArraySendAll = null;
            byteArrayRecvPrefix = null;
            receiveMessageOffset = bufOffsetRecv + PrefixLength;
        }
    }
}
