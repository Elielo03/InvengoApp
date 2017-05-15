using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Invengo.NetAPI.Core;
using Invengo.NetAPI.Communication;
using Invengo.NetAPI.Protocol.IRP1;
using Invengo.Platform;
using Invengo.Devices.ModuleControl;
using Invengo.Audio;
using System.Data.SQLite;

namespace Invengo.Sample
{
    public partial class FrScanTagComedor : Form
    {
        Reader reader;
        //scan tags sound;
        private UiReadSound readSnd;
        public MemoryBank selCodeArea = MemoryBank.TIDMemory;
        public RFIDModule RfidType = RFIDModule.F6C;
        private bool IsRunning;
        private int totalTimes;
        private int totalTags;
        private int readMoment;
        private int TargetCodeArea = 0;
        private ushort QValue = 3;
        private string Tid = string.Empty;
        public FrScanTagComedor(Reader _reader)
        {
            reader = _reader;
            InitializeReader();
            InitializeComponent();
            readSnd = new UiReadSound();
        }

        /// <summary>
        /// RFID Initialize
        /// </summary>
        //private void RfidInitialze()
        //{
        //    reader = new Reader(
        //       "Reader1",  "RS232", "COM4,19200");

        //    reader.OnMessageNotificationReceived +=
        //       new MessageNotificationReceivedHandle(
        //           r_OnMessageNotificationReceived);
        //}

        private void InitializeReader()
        {

            if (reader != null)
            {
                reader.OnMessageNotificationReceived += new MessageNotificationReceivedHandle(r_OnMessageNotificationReceived);

            }

        }
        /// <summary>
        /// Receive Message
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="msg"></param>
        void r_OnMessageNotificationReceived(BaseReader reader, IMessageNotification msg)
        {
            IsRunning = true;
            bool ismatch = false;//是否有数据
            string strtid = "";
            string strepc = "";
            string struserdata = "";
            string rssi = "";
            string errInfo = "";

            String msgType = msg.GetMessageType();
            msgType = msgType.Substring(msgType.LastIndexOf('.') + 1);

            switch (msgType)
            {

                #region RXD_TagData
                case "RXD_TagData":
                    {
                        RXD_TagData m = (RXD_TagData)msg;

                        strepc = Util.ConvertByteArrayToHexWordString(m.ReceivedMessage.EPC);

                        strtid = Util.ConvertByteArrayToHexWordString(m.ReceivedMessage.TID);

                        struserdata = Util.ConvertByteArrayToHexWordString(m.ReceivedMessage.UserData);


                        if (m.ReceivedMessage.RSSI != null)
                        {
                            if (reader.ModelNumber.IndexOf("502E") != -1 || reader.ModelNumber == "XC-RF811")//502E
                            {
                                rssi = m.ReceivedMessage.RSSI[0].ToString("X2") + m.ReceivedMessage.RSSI[1].ToString("X2");
                            }
                            else
                            {
                                rssi = m.ReceivedMessage.RSSI[0].ToString("X2");

                            }
                        }
                        ismatch = true;
                        AddToListAsync(new TagView1(strtid, strepc, struserdata, rssi));
                    }
                    break;
                #endregion
                default:
                    if (msg.StatusCode == 0x00)
                    {
                        ismatch = true;
                    }
                    break;

            }
            if (!ismatch)//无标签数据
            {
                errInfo = "Read Failure";
                if (msg.ErrInfo != null && msg.ErrInfo != "")
                {
                    errInfo = string.Format("Read Failure,{0}", msg.StatusCode.ToString("X2"));
                }

                AddToStatusAsync(errInfo);
            }

        }

        /// <summary>
        /// 读取标签或停止读取
        /// </summary>
        public void ReadLoop()
        {
            if (InvokeRequired)
            {
               
                BeginInvoke(new EventHandler(ReadLoopRaw));
            }
            else
            {
               
                ReadLoopRaw(null, null);
            }
        }

