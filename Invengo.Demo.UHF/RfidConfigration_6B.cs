using System;
using System.Collections.Generic;
using System.Text;

using Invengo.NetAPI.Core;
using Invengo.NetAPI.Communication;
using Invengo.NetAPI.Protocol.IRP1;

namespace Invengo.Sample
{
    public class RfidConfigration_6B
    {
        public static Reader RfReader;
        public static byte Antenna = 0x01;

        public static bool GetAntennaPower(out byte[] powerlist, out string errInfo)
        {
            errInfo = "";
            powerlist = null;
            SysQuery_500 msg = new SysQuery_500(0x07, 0x01);
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
            byte[] bval = new byte[] { val }; //#1
            Invengo.NetAPI.Protocol.IRP1.SysConfig_500 msg = new SysConfig_500(0x07, (byte)bval.Length, bval);
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

        public static bool GetPowerList(out byte[] val, out string errInfo)
        {
            errInfo = "";
            val = null;
            ////SysQuery_800 msg = new SysQuery_800(0x30);
            ////if (RfReader.Send(msg))
            ////{
            ////    val = msg.ReceivedMessage.QueryData;
            ////    return true;
            ////}
            ////else
            ////{
            ////    if (msg.ErrInfo == null || msg.ErrInfo == "")
            ////    {
            ////        errInfo = string.Format("0x{0}", msg.StatusCode.ToString("X2"));
            ////    }
            ////    else
            ////    {
            ////        errInfo = msg.ErrInfo;
            ////    }
            ////}
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

        public static bool GetFrequency(out byte[] freq, out string errInfo)
        {
            freq = null;
            errInfo = "";
            SysQuery_500 msg = new SysQuery_500(0x01, 0x1E);
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
            SysConfig_500 msg = new SysConfig_500(0x01, (byte)data.Length, data);
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
       
    }
}
