using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.TextEditController.Win32;
using DevExpress.XtraSplashScreen;
using MaSoft.MaPos.Windows.Properties;
using Timer = System.Windows.Forms.Timer;

namespace MaSoft.MaPos.Windows {
    public partial class MaPosSplashForm : DemoSplashScreen {
        int dotCount = 0;

        private Timer tmr;
        private Timer tmrClose;

        public bool Loaded = false;
        internal Action _initMethod;

        public MaPosSplashForm(Action InitMethod) {
            InitializeComponent();

            labelControl1.Text = string.Format("{0} {1}", labelControl1.Text, GetYearString() );

            pictureEdit2.Size = new Size(435, 190);
            pictureEdit2.Image = LocalHelper.ConvertSvgToBitmap_FromResource(Resources.mapos_svg, 390, 75);

            tmr = new Timer();
            tmr.Interval = 200;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Start();

            tmrClose = new Timer();
            tmrClose.Interval = 2000;
            tmrClose.Tick += new EventHandler(tmr_Close_Tick);
            tmrClose.Start();

            // Splash esnasýnda çalýþmasýný istediðimiz method larý initialize etsin...
            _initMethod = InitMethod;
        }

        protected override void OnShown(EventArgs e)
        {
            // Açýlýrken thread start..
            Task.Run(() => { _initMethod.Invoke(); });

            base.OnShown(e);
        }

        void tmr_Tick(object sender, EventArgs e) {
            if(++dotCount > 3) dotCount = 0;
            labelControl2.Text = string.Format("{0}{1}", "Baþlatýlýyor", GetDots(dotCount));
        }

        string GetDots(int count) {
            string ret = string.Empty;
            for(int i = 0; i < count; i++) ret += ".";
            return ret;
        }

        int GetYearString() {
            int ret = DateTime.Now.Year;
            return ret;
        }
        void tmr_Close_Tick(object sender, EventArgs e)
        {
            tmr.Enabled = false;
            tmrClose.Enabled = false;

            Close();
        }

        private void MaPosSplashForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
