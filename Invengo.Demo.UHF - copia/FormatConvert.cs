using System;
using System.Collections.Generic;
using System.Text;
using Invengo.Audio;
using Invengo.NetAPI.Core;

namespace Invengo.Sample
{
    /// <summary>
    /// Format Convert
    /// </summary>
    public class FormatConvert
    {
       
       
        /// <summary>
        /// HexToValue
        /// </summary>
        /// <param name="ch">Hex</param>
        /// <returns></returns>
        public static int HexToValue(int ch)
        {
            if ((ch >= '0') && (ch <= '9'))
                return ch - '0';
            else if ((ch >= 'A') && (ch <= 'F'))
                return ch - 'A' + 10;
            else if ((ch >= 'a') && (ch <= 'f'))
                return ch - 'a' + 10;
            else
                return -1;
        }

        /// <summary>
        /// HexStringToBytes
        /// </summary>
        /// <param na</returns>
        public static byte[] HexStringToBytes(string hexValue)
        {
            if (!IsHexCharacters(hexValue))
                throw new ApplicationException("Not all the character is hex-character!");
            if (hexValue.Length % 2 != 0)
                throw new ApplicationException("The string length must be even!");
            byte[] bValue = new byte[hexValue.Length / 2];
            for (int i = 0, j = 0; i < bValue.Length && j < hexValue.Length; i++)
            {
                int highHex = HexToValue(hexValue[j]);
                int lowHex = HexToValue(hexValue[j + 1]);
                int sum = highHex * 16 + lowHex;
                bValue[i] = Convert.ToByte(sum);
                j = j + 2;
            }
            return bValue;
        }
        
     
        /// <summary>
        /// IsHexCharacters¡£
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// </returns>
        public static bool IsHexCharacters(string value)
        {
            if (value == null || value == "")
                return false;
            foreach (char c in value)
            {
                if (c < '0')
                    return false;
                else if (c > '9' && c < 'A')
                    return false;
                else if (c > 'F' && c < 'a')
                    return false;
                else if (c > 'f')
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Get the Time String
        /// </summary>
        public static String ReadTimeToString(Byte[] readTime)
        {
            String str = "";
            if (readTime == null)
                return "";
            if (readTime.Length == 6)
            {
                str = "20" + readTime[0].ToString("X2") + "-"
                    + readTime[1].ToString("X2") + "-"
                    + readTime[2].ToString("X2") + " "
                    + readTime[3].ToString("X2") + ":"
                    + readTime[4].ToString("X2") + ":"
                    + readTime[5].ToString("X2") + "(BCD)";
            }
            else if (readTime.Length == 8)
            {
                DateTime dt = DateTime.Parse("1970-01-01").
                    AddSeconds((readTime[0] << 24) + (readTime[1] << 16) + (readTime[2] << 8) + readTime[3]);
                str = dt.ToString("yyyy-MM-dd HH:mm:ss");
                UInt32 ms = ((UInt32)((readTime[4] << 24) + (readTime[5] << 16) + (readTime[6] << 8) + (readTime[7])) / 1000);
                if (ms < 1000)
                    str += "." + ms.ToString().PadLeft(3, '0') + "(UTC)";
                else
                    str = "";
            }
            return str;
        }

        /// <summary>
        /// Convert Hex String To Byte Array
        /// </summary>
        /// <param name="hexValue"></param>
        /// <returns></returns>
        public static byte[] ConvertHexStringToByteArray(string hexValue)
        {
            if (!IsHexCharacters(hexValue))
                throw new ApplicationException("Not all the character is hex-character!");
            if (hexValue.Length % 2 != 0)
                throw new ApplicationException("The string length must be even!");
            byte[] bValue = new byte[hexValue.Length / 2];
            for (int i = 0, j = 0; i < bValue.Length && j < hexValue.Length; i++)
            {
                int highHex = HexToValue(hexValue[j]);
                int lowHex = HexToValue(hexValue[j + 1]);
                int sum = highHex * 16 + lowHex;
                bValue[i] = Convert.ToByte(sum);
                j = j + 2;
            }
            return bValue;
        }

        /// <summary>
        /// Read Utc Time Fix
        /// </summary>
        /// <param name="epc"></param>
        /// <returns></returns>
        public static String ReadUtcTimeFix(Byte[] epc)
        {
            try
            {
                Byte[] utc = new Byte[8];
                Array.Copy(epc, epc.Length - 8, utc, 0, 8);
                double dec = (utc[0] << 24) + (utc[1] << 16) + (utc[2] << 8) + (utc[3]);
                DateTime utcd = DateTime.Parse("1970-01-01").AddSeconds(dec);
                String mainTime = utcd.ToString("yyyy-MM-dd HH:mm:ss");
                UInt32 ms = ((UInt32)((utc[4] << 24) + (utc[5] << 16) + (utc[6] << 8) + (utc[7])) / 1000);
                if (ms > 999)
                    return "";
                String msTime = ms.ToString().PadLeft(3, '0');  //ms  
                if (msTime.Length > 3) msTime = msTime.Substring(0, 3);
                return mainTime + "." + msTime + "(UTC)";
            }
            catch
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            }
        }
        /// <summary>
        /// Get Write Data
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Byte[] getWriteData(String str)
        {
            Byte[] data = Util.ConvertHexStringToByteArray(str);
            if (data.Length % 2 == 1)
            {
                Byte[] d = new Byte[data.Length + 1];
                Array.Copy(data, 0, d, 0, data.Length);
                return d;
            }
            return data;
        }

        /// <summary>
        /// Get PassWord
        /// </summary>
        /// <param name="pwdText"></param>
        /// <returns></returns>
        public static Byte[] getPwd(String pwdText)
        {
            if (pwdText == "")
                return new Byte[4];
            Byte[] pwd = Util.ConvertHexStringToByteArray(pwdText);
            if (pwd.Length < 4)
            {
                Byte[] p = new Byte[4];
                Array.Copy(pwd, 0, p, 4 - pwd.Length, pwd.Length);
                return p;
            }
            return pwd;
        }


        /// <summary>
        /// play success voice;
        /// </summary>
        public static void SoundRecord()
        {
            SoundPlayer.PlayWAV(@"\Windows\recend.wav");
        }

        /// <summary>
        /// play success voice;
        /// </summary>
        public static void SoundSucceed()
        {
            SoundPlayer.PlayWAV(@"\Windows\Infend.wav");
        }

        /// <summary>
        /// play error voice;
        /// </summary>
        public static void SoundError()
        {
            SoundPlayer.PlayWAV(@"\Windows\Alarm2.wav");
        }

        /// <summary>
        /// Hex To String
        /// </summary>
        /// <param name="asc"></param>
        /// <returns></returns>
        public static string HaxToStr(string Hax)
        {
           
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Hax.Length; i++)
            {
                if (Hax.Substring(i, 1) != " ")
                {
                    sb.Append(Hax.Substring(i, 1));
                }

            }

            return sb.ToString();
        }
    }
    /// <summary>
    /// combo bind data;
    /// </summary>
    public class ComboBindData
    {
        private object displayMember;
        private object valueMember;
        public object DisplayMember
        {
            get { return displayMember; }
        }

        public object ValueMember
        {
            get { return valueMember; }
        }

        public ComboBindData(object displayMember, object valueMember)
        {
            this.displayMember = displayMember;
            this.valueMember = valueMember;
        }
    }
}   //