        /// <summary>
        /// 读取标签或停止读取
        /// </summary>
        private void ReadLoopRaw(object sender, EventArgs e)
        {
            try
            {
                AddToStatusAsync("");
                if ((string)ibScan.Tag == "Start")
                {
                    string err = "";
                    totalTimes = 0;
                    //totalTags = 0;
                    readMoment = Environment.TickCount;
                    try
                    {
                        QValue = Convert.ToUInt16(txtqvalue.Text.Trim());
                        //MessageBox.Show(QValue.ToString);
                    }
                    catch
                    {
                        AddToStatusAsync("Q Value Must Be Integer!");
                        return;
                    }
                    readSnd.Start();
                    ReadTag msg = msg = ReadTagBll.ConcreateReadTag((byte)TargetCodeArea, QValue);
                   
                    if (reader.Send(msg))
                    {
                       
                        if (!ReadTagBll.IsLoop) { readSnd.Stop(); return; }
                        IsRunning = true;
                        ibScan.Text = "Stop";
                        ibScan.Tag = "Stop";
                        AddToStatusAsync("Scanning Tag!");
                        this.timer1.Enabled = true;
                        
                    }
                    else
                    {
                        AddToStatusAsync("Scan Failure !");
                      
                    }
                }
                else
                {
                   
                    readSnd.Stop();
                    BaseMessage msgPoweroff = new PowerOff();
                    msgPoweroff.IsReturn = false;
                    bool ret = reader.Send(msgPoweroff);
                    if (ret)
                    {
                        
                        IsRunning = false;
                        ibScan.Text = "Scan";
                        ibScan.Tag = "Start";
                        this.timer1.Enabled = false;
                        AddToStatusAsync("Stop Scan Tag");
                        
                        Update();
                    }
                    else
                    {
                        
                        AddToStatusAsync(" Stop Failure");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
       

        private void AddToListAsync(TagView1 msg)
        {
            Invoke(new EventHandler(AddToList), msg);
        }

        /// <summary>
        /// Add To List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToList(object sender, EventArgs e)
        {
           
            totalTimes++;//总次数
           
            TagView1 msg = (TagView1)sender;
            bool exists = false;
            foreach (ListViewItem lvi in lvCodes.Items)
            {
             

                if (lvi == null)
                    continue;
                if (msg.Userdata != "")
                {
                    if (msg.Userdata == lvi.SubItems[3].Text)
                    {
                        exists = true;
                        int ic = Convert.ToInt32(lvi.SubItems[0].Text);
                        ic += 1;
                        lvi.SubItems[0].Text = ic.ToString();
                        MessageBox.Show(ic.ToString());
                        if (msg.RSSI != "")
                        {
                            lvi.SubItems[4].Text = msg.RSSI;
                        }
                        break;
                    }
                }
                else if (msg.Epc != "" && msg.ID == "")
                {
                    if (lvi.SubItems[2].Text == msg.Epc)
                    {
                        exists = true;
                        int ic = Convert.ToInt32(lvi.SubItems[0].Text);
                        ic += 1;
                        lvi.SubItems[0].Text = ic.ToString();
                        if (msg.RSSI != "")
                        {
                            lvi.SubItems[4].Text = msg.RSSI;
                        }
                        break;
                    }
                }
                else
                {
                    if (lvi.SubItems[1].Text == msg.ID)
                    {
                        exists = true;
                        int ic = Convert.ToInt32(lvi.SubItems[0].Text);
                        ic += 1;
                        lvi.SubItems[0].Text = ic.ToString();
                        break;
                    }
                }
            }

            if (!exists)
            {
                try
                {
                    string[] arrayCodigo = null;
                    string[] arrayResultado = null;
                    string codigo = null;
                    string nombre=null;
                    Dao.Dao dao = new Dao.Dao();
                   

                    arrayCodigo = msg.Epc.Split(' ');
                    codigo = arrayCodigo[2] + arrayCodigo[3][0] + arrayCodigo[3][1];
                    int lectura = (int)Int64.Parse(codigo, System.Globalization.NumberStyles.HexNumber);
                    

                    string res = dao.getPersonaByUHFComedor(lectura.ToString());
                    arrayResultado = res.Split(',');
                    nombre=arrayResultado[1];
                    ListViewItem lvi = new ListViewItem(new string[] { "1", msg.ID, nombre, msg.Epc, msg.Userdata, msg.RSSI.ToString() });
                    //strmsg = msg.Userdata
                    lvCodes.Items.Add(lvi);
                    lvCodes.EnsureVisible(lvCodes.Items.Count - 1);
                    readSnd.Set();

                    //lvCodes.Items.Add(nombre, 2);
                     //lvi = new ListViewItem(new string[] { "1", msg.ID,nombre, msg.Epc, msg.Userdata, msg.RSSI.ToString() });
                   
                    //lvCodes.Items.Add(lvi);
                    //lvCodes.EnsureVisible(lvCodes.Items.Count - 1);
                    //readSnd.Set();
                    stopSearching();
                  

                    FrInfo frInfo = new FrInfo(res);
                    frInfo.ShowDialog();

                    totalTags = 1;
                    totalTimes = 1;
                   
                }
                catch (Exception ex) {
                    MessageBox.Show("Lectura de tarjeta incorrecta!\n Tarjeta dañada o ajena al establecimiento");
                    stopSearching();
                }
               
        }
            totalTags = lvCodes.Items.Count;//
           
        }

        protected void AddToStatAsync()
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(AddToStat));
            }
            else
            {
                AddToStat(null, null);
            }
        }

        protected void AddToStat(object sender, EventArgs e)
        {
            int readSpan = (Environment.TickCount - readMoment) / 1000;
            int rate = 0;
            if (readSpan > 0)
            {
                rate = totalTimes / readSpan;
            }
            string strtmp = "Rate:{0}/s  tags:{1}";
            ////string str = string.Format(strtmp, rate, totalTimes, totalTags);
            string str = string.Format(strtmp, rate, totalTags);
            lblStat.Text = str;

            //if (IsSound)
            //{
            //    readSnd.Set();
            //}
        }

        private void btClear_Click_1(object sender, EventArgs e)
        {
            lvCodes.Items.Clear();
            totalTimes = 0;
            totalTags = 0;
        }



        protected void AddToStatusAsync(string msg)
        {
            if (InvokeRequired)
            {
               
                Invoke(new EventHandler(AddToStatus), msg);
            }
            else
            {
               
                AddToStatus(msg, null);
            }
        }

        protected void AddToStatus(object sender, EventArgs e)
        {
            string msg = (string)sender;
            lblStatus.Text = msg;
        }



        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            int keyval = e.KeyValue;
            //AddToStatusAsync(keyval.ToString("X2"));
            bool isrefresh = false;
            switch (keyval)
            {
                case 0xF1:
                    ReadLoop();
                    isrefresh = true;
                    break;
                case 0xF2:
                    break;
                case 0xF5:
                    PressTimes++;
                    if (PressTimes > 1) PressTimes = 2;
                    if (!IsRunning)
                    {
                        ReadLoop();
                        AddToStatAsync();
                        Invalidate();
                    }
                    else if (IsKeyUp)//ReadType != 0 && 
                    {
                        ReadLoop();
                        IsKeyUp = false;
                        Invalidate();
                    }

                    break;

            }
        }

