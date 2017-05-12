using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Invengo.Platform;
using System.Runtime.InteropServices;

namespace Invengo.Sample
{
    public partial class FrBattery : Form
    {
       
        public bool IsDelayLoad = false;

        PDAInfo.DevModel _pdatype;

        public FrBattery()
        {
            InitializeComponent();
            _pdatype = PDAInfo.GetDevModel();
            GetInfoAsync();
            timerGetPower.Enabled = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            IsDelayLoad = true;

            base.OnLoad(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            timerGetPower.Enabled = false;

            base.OnClosed(e);
        }

       

        public void GetInfoAsync()
        {
            Invoke(new EventHandler(GetInfo));
        }

        /// <summary>
        /// Get Info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetInfo(object sender, EventArgs e)
        {
            BatteryQuery.PowerInfo obj = BatteryQuery.GetPowerInfo(_pdatype);
            if (obj == null)
                return;

            lblPowerType.Text = obj.PowerType;

            lblLifePercent.Text = obj.LifePercent;

            lblVoltage.Text = obj.Voltage;

            lblBatteryStatus.Text = obj.BaterryStatus;

            if (obj.BakcupBatteryFlag != SystemPower.BATTERY_PERCENTAGE_UNKNOWN)
            {
                if (!panel2.Visible)
                    panel2.Visible = true;
                lblBakVoltage.Text = string.Format("{0}V", obj.BakcupBatteryVoltage);
                lblBakPercent.Text = string.Format("{0}%", obj.BakcupBatteryLifePercent);
            }
        }

        private void timerGetPower_Tick(object sender, EventArgs e)
        {
            timerGetPower.Enabled = false;

            GetInfoAsync();

            timerGetPower.Enabled = true;
        }

        private void timerGetPower_Tick_1(object sender, EventArgs e)
        {
            timerGetPower.Enabled = false;

            GetInfoAsync();

            timerGetPower.Enabled = true;
        }

        private void lblBakPercent_ParentChanged(object sender, EventArgs e)
        {

        }

        private void FrBattery_Load(object sender, EventArgs e)
        {

        }
    }


    /// <summary>
    /// Battery Query
    /// </summary>
    public class BatteryQuery
    {
        public class PowerInfo
        {
            public string PowerType;
            public string Voltage;
            public string LifePercent;
            public string BaterryStatus;
            public byte BakcupBatteryFlag;
            public float BakcupBatteryVoltage;
            public byte BakcupBatteryLifePercent;
        }


        /// <summary>
        /// Get Power Info
        /// </summary>
        /// <param name="pdatype"></param>
        /// <returns></returns>
        public static PowerInfo GetPowerInfo(PDAInfo.DevModel pdatype)
        {
            PowerInfo obj = null;
            try
            {
                int mRetLen;
                string temp_str;
                ushort temp;
                byte[] mBatVoltageBuf = new byte[2];
                SystemPower.SYSTEM_POWER_STATUS_EX2 sSysPowerStatus = new SystemPower.SYSTEM_POWER_STATUS_EX2();
                int wlen = Marshal.SizeOf(sSysPowerStatus);
                mRetLen = SystemPower.GetSystemPowerStatusEx2(ref sSysPowerStatus, wlen, true);
                if (mRetLen < 1)
                    return null;			// Get System Power Status Error

                obj = new PowerInfo();
                if (sSysPowerStatus.ACLineStatus == SystemPower.AC_LINE_ONLINE)
                {
                    obj.PowerType = "AC power supply";
                }
                else
                {
                    obj.PowerType = "Battery power supply";
                }

              
                {
                    temp = (ushort)(((sSysPowerStatus.BatteryVoltage)) / 100);      //2903
                    mBatVoltageBuf[0] = (byte)temp;   //ProcessVoltageValue(temp);
                }
            
                mBatVoltageBuf[1] = (byte)(mBatVoltageBuf[0] % 10);
                mBatVoltageBuf[0] = (byte)(mBatVoltageBuf[0] / 10);
                temp_str = string.Format("{0}.{1}V", mBatVoltageBuf[0], mBatVoltageBuf[1]);
                obj.Voltage = temp_str;

                //lifePercent;
                temp = sSysPowerStatus.BatteryLifePercent;
                if ((temp >= 100) && (temp != SystemPower.BATTERY_PERCENTAGE_UNKNOWN))
                {
                    temp = 100;
                }
                if ((temp == SystemPower.BATTERY_PERCENTAGE_UNKNOWN)
                    || (sSysPowerStatus.ACLineStatus == SystemPower.AC_LINE_ONLINE))
                {
                    obj.LifePercent = "Unknow";
                }
                else
                {
                    
                    {
                        mBatVoltageBuf[0] = (byte)temp;
                    }
                 
                    temp_str = string.Format("{0} %", mBatVoltageBuf[0]);
                    obj.LifePercent = temp_str;
                }

                temp = sSysPowerStatus.BatteryFlag;
                switch ((uint)temp)
                {
                    case SystemPower.BATTERY_FLAG_HIGH:
                        obj.BaterryStatus = "Discharge";
                        break;

                    case SystemPower.BATTERY_FLAG_LOW:
                        obj.BaterryStatus = "Power lower";
                        break;

                    case SystemPower.BATTERY_FLAG_CRITICAL:
                        obj.BaterryStatus = "Power extremely low";
                        break;

                    case SystemPower.BATTERY_FLAG_CHARGING:
                        obj.BaterryStatus = "Charging";
                        break;

                    case SystemPower.BATTERY_FLAG_NO_BATTERY:
                        obj.BaterryStatus = "No baterry";
                        break;

                    case SystemPower.BATTERY_FLAG_UNKNOWN:
                    default:
                        obj.BaterryStatus = "Unknown status";
                        break;
                }

                //backup battery
                obj.BakcupBatteryFlag = sSysPowerStatus.BackupBatteryFlag;
                if (obj.BakcupBatteryFlag != SystemPower.BATTERY_FLAG_NO_BATTERY
                    || obj.BakcupBatteryFlag != sSysPowerStatus.BackupBatteryFlag)
                {
                    int bval = sSysPowerStatus.BackupBatteryVoltage;
                    byte[] tmpBuf = new byte[2];
                    tmpBuf[0] = (byte)(bval / 100);
                    tmpBuf[1] = (byte)(tmpBuf[0] / 10);
                    tmpBuf[0] = (byte)(tmpBuf[0] % 10);

                    obj.BakcupBatteryVoltage = Convert.ToSingle(string.Format("{0}.{1}", tmpBuf[1], tmpBuf[0]));

                    int bPer = sSysPowerStatus.BackupBatteryLifePercent;
                    if ((bPer > 100) && (bPer != SystemPower.BATTERY_PERCENTAGE_UNKNOWN))
                    {
                        bPer = 100;
                    }
                    if (bPer == SystemPower.BATTERY_PERCENTAGE_UNKNOWN)
                    {
                        obj.BakcupBatteryLifePercent = 0;
                    }
                    else
                    {
                        obj.BakcupBatteryLifePercent = (byte)bPer;
                    }
                }
            }
            catch { }

            return obj;
        }

