using System;
using System.Collections.Generic;
using System.Text;

using Invengo.NetAPI.Core;
using Invengo.NetAPI.Communication;
using Invengo.NetAPI.Protocol.IRP1;

namespace Invengo.Sample
{
    public class RfidConfigration_6C
    {
        public static Reader RfReader;
        public static byte Antenna = 0x01;

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

        public static bool GetPowerList(out byte[] val, out string errInfo)
        {
            errInfo = "";
            val = null;
            SysQuery_800 msg = new SysQuery_800(0x30);
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

        public static bool GetProductNo(out string proNo, out string errInfo)
        {
            proNo = "";
            errInfo = "";
            SysQuery_800 msg = new SysQuery_800(0x21, 0x00);
            if (RfReader.Send(msg))
            {
                if (msg.ReceivedMessage.QueryData != null && msg.ReceivedMessage.QueryData.Length > 0)
                {
                    proNo = Encoding.Default.GetString(msg.ReceivedMessage.QueryData, 0, msg.ReceivedMessage.QueryData.Length);
                    return true;
                }
                return false;
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

        public static bool GetBasebandSoftwareVersion(out string ver, out string errInfo)
        {
            ver = "";
            errInfo = "";
            SysQuery_800 msg = new SysQuery_800(0x23, 0x00);
            if (RfReader.Send(msg))
            {
                if (msg.ReceivedMessage.QueryData != null && msg.ReceivedMessage.QueryData.Length > 0)
                {
                    ver = Encoding.Default.GetString(msg.ReceivedMessage.QueryData, 0, msg.ReceivedMessage.QueryData.Length);
                    return true;
                }
                return false;
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

        public static bool GetHardwareVersion(out string ver, out string errInfo)
        {
            ver = "";
            errInfo = "";
            SysQuery_800 msg = new SysQuery_800(0x25, 0x00);
            if (RfReader.Send(msg))
            {
                if (msg.ReceivedMessage.QueryData != null && msg.ReceivedMessage.QueryData.Length > 0)
                {
                    ver = Encoding.Default.GetString(msg.ReceivedMessage.QueryData, 0, msg.ReceivedMessage.QueryData.Length);
                    return true;
                }
                return false;
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

        public static bool GetFrequencyBand(out string freqBand, out string errInfo)
        {
            freqBand = "";
            errInfo = "";
            //string proNo = "";
            //bool ret = false;
            //if (GetProductNo(out proNo, out errInfo))
            //{
            //    if (!string.IsNullOrEmpty(proNo) && proNo[proNo.Length - 1] == 'A')
            //    {
            //        freqBand = "FCC";
            //        ret = true;
            //    }
            //    else if (!string.IsNullOrEmpty(proNo) && proNo[proNo.Length - 1] == 'C')
            //    {
            //        freqBand = "CN";
            //        ret = true;
            //    }
            //}

            bool ret = false;
            Invengo.NetAPI.Protocol.IRP1.SysQuery_800 msg = new SysQuery_800(0x15);
            if (RfReader.Send(msg))
            {
                if (msg.ReceivedMessage.QueryData != null && msg.ReceivedMessage.QueryData.Length > 0)
                {
                    byte band = msg.ReceivedMessage.QueryData[0];
                    switch (band)
                    {
                        case 0x00:
                            freqBand = "CN";
                            break;
                        case 0x01:
                            freqBand = "FCC";
                            break;
                        case 0x02:
                            freqBand = "EU"; //"ESTI";
                            break;
                        case 0x03:
                            freqBand = "KOREA";
                            break;
                        case 0x04:
                            freqBand = "JAPEN";
                            break;
                        case 0x05:
                            freqBand = "CN2";
                            break;
                    }
                    ret = true;
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
            }
            return ret;
        }

        public static bool GetFrequency(out byte[] freq, out string errInfo)
        {
            freq = null;
            errInfo = "";
            SysQuery_800 msg = new SysQuery_800(0x04, 0x00);
            if(RfReader.Send(msg))
            {
                freq = msg.ReceivedMessage.QueryData;
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

        public static bool SetFrequency(byte[] data, out string errInfo)
        {
            errInfo = "";
            SysConfig_800 msg = new SysConfig_800(0x04, data);
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

        public static bool SetEpcFilter(byte opType, byte[] epc, byte[] mask, out string errInfo )
        {
            errInfo = "";
            EpcFilter_6C msg = new EpcFilter_6C(opType, epc, mask);
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

        public static bool SetOverlapFilter(byte opType, ushort interval, out string errInfo)
        {
            errInfo = "";
            byte[] bval = BitConverter.GetBytes(interval);
            byte[] stime = new byte[2];
            stime[0] = bval[1];
            stime[1] = bval[0];
            Invengo.NetAPI.Protocol.IRP1.FilterByTime msg = new FilterByTime(opType, stime);
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

        public static bool FirmwareUpgrade_6C(out string errInfo)
        {
            errInfo = "";
            Invengo.NetAPI.Protocol.IRP1.FirmwareUpgrade_800 msg = new FirmwareUpgrade_800();
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
    }
}
