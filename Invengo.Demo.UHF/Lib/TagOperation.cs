using System;
using System.Collections.Generic;
using System.Text;

using Invengo.NetAPI.Core;
using Invengo.NetAPI.Communication;
using Invengo.NetAPI.Protocol.IRP1;
using Invengo.Devices.ModuleControl;
using System.Windows.Forms;

namespace Invengo.Sample
{
    public class TagOperation
    {
        public static Reader RfReader;
        public static byte Antenna = 0x01;

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

            if (RfReader.Send(msg))
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
                Log.Debug(errInfo);
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


        public static bool GetAntennaPower(out byte[] powerlist, out string errInfo)
        {
            errInfo = "";
            powerlist = null;
            SysQuery_800 msg = new SysQuery_800(0x03, 0x00);
            if (RfReader.Send(msg))
            {
                powerlist = msg.ReceivedMessage.QueryData;
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
            }
            return false;
        }

        public static bool GetPowerList(out byte[] val, out string errInfo)
        {
            errInfo = "";
            val = null;
            SysQuery_800 msg = new SysQuery_800(0x0c);//0x30
            if (RfReader.Send(msg))
            {
                val = msg.ReceivedMessage.QueryData;
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
            }
            return false;
        }

        public static bool SetAntennaPower(byte val, out string errInfo)
        {
            errInfo = "";
            byte[] bval = new byte[] { 0x00, val }; //#1
            Invengo.NetAPI.Protocol.IRP1.SysConfig_800 msg = new SysConfig_800(0x03, bval);
            if (RfReader.Send(msg))
            {
                return true;
            }
            else
            {
                errInfo = msg.ErrInfo;
            }
            return false;
        }

        public static bool SetDefualtTidLength(ushort val, out string errInfo)
        {
            errInfo = "";
            ushort v1 = (ushort)(val / 2);
            byte[] bval = new byte[] { (byte)v1 };
            Invengo.NetAPI.Protocol.IRP1.TagOperationConfig_6C msg = new TagOperationConfig_6C(0x15, bval);
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
            }
            return false;
        }

        public static bool GetScanInterval(out ushort val, out string errInfo)
        {
            errInfo = "";
            val = 30;
            Invengo.NetAPI.Protocol.IRP1.SysQuery_800 msg = new SysQuery_800(0x12);
            if (RfReader.Send(msg))
            {
                if (msg.ReceivedMessage != null
                    && msg.ReceivedMessage.QueryData != null
                    && msg.ReceivedMessage.QueryData.Length > 0)
                {
                    val = msg.ReceivedMessage.QueryData[0];
                }
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
            }
            return false;
        }


        public static bool SetScanInterval(ushort val, out string errInfo)
        {
            errInfo = "";
            byte[] bval = new byte[] { (byte)val };
            Invengo.NetAPI.Protocol.IRP1.SysConfig_800 msg = new SysConfig_800(0x12, bval);
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
            }
            return false;
        }

        public static bool SetLoopRead(out string errInfo)
        {
            errInfo = "";
            Invengo.NetAPI.Protocol.IRP1.SysConfig_800 msg = new SysConfig_800(0x01, new byte[] { 0x00, 0x00 });
            if (RfReader.Send(msg))
            {
                return true;
            }
            else
            {
                errInfo = msg.ErrInfo;
            }
            return false;
        }


        public static bool GetDefaultTidLength(out ushort val, out string errInfo)
        {
            errInfo = "";
            val = 30;
            Invengo.NetAPI.Protocol.IRP1.TagOperationQuery_6C msg = new TagOperationQuery_6C(0x15);
            if (RfReader.Send(msg))
            {
                if (msg.ReceivedMessage != null
                    && msg.ReceivedMessage.QueryData != null
                    && msg.ReceivedMessage.QueryData.Length > 0)
                {
                    val = (ushort)(msg.ReceivedMessage.QueryData[0] * 2);
                }
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
            }
            return false;
        }

        public static bool SetRssiStatus(bool enable, out string errInfo)
        {
            errInfo = "";
            //0x1B: RSSI
            //0x01: set , 0x00: cancel
            byte[] bval = new byte[] { 0x00 };
            if (enable)
            {
                bval[0] = 0x01;
            }
            Invengo.NetAPI.Protocol.IRP1.SysConfig_800 msg = new SysConfig_800(0x14, bval);
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
            }
            return false;
        }

        public static bool GetRssiStatus(out ushort val, out string errInfo)
        {
            errInfo = "";
            val = 30;
            Invengo.NetAPI.Protocol.IRP1.SysQuery_800 msg = new SysQuery_800(0x14);
            if (RfReader.Send(msg))
            {
                if (msg.ReceivedMessage != null
                    && msg.ReceivedMessage.QueryData != null
                    && msg.ReceivedMessage.QueryData.Length > 0)
                {
                    val = (ushort)msg.ReceivedMessage.QueryData[0];
                }
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
            }
            return false;
        }


        #endregion

        #region 6B

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

       
        #endregion



    }
}
