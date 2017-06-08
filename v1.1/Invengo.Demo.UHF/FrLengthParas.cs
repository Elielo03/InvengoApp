using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Invengo.Sample
{
    public partial class FrLengthParas : Form
    {
        RFIDModule RfidType = RFIDModule.F6C;
        public FrLengthParas(RFIDModule _RfidType)
        {
            RfidType = _RfidType;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ushort itid = Convert.ToUInt16(tvTidLength.Text);
                ushort iuser = Convert.ToUInt16(tvUserdataLength.Text);
                ushort ioffset = Convert.ToUInt16(tvUserdataOffset.Text);
                string strpwd = tvPassWord.Text.Trim();
                if (RfidType == RFIDModule.F6C)
                {
                    if (itid % 2 != 0)
                    {
                        ReadTagBll.TidLength = (ushort)((itid / 2) * 2);
                    }
                    else
                    {
                        ReadTagBll.TidLength = itid;
                    }

                    if (iuser % 2 != 0)
                    {
                        ReadTagBll.UserdataLength = (ushort)((iuser / 2) * 2);
                    }
                    else
                    {
                        ReadTagBll.UserdataLength = iuser;
                    }
                }
                else
                {
                    ReadTagBll.TidLength = itid;
                    ReadTagBll.UserdataLength = iuser;
                    ReadTagBll.UserdataOffset = ioffset;
                    ReadTagBll.strpwd = strpwd;

                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrLengthParas_Load(object sender, EventArgs e)
        {
            if (RfidType != RFIDModule.F6C_F6B)
            {
                this.label4.Visible = false;
                this.tvPassWord.Visible = false;
            }
            else
            {
                this.label4.Visible = true;
                this.tvPassWord.Visible = true;
            }
        }
    }
}