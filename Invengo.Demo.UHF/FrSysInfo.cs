using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Invengo.Platform;

namespace Invengo.Sample
{
    public partial class FrSysInfo : Form
    {
        public bool IsDelayLoad = false;

        internal class ViewData
        {
            public string Name;
            public string Detail;
            public ViewData(string name, string detail)
            {
                this.Name = name;
                this.Detail = detail;
            }
        }

        /// <summary>
        /// Initialize
        /// </summary>
        public FrSysInfo()
        {
            InitializeComponent();
            GetAssemblyVersion();
            GetOSVersion();

        }

        protected override void OnLoad(EventArgs e)
        {
            IsDelayLoad = true;

            base.OnLoad(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

    
        /// <summary>
        /// Get Assembly Version
        /// </summary>
        private void GetAssemblyVersion()
        {
            AssemblyAttributes ass = new AssemblyAttributes();
            //ass.AssemblyTitle;
            AddToViewAsync(new ViewData("Software ver.", ass.AssemblyVersion));
       
        }

        /// <summary>
        /// Add To View
        /// </summary>
        /// <param name="data"></param>
        private void AddToViewAsync(ViewData data)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new EventHandler(AddToView), data);
            }
            else
            {
                AddToView(data, null);
            }
        }

        private void AddToView(object sender, EventArgs e)
        {
            ViewData data = (ViewData)sender;
            ListViewItem item = new ListViewItem(data.Name);
            item.SubItems.Add(data.Detail);
            lvInfo.Items.Add(item);
        }

        /// <summary>
        /// Get OS Version
        /// </summary>
        private void GetOSVersion()
        {
            string pid = "";
            if (Environment.OSVersion.Platform == PlatformID.WinCE)
                pid = "Windows CE ";
            else
                pid = Environment.OSVersion.Platform.ToString();

            OSInfo._OSVERSIONINFO obj = new OSInfo._OSVERSIONINFO();
            OSInfo.GetVersionEx(ref obj);
            pid += string.Format("{0}.{1}", obj.dwMajorVersion, obj.dwMinorVersion);

            string custVer = PDAInfo.OSInsideVersion;
            AddToViewAsync(new ViewData("Operating system ver.", pid));
            AddToViewAsync(new ViewData("Internal ver.", custVer));
        }
        private void FrSysInfo_Load(object sender, EventArgs e)
        {

        }
    }
}