using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors.TextEditController.Win32;
using DevExpress.XtraSplashScreen;
using MaSoft.MaPos.Windows.Helper;
using Timer = System.Windows.Forms.Timer;

namespace MaSoft.MaPos.Windows {
    public partial class MaPosSplashForm : DemoSplashScreen {
        int dotCount = 0;

        private Timer tmr;
        private Timer tmrClose;

        public bool Loaded = false;

        public MaPosSplashForm(Action InitMethod) {
            InitializeComponent();

            labelControl1.Text = string.Format("{0} {1}", labelControl1.Text, GetYearString() );

            pictureEdit1.Size = new Size(168, 48);
            pictureEdit1.Image = global::MaSoft.MaPos.Windows.Properties.Resources.logo;

            pictureEdit2.Size = new Size(434, 187);
            pictureEdit2.Image = global::MaSoft.MaPos.Windows.Properties.Resources.SplashPicture;
            
            tmr = new Timer();
            tmr.Interval = 200;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Start();

            tmrClose = new Timer();
            tmrClose.Interval = 3500;
            tmrClose.Tick += new EventHandler(tmr_Close_Tick);
            tmrClose.Start();

            // Splash esnas�nda �al��mas�n� istedi�imiz method lar� initialize etsin...
            InitMethod.Invoke();
        }

        void tmr_Tick(object sender, EventArgs e) {
            if(++dotCount > 3) dotCount = 0;
            labelControl2.Text = string.Format("{0}{1}", "Ba�lat�l�yor", GetDots(dotCount));
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