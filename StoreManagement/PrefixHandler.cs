using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace StoreManagement
{
    class PrefixHandler
    {
        static public Int32 HandlePrefix(SocketAsyncEventArgs e, DataHoldingUserToken token, int remainingBytesToProcess)
        {
            if (token.countRecvPfxDone == 0)
            {
                // new message
                token.byteArrayRecvPrefix = new byte[token.PrefixLength];
            }

            if (remainingBytesToProcess >= token.PrefixLength - token.countRecvPfxDone)
            {
                Buffer.BlockCopy(e.Buffer,
                                        token.receiveMessageOffset - token.PrefixLength + token.countRecvPfxDone,
                                        token.byteArrayRecvPrefix,
                                        token.countReccMsgDone,
                                        token.PrefixLength - token.countRecvPfxDone);

                remainingBytesToProcess -= (token.PrefixLength - token.countRecvPfxDone);
                token.countRecvPfxDoneThisOp = token.PrefixLength - token.countRecvPfxDone;
                token.countRecvPfxDone = token.PrefixLength;

                RetrieveCMDTypeAndMsgLen(token);
                return remainingBytesToProcess;
            }
            else
            {
                Buffer.BlockCopy(e.Buffer,
                                        token.receiveMessageOffset - token.PrefixLength + token.countRecvPfxDone,
                                        token.byteArrayRecvPrefix,
                                        token.countReccMsgDone,
                                        remainingBytesToProcess);

                token.countRecvPfxDoneThisOp = remainingBytesToProcess;
                token.countReccMsgDone += remainingBytesToProcess;
                remainingBytesToProcess = 0;
            }
            if (remainingBytesToProcess == 0)
            {
                token.receiveMessageOffset -= token.countRecvPfxDoneThisOp;
                token.countRecvPfxDoneThisOp = 0;
            }
            return remainingBytesToProcess;
        }

        private static void RetrieveCMDTypeAndMsgLen(DataHoldingUserToken token)
        {
            Array.Copy(token.byteArrayRecvPrefix, token.byteArrayCMD, token.lenCMD);
            token.lenRecvMsg = BitConverter.ToInt32(token.byteArrayRecvPrefix, token.lenCMD);
            int cmd = BitConverter.ToInt32(token.byteArrayCMD, 0);
            switch ((CMDTYPE)cmd)
            {
                case CMDTYPE.IMAGEREQ:
                    {
                        token.cmdType = CMDTYPE.IMAGEREQ;
                    }
                    break;
                case CMDTYPE.IMAGERES:
                    {
                        token.cmdType = CMDTYPE.IMAGERES;
                    }
                    break;
                default:
                    token.cmdType = CMDTYPE.NONE;
                    break;
            }
        }
    }
}
