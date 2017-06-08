using System;
using System.Collections.Generic;
using System.Text;

using Invengo.NetAPI.Core;
using Invengo.NetAPI.Communication;
using Invengo.NetAPI.Protocol.IRP1;
using Invengo.Devices.ModuleControl;

namespace Invengo.Demo.UHF
{
    public class TagOperation
    {
        public static Reader RfReader;
        public static byte Antenna = 0x01;

        /// <summary>
        /// RFID Connect
        /// </summary>
        public static void RfidConnecte()
        {
            RfidControl.Active();
            if (RfReader.IsConnected)
            {


            }
            else
            {
                try
                {
                    RfReader.Connect();

                }
                catch { }


            }
        }

        /// <summary>
        /// Disconnect
        /// </summary>
        public static void Disconnect()
        {
            if (RfReader != null)
            {
                RfReader.Disconnect();
                RfReader.Dispose();
            }
        }

        /// <summary>
        /// Power Off
        /// </summary>
        public static void PowerOff()
        {
            try
            {
                if (RfReader != null)
                {
                    RfReader.Send(new PowerOff());
                    Disconnect();
                }
                RfidControl.Deactive();

            }
            catch { }

        }

        #region 6C
        public static bool TargetTag_6C(byte[] selCode, MemoryBank selArea, byte offset, byte length, out string errInfo)
        {
            errInfo = "";
            SelectTag_6C msg = new SelectTag_6C(selArea, offset, (byte)(length * 8), selCode);
            if (RfReader.Send(msg))
            {
                return true;
            }
            else
            {
                if (msg.ErrInfo == null || msg.ErrInfo == "")
                {
                    errInfo = string.Format("0x{0}", msg.StatusCode.ToString("X2"));
                }
                else
                {
                    errInfo = msg.ErrInfo;
                }
                Log.Debug(errInfo);
            }
            return false;
        }

        public static bool ReadUserdata_6C(uint offsetAddr, uint length, byte[] selCode, MemoryBank selArea, out byte[] data, out string errInfo)
        {
            data = null;
            errInfo = "";
            byte readlen = (byte)(length / 2);
            byte ptr = (byte)(offsetAddr / 2);
            ReadUserData_6C msg;
            if (selCode != null)
            {
                msg = new ReadUserData_6C(0x01, ptr, readlen, selCode, selArea);
            }
            else
            {
                msg = new ReadUserData_6C(0x01, ptr, readlen);
            }

            if (RfReader.Send(msg, 1500))
            {
                data = msg.ReceivedMessage.UserData;
                if( data != null)
                    return true;
            }
            else
            {
                if (msg.ErrInfo == null || msg.ErrInfo == "")
                {
                    errInfo = string.Format("0x{0}", msg.StatusCode.ToString("X2"));
                }
                else
                {
                    errInfo = msg.ErrInfo;
                }
                Log.Debug(errInfo);
            }
            return false;
        }

        public static bool WriteUserdata_6C(uint offset, byte[] accessPwd, byte[] writedata, byte[] selCode, MemoryBank selArea, out string errInfo)
        {
            errInfo = "";
            WriteUserData_6C msg;
            byte ptr = (byte)(offset / 2);
            if (selCode != null)
            {
                msg = new WriteUserData_6C(Antenna, accessPwd, ptr, writedata, selCode, selArea);
            }
            else
            {
                msg = new WriteUserData_6C(Antenna, accessPwd, ptr, writedata);
            }
            if (RfReader.Send(msg))
            {
                return true;
            }
            else
            {
                if (msg.ErrInfo == null || msg.ErrInfo == "")
                {
                    errInfo = string.Format("0x{0}", msg.StatusCode.ToString("X2"));
                }
                else
                {
                    errInfo = msg.ErrInfo;
                }
                Log.Debug(errInfo);
            }
            return false;
        }

        public static bool BlockWriteDataRaw_6C(uint offset, byte[] accessPwd, MemoryBank writebank, byte blockLength, byte[] writedata, byte[] selCode, MemoryBank selArea, out string errInfo)
        {
            BlockWrite_6C msg;
            errInfo = "";
            byte ptr = (byte)(offset / 2);
            if (selCode != null)
            {
                msg = new BlockWrite_6C(Antenna, accessPwd, writebank, ptr, blockLength, writedata, selCode, selArea);
            }
            else
            {
                msg = new BlockWrite_6C(Antenna, accessPwd, writebank, ptr, blockLength, writedata);
            }
            if (RfReader.Send(msg))
            {
                return true;
            }
            else
            {
                if (msg.ErrInfo == null || msg.ErrInfo == "")
                {
                    errInfo = string.Format("0x{0}", msg.StatusCode.ToString("X2"));
                }
                else
                {
                    errInfo = msg.ErrInfo;
                }
                Log.Debug(errInfo);
            }
            return false;
        }