        private void FrScanTag_Load(object sender, EventArgs e)
        {
            this.cbRfidType.SelectedIndex = 0;
            InitializeCombox(RfidType);

        }

        private void FrScanTag_Closed(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            IsKeyUp = !IsKeyUp;
            ReadLoop();
        }

        protected int GetTargetSeelectedIndex()
        {
            if (cbDataArea.SelectedItem == null)
                return -1;
            int idx = 0;
            ComboBindData obj = (ComboBindData)cbDataArea.SelectedItem;
            idx = Convert.ToInt32(obj.ValueMember);
            //MessageBox.Show("idx: " + idx);
            return 1;
        }

        protected void InitializeCombox(RFIDModule rfidType)
        {
            cbDataArea.DisplayMember = "DisplayMember";
            cbDataArea.ValueMember = "ValueMember";
            cbDataArea.Items.Clear();
            if (rfidType == RFIDModule.F6B)
            {
                cbDataArea.Items.Add(new ComboBindData("ID_6B", 4));
                cbDataArea.Items.Add(new ComboBindData("ID_UserData", 5));
            }

            else if (rfidType == RFIDModule.F6C_F6B)
            {
                cbDataArea.Items.Add(new ComboBindData("EPC_TID_UserData_Reserved_6C_ID_UserData_6B", 6));
            }
            else
            {
                cbDataArea.Items.Add(new ComboBindData("TID_6C", 0));
                cbDataArea.Items.Add(new ComboBindData("EPC_6C", 1));
                cbDataArea.Items.Add(new ComboBindData("EPC_TID_UserData", 2));
                cbDataArea.Items.Add(new ComboBindData("EPC_TID_UserData2", 3));
            }
            cbDataArea.SelectedIndex = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RfidType != (RFIDModule)cbRfidType.SelectedIndex)
            {
                RfidType = (RFIDModule)cbRfidType.SelectedIndex;

                InitializeCombox(RfidType);
            }
            //if (RfidType == RFIDModule.F6C_F6B)
            //{
            //    //this.btwritetag.Enabled = false;
            //}
            //else
            //{
            //    btwritetag.Enabled = true;
            //}
        }

