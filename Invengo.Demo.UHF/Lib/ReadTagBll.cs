using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using Invengo.NetAPI.Core;
using Invengo.NetAPI.Communication;
using Invengo.NetAPI.Protocol.IRP1;

namespace Invengo.Sample
{
    /// <summary>
    /// RFID Module Types;
    /// </summary>
    public enum RFIDModule : byte
    {
        F6C = 0,
        F6B = 1,
        F6C_F6B = 2
    }


    public class ReadTagBll
    {
        //antenna no.,
        public static byte AntennaNo = 0x01;
        public static ushort TidLength = 8;
        public static ushort UserdataOffset = 0;
        public static ushort UserdataLength = 28;
        public static byte Readtimes_6C = 0x01;
        public static byte Readtimes_6B = 0x01;
        public static string strpwd = "00000000";
        public static bool IsLoop = true;

      
     
        public static ReadTag ConcreateReadTag(byte TargetCodeArea, ushort qvalue,int readTime, int stopTime)
        {
          
            ReadTag msg = null;
            switch (TargetCodeArea)
            {
                case 0:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.TID_6C,readTime,stopTime);
                    break;
                case 1:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.EPC_6C, readTime, stopTime);
                    break;
                case 2:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.EPC_TID_UserData_6C, readTime, stopTime);
                    break;
                case 3:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.EPC_TID_UserData_6C_2, readTime, stopTime);
                    break;
                case 4:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.ID_6B, readTime, stopTime);
                    break;
                case 5:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.ID_UserData_6B, readTime, stopTime);
                    break;
                case 6:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.EPC_TID_UserData_Reserved_6C_ID_UserData_6B, readTime, stopTime);
                    break;

            }
            if (msg != null)
            {
                msg.Q = (byte)qvalue;
                msg.Antenna = AntennaNo;

                //EPC_TID_UserData_6C_2 actived
                if (TargetCodeArea == 3)    //6C
                {
                    msg.TidLen = (byte)(TidLength / 2);
                    msg.UserDataPtr_6C = (byte)UserdataOffset;
                    msg.UserDataLen_6C = (byte)(UserdataLength / 2);
                }
                else if (TargetCodeArea == 5)   //6B
                {
                    msg.UserDataPtr_6B = (byte)UserdataOffset;
                    msg.UserDataLen_6B = (byte)UserdataLength;
                }
                else if (TargetCodeArea == 6)   //6B/6C
                {
                    msg.ReadTimes_6C = Readtimes_6C;
                    msg.ReadTimes_6B = Readtimes_6B;

                    msg.AccessPwd = Util.ConvertHexStringToByteArray(strpwd); ;

                    msg.TidLen = (byte)(TidLength / 2);
                    msg.UserDataPtr_6C = (byte)UserdataOffset;
                    msg.UserDataLen_6C = (byte)(UserdataLength / 2);

                    msg.UserDataPtr_6B = (byte)UserdataOffset;
                    msg.UserDataLen_6B = (byte)UserdataLength;
                }
            }
            return msg;
        }
        public static ReadTag ConcreateReadTag(byte TargetCodeArea, ushort qvalue)
        {
           
            ReadTag msg = null;
            switch (TargetCodeArea)
            {
                case 0:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.TID_6C);
                    break;
                case 1:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.EPC_6C);
                    break;
                case 2:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.EPC_TID_UserData_6C);                    
                    break;
                case 3:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.EPC_TID_UserData_6C_2);
                    break;
                case 4:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.ID_6B);
                    break;
                case 5:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.ID_UserData_6B);
                    break;
                case 6:
                    msg = new ReadTag( ReadTag.ReadMemoryBank.EPC_TID_UserData_Reserved_6C_ID_UserData_6B);
                    break;
             
            }
            if (msg != null)
            {
                
                msg.Q = (byte)qvalue;
                msg.Antenna = AntennaNo;
                msg.IsLoop = IsLoop;
                //EPC_TID_UserData_6C_2 actived
                if (TargetCodeArea == 3)    //6C
                {
                    msg.TidLen = (byte)(TidLength / 2);
                    msg.UserDataPtr_6C = (byte)UserdataOffset;
                    msg.UserDataLen_6C = (byte)(UserdataLength / 2);
                }
                else if (TargetCodeArea == 5)   //6B
                {
                    msg.UserDataPtr_6B = (byte)UserdataOffset;
                    msg.UserDataLen_6B = (byte)UserdataLength;
                }
                else if (TargetCodeArea == 6)   //6B/6C
                {
                    msg.ReadTimes_6C = Readtimes_6C;
                    msg.ReadTimes_6B = Readtimes_6B;

                    msg.AccessPwd = Util.ConvertHexStringToByteArray(strpwd); ;

                    msg.TidLen = (byte)(TidLength / 2);
                    msg.UserDataPtr_6C = (byte)UserdataOffset;
                    msg.UserDataLen_6C = (byte)(UserdataLength / 2);

                    msg.UserDataPtr_6B = (byte)UserdataOffset;
                    msg.UserDataLen_6B = (byte)UserdataLength;
                }
            }
            return msg;
        }
        public static ReadTag ConcreateReadTagOnce(byte TargetCodeArea, ushort qvalue,bool IsGetOneTag)
        {
           
            ReadTag msg = null;
            switch (TargetCodeArea)
            {
                case 0:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.TID_6C, IsGetOneTag);
                    break;
                case 1:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.EPC_6C, IsGetOneTag);
                    break;
                case 2:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.EPC_TID_UserData_6C, IsGetOneTag);
                    break;
                case 3:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.EPC_TID_UserData_6C_2, IsGetOneTag);
                    break;
                case 4:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.ID_6B, IsGetOneTag);
                    break;
                case 5:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.ID_UserData_6B, IsGetOneTag);
                    break;
                case 6:
                    msg = new ReadTag(ReadTag.ReadMemoryBank.EPC_TID_UserData_Reserved_6C_ID_UserData_6B, IsGetOneTag);
                    break;

            }
            if (msg != null)
            {
                msg.IsLoop = false;
                msg.Q = (byte)qvalue;
                msg.Antenna = AntennaNo;

                //EPC_TID_UserData_6C_2 actived
                if (TargetCodeArea == 3)    //6C
                {
                    msg.TidLen = (byte)(TidLength / 2);
                    msg.UserDataPtr_6C = (byte)UserdataOffset;
                    msg.UserDataLen_6C = (byte)(UserdataLength / 2);
                }
                else if (TargetCodeArea == 5)   //6B
                {
                    msg.UserDataPtr_6B = (byte)UserdataOffset;
                    msg.UserDataLen_6B = (byte)UserdataLength;
                }
                else if (TargetCodeArea == 6)   //6B/6C
                {
                    msg.ReadTimes_6C = Readtimes_6C;
                    msg.ReadTimes_6B = Readtimes_6B;

                    msg.AccessPwd = Util.ConvertHexStringToByteArray(strpwd); ;

                    msg.TidLen = (byte)(TidLength / 2);
                    msg.UserDataPtr_6C = (byte)UserdataOffset;
                    msg.UserDataLen_6C = (byte)(UserdataLength / 2);

                    msg.UserDataPtr_6B = (byte)UserdataOffset;
                    msg.UserDataLen_6B = (byte)UserdataLength;
                }
            }
            return msg;
        }
        public static ReadTag ConcreateReadTagOnce(byte TargetCodeArea, ushort qvalue)
        {
            return ConcreateReadTagOnce(TargetCodeArea, qvalue, false);
        }

       
    }
}