        public static bool BlockWriteData_6C(uint offset, byte[] accessPwd, MemoryBank writebank, byte[] writedata, byte[] selCode, MemoryBank selArea, ushort maxBlockLength, out int hadLen, out string errInfo)
        {
            bool ret = false;
            int tmpLen = writedata.Length;
            hadLen = 0;
            if (maxBlockLength < 1)
                maxBlockLength = 4;
            errInfo = "";
            bool bl = false;
            do
            {
                tmpLen = (writedata.Length - hadLen);
                if (tmpLen <= 0)
                    break;
                if (tmpLen > maxBlockLength)
                    tmpLen = maxBlockLength;
                byte[] tmpArr = new byte[tmpLen];
                Array.Copy(writedata, hadLen, tmpArr, 0, tmpLen);
                uint iOffset = (uint)(offset + hadLen);
                for (int i = 0; i < 3; i++)
                {
                    bl = BlockWriteDataRaw_6C(iOffset, accessPwd, writebank, (byte)maxBlockLength, tmpArr, selCode, selArea, out errInfo);
                    if (bl)
                        break;
                }
                if (!bl)
                    break;
                hadLen += tmpArr.Length;
            } while (hadLen < writedata.Length);

            if (hadLen >= writedata.Length)
            {
                hadLen = writedata.Length;
                ret = true;
            }
            return ret;
        }

        public static bool BlockEraseData_6C(uint offset, byte[] accessPwd, MemoryBank writebank, uint blockLength, uint blockSize, byte[] selCode, MemoryBank selArea, out string errInfo)
        {
            BlockErase_6C msg;
            errInfo = "";
            byte ptr = (byte)(offset / 2);
            if (selCode != null)
            {
                msg = new BlockErase_6C(Antenna, accessPwd, writebank, ptr, (byte)blockLength, (byte)blockSize, selCode, selArea);
            }
            else
            {
                msg = new BlockErase_6C(Antenna, accessPwd, writebank, ptr, (byte)blockLength, (byte)blockSize);
            }
            if (RfReader.Send(msg))
            {
                return true;
            }
            else
            {
                if (msg.ErrInfo == null || msg.ErrInfo == "")
                {
                    errInfo = string.Format("0x{0}", msg.StatusCode.ToString("X2"));
                }
                else
                {
                    errInfo = msg.ErrInfo;
                }
                Log.Debug(errInfo);
            }
            return false;
        }

