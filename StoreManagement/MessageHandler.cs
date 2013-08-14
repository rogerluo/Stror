using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace StoreManagement
{
    internal class MessageHandler
    {
        static internal bool HandleMessage(SocketAsyncEventArgs e, DataHoldingUserToken token, int remainingBytesToProcess)
        {
            bool msgIsReady = false;

            if (token.countReccMsgDone == 0)
            {
                token.byteArrayRecvMsg = new byte[token.lenRecvMsg];
            }

            if (remainingBytesToProcess + token.countReccMsgDone == token.lenRecvMsg)
            {
                Buffer.BlockCopy(e.Buffer,
                                            token.receiveMessageOffset,
                                            token.byteArrayRecvMsg,
                                            token.countReccMsgDone,
                                            remainingBytesToProcess);
                msgIsReady = true;
            }
            else
            {
                Buffer.BlockCopy(e.Buffer,
                                            token.receiveMessageOffset,
                                            token.byteArrayRecvMsg,
                                            token.countReccMsgDone,
                                            remainingBytesToProcess);

                token.receiveMessageOffset -= token.countRecvPfxDoneThisOp;
                token.countReccMsgDone += remainingBytesToProcess;
            }

            return msgIsReady;
        }
    }
}