        private void cbDataArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = GetTargetSeelectedIndex();
            if (idx > -1)
            {
                TargetCodeArea = idx;
            }
            if (idx == 1) lvCodes.Columns[1].Width = 0;
            else lvCodes.Columns[1].Width = 200;
            switch (idx)
            {

                case 3:
                case 5:
                case 6:
                    FrLengthParas form = new FrLengthParas(RfidType);
                    form.Owner = this;
                    form.Show();
                    break;
            }

        }


        private void cbsingle_CheckStateChanged(object sender, EventArgs e)
        {
            ReadTagBll.IsLoop = !cbsingle.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AddToStatAsync();

        }

        //private void btwritetag_Click(object sender, EventArgs e)
        //{
        //    FrWriteTag form = new FrWriteTag(RfidType, Tid);
        //    form.Owner = this;
        //    form.Show();
        //}

        private void lvCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //选中行的索引
                int index = lvCodes.SelectedIndices[0];
                //选中行的第一列的值
                this.Tid = lvCodes.Items[index].SubItems[1].Text;
            }
            catch { }
        }
        private bool IsKeyUp = false;
        private int PressTimes = 0;

        private void stopSearching()
        {

            readSnd.Stop();
            BaseMessage msgPoweroff = new PowerOff();
            msgPoweroff.IsReturn = false;
            bool ret = reader.Send(msgPoweroff);
            if (ret)
            {

                IsRunning = false;
                ibScan.Text = "Scan";
                ibScan.Tag = "Start";
                this.timer1.Enabled = false;
                AddToStatusAsync("Stop Scan Tag");

                Update();
            }else{
                
            }
        }
       
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            switch (e.KeyValue)
            {
                
                case 0xF5:
                    if (IsRunning)
                    {
                        if (PressTimes == 1)
                        {
                            IsKeyUp = true;
                        }
                        else
                        {
                            ReadLoop();
                            AddToStatAsync();
                            Invalidate();
                        }
                    }
                    PressTimes = 0;
                    break;
            }
        }

        private void label5_ParentChanged(object sender, EventArgs e)
        {

        }

        private void btwritetag_Click(object sender, EventArgs e)
        {

        }

        private void btwritetag_Click_1(object sender, EventArgs e)
        {
            FrWriteTag form = new FrWriteTag(RfidType, Tid);
            form.Owner = this;
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrMotoBarCode frm = new FrMotoBarCode(true);
            frm.ShowDialog();
        }

       

    }

    /// <summary>
    /// Tag View
    /// </summary>
    public class TagView1
    {
        public string ID;
        public string Epc;
        public string Userdata;
        public string RSSI;
        public TagView1(string id)
        {
            this.ID = id;
        }

        public TagView1(string id, string epc, string userdata, string rssi)
            : this(id)
        {
            this.Epc = epc;
            this.Userdata = userdata;
            this.RSSI = rssi;

        }
    }

}