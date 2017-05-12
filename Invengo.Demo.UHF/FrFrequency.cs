using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;

namespace Invengo.Demo.UHF
{
    public partial class FrFrequency : Form
    {
        private List<byte> readerFreqPointList = new List<byte>();
        private List<ComboBindData> freqListLB = new List<ComboBindData>();
        private string curFreqBand = "CN";
        private string RfidType = "F6C";
        protected XmlDocument XmlDoc = new XmlDocument();
        string _xmlFile;

        public FrFrequency()
        {
            InitializeComponent();
            RfidConfig.RfidConnecte();
           
        }

        /// <summary>
        /// Select Attributes
        /// </summary>
        /// <param name="XmlPathNode"></param>
        /// <param name="Attrib"></param>
        /// <returns></returns>
        public string SelectAttrib(string XmlPathNode, string Attrib)
        {
            string _strNode = "";
            try
            {
                _strNode = XmlDoc.SelectSingleNode(XmlPathNode).Attributes[Attrib].Value;
            }
            catch
            { }
            return _strNode;
        }

        /// <summary>
        /// Initialize Frequecy List
        /// </summary>
        private void InitializeFrequecyList()
        {
            this.freqListLB.Clear();

            //frequency point
            double freqDisplay = 920.625;
            double freqDisplayStep = 0.25;
            int freqValue = 0;
            int freqValueStep = 1;
            int freqMax = 16;

            try
            {
                string ExeFolder = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                _xmlFile = ExeFolder + @"\F6C.config";
                XmlDoc.Load(_xmlFile);
                XmlNodeList freqNodeList = XmlDoc.SelectNodes("//configuration/rfFrequency/freqType");
                foreach (XmlNode node in freqNodeList)
                {
                    if (node.Attributes["name"].Value != curFreqBand)
                        continue;
                    freqDisplay = Convert.ToDouble(node.Attributes["displayMember"].Value);
                    freqDisplayStep = Convert.ToDouble(node.Attributes["displayStep"].Value);
                    freqValue = Convert.ToInt32(node.Attributes["valueMember"].Value);
                    freqValueStep = Convert.ToInt32(node.Attributes["valueStep"].Value);
                    freqMax = Convert.ToInt32(node.Attributes["max"].Value);
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            for (int i = 0; i < freqMax; i++)
            {
                double tmpFreqDisplay = freqDisplay + freqDisplayStep * (double)i;
                freqListLB.Add(new ComboBindData(tmpFreqDisplay.ToString("F3"), freqValue + freqValueStep * i));
            }

            this.lbfrequency.DisplayMember = "DisplayMember";
            this.lbfrequency.ValueMember = "ValueMember";
            this.lbfrequency.BeginUpdate();
            this.lbfrequency.Items.Clear();
            foreach (ComboBindData b in freqListLB)
            {
                this.lbfrequency.Items.Add(b);
            }
            this.lbfrequency.EndUpdate();

            this.lbfrequency.DisplayMember = "DisplayMember";
            this.lbfrequency.ValueMember = "ValueMember";
        }

        /// <summary>
        /// Get Frequency Band
        /// </summary>
        /// <returns></returns>
        private bool GetFrequencyBand()
        {
            if (RfidType == "F6C")
            {
                string errInfo;
                if (RfidConfig.GetFrequencyBand(out curFreqBand, out errInfo))
                {
                }
                else
                {
                    string strtmp = "Get Frequency Band Failed," + errInfo;
                    MessageBox.Show(string.Format(strtmp, errInfo));
                    this.Close();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Frequency Query Display
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string FrequencyQueryDisplay(int val)
        {
            string result = val.ToString();
            try
            {
                ComboBindData bindA = freqListLB[0];
                ComboBindData bindB = freqListLB[1];
                int aVal = Convert.ToInt32(bindA.ValueMember);
                double aShow = Convert.ToDouble(bindA.DisplayMember);
                int bVal = Convert.ToInt32(bindB.ValueMember);
                double bShow = Convert.ToDouble(bindB.DisplayMember);
                int stepVal = bVal - aVal;
                double stepShow = bShow - aShow;

                double curFreq = aShow + (val - aVal) * stepShow;
                result = curFreq.ToString("F3");
            }
            catch { }
            return result;
        }

        /// <summary>
        /// Query Frequency
        /// </summary>
        private void QueryFrequency()
        {

            byte[] freq = null;
            string errInfo = "";
            this.lbdisplay.BeginUpdate();
            lbdisplay.Items.Clear();
            this.lbdisplay.DisplayMember = "DisplayMember";
            this.lbdisplay.ValueMember = "ValueMember";
            if (RfidConfig.GetFrequency(out freq, out errInfo))
            {
                foreach (byte b in freq)
                {
                    string valshow = FrequencyQueryDisplay(b);
                   
                    lbdisplay.Items.Add(new ComboBindData(valshow, b));
                   
                   
                }
                AddToStatusAsync("Search SuccessFully!");
                FormatConvert.SoundSucceed();
            }
            else
            {
                AddToStatusAsync("Search Failed," + errInfo);
                FormatConvert.SoundError();
            }
           
            this.lbdisplay.EndUpdate();

        }

        /// <summary>
        /// Set Frequency
        /// </summary>
        private void SetFrequency()
        {
            string errInfo = "";
            if (lbdisplay.Items.Count < 1)
            {
                AddToStatusAsync("No frequency.");
                return;
            }
            List<byte> freqList = new List<byte>();
            foreach (object b in lbdisplay.Items)
            {
                ComboBindData cbd = (ComboBindData)b;
                freqList.Add(Convert.ToByte(cbd.ValueMember));
            }
            if (freqList.Count > 0)
            {
                if (RfidConfig.SetFrequency(freqList.ToArray(), out errInfo))
                {
                    AddToStatusAsync("Set frequency completed.");
                   FormatConvert.SoundSucceed();
                    Close();
                    return;
                }
                else
                {
                    AddToStatusAsync("Set Failed," + errInfo);
                    FormatConvert.SoundError();
                }
            }
            else
            {
                AddToStatusAsync("No frequency.");
            }
        }

        /// <summary>
        /// Add Point
        /// </summary>
        private void UiAddPoint()
        {
            if (lbfrequency.SelectedIndex < 0)
                return;
            if (lbdisplay.Items.Count < 16)
            {
                object selB = lbfrequency.SelectedItem;
                lbdisplay.Items.Add(selB);
            }
            else
            {
                AddToStatusAsync("Can not add more!");
            }
        }

        /// <summary>
        /// Move Point
        /// </summary>
        private void UiMovePoint()
        {
            if (lbdisplay.SelectedIndex < 0)
                return;
            ComboBindData selB = (ComboBindData)lbdisplay.SelectedItem;
            if (selB != null)
            {
                lbdisplay.Items.Remove(selB);
            }
        }

        /// <summary>
        /// Add All Point
        /// </summary>
        private void UiAddAllPoint()
        {
            lbdisplay.BeginUpdate();
            lbdisplay.Items.Clear();
            foreach (object b in lbfrequency.Items)
            {
                lbdisplay.Items.Add(b);
            }
            lbdisplay.EndUpdate();
        }

        private void UiMoveAllPoint()
        {
            lbdisplay.Items.Clear();
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

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyValue)
            {
                case 0xF1:
                case 0xF2:
                case 0xF5:
                    QueryFrequency();
                    break;
            }
        }
        protected void AddToStatus(object sender, EventArgs e)
        {
            string msg = (string)sender;
            lblStatus.Text = msg;
        }
        private void FrFrequency_Load(object sender, EventArgs e)
        {
            if (GetFrequencyBand())
            {
                InitializeFrequecyList();
                QueryFrequency();
            }
        }

        private void btsearch_Click(object sender, EventArgs e)
        {
            QueryFrequency();
        }

        private void btleft_Click(object sender, EventArgs e)
        {
            UiAddPoint();
        }

        private void btright_Click(object sender, EventArgs e)
        {
            UiMovePoint();
        }

        private void btallleft_Click(object sender, EventArgs e)
        {
            UiAddAllPoint();
        }

        private void btallrigth_Click(object sender, EventArgs e)
        {
            UiMoveAllPoint();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetFrequency();
        }

        private void FrFrequency_Closed(object sender, EventArgs e)
        {
            RfidConfig.Disconnect();
        }
    }


}