        public static bool ReadEpc(byte[] selCode, MemoryBank selArea, ushort qvalue, out byte[] epc, out string errInfo)
        {
            epc = null;
            errInfo = "";
            Invengo.NetAPI.Protocol.IRP1.ReadTag msg = new ReadTag(ReadTag.ReadMemoryBank.EPC_6C, true);
            //msg.IsLoop = false;
            //msg.IsReturn = true;
            if (selCode != null)
            {
                if (!TargetTag_6C(selCode, selArea, 0x00, (byte)selCode.Length, out errInfo))
                {
                    return false;
                }
            }

            if (RfReader.Send(msg, 1000))
            {
                if (msg.ReceivedMessage != null)
                {
                    RXD_TagData[] brecv = msg.ReceivedMessage.List_RXD_TagData;
                    if (brecv != null && brecv.Length > 0)
                    {
                        epc = brecv[0].ReceivedMessage.EPC;
                        return true;
                    }
                }
            }
            else
            {
                if (msg.ErrInfo == null || msg.ErrInfo == "")
                {
                    errInfo = string.Format("0x{0}", msg.StatusCode.ToString("X2"));
                }
                else
                {
                    errInfo = msg.ErrInfo;
                }
                Log.Debug(errInfo);
            }
            return false;
        }
        /// <summary>
        /// Read TID
        /// </summary>
        /// <param name="selCode"></param>
        /// <param name="selArea"></param>
        /// <param name="qvalue"></param>
        /// <param name="epc"></param>
        /// <param name="errInfo"></param>
        /// <returns></returns>
        public static bool ReadTID(byte[] selCode, MemoryBank selArea, ushort qvalue, out byte[] TID, out string errInfo)
        {
            TID = null;
            errInfo = "";
            Invengo.NetAPI.Protocol.IRP1.ReadTag msg = new ReadTag(ReadTag.ReadMemoryBank.TID_6C, false);
            //msg.IsLoop = false;
            //msg.IsReturn = true;

            try
            {
                if (RfReader.Send(msg, 1000))
                {

                    RXD_TagData[] brecv = msg.ReceivedMessage.List_RXD_TagData;
                    if (brecv != null && brecv.Length > 0)
                    {
                        TID = brecv[0].ReceivedMessage.TID;
                        return true;
                    }


                }
                else
                {
                    if (msg.ErrInfo == null || msg.ErrInfo == "")
                    {
                        errInfo = string.Format("0x{0}", msg.StatusCode.ToString("X2"));
                    }
                    else
                    {
                        errInfo = msg.ErrInfo;
                    }
                    Log.Debug(errInfo);
                }
            }
            catch (Exception e)
            {
                string err = e.ToString();
                errInfo = "No tag respondse!";
                return false;
            }
            return false;
        }
        public static bool WriteEpc(byte[] accessPwd, byte[] writedata, byte[] selCode, MemoryBank selArea, out string errInfo)
        {
            errInfo = "";
            Invengo.NetAPI.Protocol.IRP1.WriteEpc msg;
            if (selCode != null)
            {
                msg = new WriteEpc(Antenna, accessPwd, writedata, selCode, selArea);
            }
            else
            {
                msg = new WriteEpc(Antenna, accessPwd, writedata);
            }
            if (RfReader.Send(msg))
            {
                if( msg.StatusCode == 0x00)
                    return true;
            }
            else
            {
                if (msg.ErrInfo == null || msg.ErrInfo == "")
                {
                    errInfo = string.Format("0x{0}", msg.StatusCode.ToString("X2"));
                }
                else
                {
                    errInfo = msg.ErrInfo;
                }
                Log.Debug(msg.ErrInfo);
            }
            return false;
        }

        public static bool SetAccessPassword(byte[] oldAccessPwd, byte[] newAccessPwd, byte[] selCode, MemoryBank selArea, out string errInfo)
        {
            errInfo = "";
            Invengo.NetAPI.Protocol.IRP1.AccessPwdConfig_6C msg = null;
            if (selCode != null)
            {
                msg = new AccessPwdConfig_6C(Antenna, oldAccessPwd, newAccessPwd, selCode, selArea);
            }
            else
            {
                msg = new AccessPwdConfig_6C(Antenna, oldAccessPwd, newAccessPwd);
            }

            if (RfReader.Send(msg))
            {
                return true;
            }
            else
            {
                if (msg.ErrInfo == null || msg.ErrInfo == "")
                {
                    errInfo = string.Format("0x{0}", msg.StatusCode.ToString("X2"));
                }
                else
                {
                    errInfo = msg.ErrInfo;
                }
                Log.Debug(msg.ErrInfo);
            }
            return false;
        }

        public static bool SetKillPassword(byte[] accessPwd, byte[] killPwd, byte[] selCode, MemoryBank selArea, out string errInfo)
        {
            errInfo = "";
            Invengo.NetAPI.Protocol.IRP1.KillPwdConfig_6C msg = null;
            if (selCode != null)
            {
                msg = new KillPwdConfig_6C(Antenna, accessPwd, killPwd, selCode, selArea);
            }
            else
            {
                msg = new KillPwdConfig_6C(Antenna, accessPwd, killPwd);
            }

            if (RfReader.Send(msg))
            {
                return true;
            }
            else
            {
                if (msg.ErrInfo == null || msg.ErrInfo == "")
                {
                    errInfo = string.Format("0x{0}", msg.StatusCode.ToString("X2"));
                }
                else
                {
                    errInfo = msg.ErrInfo;
                }
                Log.Debug(msg.ErrInfo);
            }
            return false;
        }

        public static bool LockTag_6C(byte[] accessPwd, byte operation, byte bank, byte[] selCode, MemoryBank selArea, out string errInfo)
        {
            errInfo = "";
            Invengo.NetAPI.Protocol.IRP1.LockMemoryBank_6C msg = null;
            if (selCode != null)
            {
                msg = new LockMemoryBank_6C(Antenna, accessPwd, operation, bank, selCode, selArea);
            }
            else
            {
                msg = new LockMemoryBank_6C(Antenna, accessPwd, operation, bank);
            }

            if (RfReader.Send(msg))
            {
                return true;
            }
            else
            {
                if (msg.ErrInfo == null || msg.ErrInfo == "")
                {
                    errInfo = string.Format("0x{0}", msg.StatusCode.ToString("X2"));
                }
                else
                {
                    errInfo = msg.ErrInfo;
                }
                Log.Debug(msg.ErrInfo);
            }
            return false;
        }