        static byte[] aPercent = new byte[] { 0, 0, 0, 0, 0 };
        static byte mOldPercent = 0x00;

        /// <summary>
        /// Process Battery Life Percent
        /// </summary>
        /// <param name="mBatteryLifePercent"></param>
        /// <returns></returns>
        protected static byte ProcessBatteryLifePercent(byte mBatteryLifePercent)
        {
            ushort mPercentValueTatol;
            byte i;

            for (i = 3; i < 4; i--)
            {
                aPercent[i + 1] = aPercent[i];
            }
            aPercent[0] = mBatteryLifePercent;
            mPercentValueTatol = 0x00;

            for (i = 0; i < 5; i++)
            {
                if (aPercent[i] > 0)
                {
                    mPercentValueTatol += aPercent[i];
                }
                else break;
            }
            if (i > 0)
            {
                mPercentValueTatol = (ushort)(mPercentValueTatol / i);
            }
            else
            {
                mPercentValueTatol = 0;
            }
            if (mPercentValueTatol < 96)
            {
                if (mPercentValueTatol < mOldPercent)
                    mPercentValueTatol += 5;
            }
            i = (byte)(mPercentValueTatol % 5);
            mPercentValueTatol -= i;
            mOldPercent = (byte)mPercentValueTatol;
            return (byte)mPercentValueTatol;
        }

        //Process Voltage Value
        static ushort[] aVoltageValueBuf = { 0, 0, 0, 0, 0 };
        static ushort mOldBatVoltage = 0x00;
        private static byte ProcessVoltageValue(ushort mVoltageValue)
        {
            int mBatValueTatol;
            int i;

            if (mVoltageValue < 300)
            {
                mBatValueTatol = (mVoltageValue / 10);
            }
            else
            {
                for (i = 3; i < 4 && i >= 0; i--)
                {
                    aVoltageValueBuf[i + 1] = aVoltageValueBuf[i];
                }
                aVoltageValueBuf[0] = mVoltageValue;
                mBatValueTatol = 0x00;
                for (i = 0; i < 5; i++)
                {
                    if (aVoltageValueBuf[i] > 0)
                    {
                        mBatValueTatol += aVoltageValueBuf[i];
                    }
                    else break;
                }
                mBatValueTatol = mBatValueTatol / i;
                i = mBatValueTatol % 10;
                mBatValueTatol = mBatValueTatol / 10;

                if (mOldBatVoltage > mBatValueTatol)
                {
                    if (i > 4) //
                    {
                        mBatValueTatol += 1;
                    }
                    else
                    {
                        if ((mOldBatVoltage - mBatValueTatol) > 1)
                        {
                            mBatValueTatol += 1;
                        }
                    }
                }
                else
                {
                    if ((mBatValueTatol - mOldBatVoltage) > 1)
                    {
                        mBatValueTatol -= 1;
                    }
                }
                mOldBatVoltage = (ushort)mBatValueTatol;
            }
            return (byte)mBatValueTatol;
        }

    }
}