        public static bool KillTag_6C(byte[] killPwd, byte[] epc, out string errInfo)
        {
            errInfo = "";
            Invengo.NetAPI.Protocol.IRP1.KillTag_6C msg = new KillTag_6C(Antenna, killPwd, epc);
            if (RfReader.Send(msg))
            {
                return true;
            }
            else
            {
                if (msg.ErrInfo == null || msg.ErrInfo == "")
                {
                    errInfo = string.Format("0x{0}", msg.StatusCode.ToString("X2"));
                }
                else
                {
                    errInfo = msg.ErrInfo;
                }
                Log.Debug(msg.ErrInfo);
            }
            return false;
        }
        #endregion

        #region 6B

        public void SelectTag_6B()
        {
        }

        public static bool ReadUserdata_6B(byte[] selCode, uint offset, uint length, out byte[] data, out string errInfo)
        {
            data = null;
            errInfo = "";
            ReadUserData_6B msg = new ReadUserData_6B(Antenna, selCode, (byte)offset, (byte)length);
            if (RfReader.Send(msg))
            {
                data = msg.ReceivedMessage.UserData;
                if (data != null)
                    return true;
            }
            else
            {
                if (msg.ErrInfo == null || msg.ErrInfo == "")
                {
                    errInfo = string.Format("0x{0}", msg.StatusCode.ToString("X2"));
                }
                else
                {
                    errInfo = msg.ErrInfo;
                }
                Log.Debug(msg.ErrInfo);
            }
            return false;
        }

        public static bool WriteUserdata_6B(byte[] selCode, uint offset, byte[] writedata, out string errInfo)
        {
            errInfo = "";
            WriteUserData_6B msg = new WriteUserData_6B(Antenna, selCode, (byte)offset, writedata);
            if (RfReader.Send(msg))
            {
                return true;
            }
            else
            {
                if (msg.ErrInfo == null || msg.ErrInfo == "")
                {
                    errInfo = string.Format("0x{0}", msg.StatusCode.ToString("X2"));
                }
                else
                {
                    errInfo = msg.ErrInfo;
                }
                Log.Debug(msg.ErrInfo);
            }
            return false;
        }

        public static bool LockTag_6B(byte[] selCode, uint offset, uint length, out string errInfo)
        {
            errInfo = "";

            if (length < 1)
            {
                errInfo = "parameters error.";
                return false;
            }
            byte[] bInfo = new byte[length];
            for( int i = 0; i < bInfo.Length; i++)
            {
                bInfo[i] = 0x01;
            }
            LockUserData_6B msg = new LockUserData_6B(Antenna, selCode, bInfo);
            if (RfReader.Send(msg))
            {
                return true;
            }
            else
            {
                if (msg.ErrInfo == null || msg.ErrInfo == "")
                {
                    errInfo = string.Format("0x{0}", msg.StatusCode.ToString("X2"));
                }
                else
                {
                    errInfo = msg.ErrInfo;
                }
                Log.Debug(msg.ErrInfo);
            }
            return false;
        }

        public static bool GetLockState_6B(byte[] selCode, uint offset, uint length, out byte[] lockStatus, out string errInfo)
        {
            errInfo = "";
            lockStatus = null;

            if( length < 1 )
            {
                errInfo = "parameters error.";
                return false;
            }
            byte[] bInfo = new byte[length];
            for (int i = 0; i < bInfo.Length; i++)
            {
                bInfo[i] = 0x01;
            }
            LockStateQuery_6B msg = new LockStateQuery_6B(Antenna, selCode, bInfo);
            if (RfReader.Send(msg))
            {
                 lockStatus = msg.ReceivedMessage.LockResult;
                return true;
            }
            else
            {
                if (msg.ErrInfo == null || msg.ErrInfo == "")
                {
                    errInfo = string.Format("0x{0}", msg.StatusCode.ToString("X2"));
                }
                else
                {
                    errInfo = msg.ErrInfo;
                }
                Log.Debug(msg.ErrInfo);
            }
            return false;
        }
        #endregion
    }
}
