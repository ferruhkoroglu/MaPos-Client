using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.TextEditController.Win32;
using DevExpress.Printing.Core.PdfExport.Metafile;
using MaSoft.MaPos.Core;
using MaSoft.MaPos.Windows.Properties;

namespace MaSoft.MaPos.Windows
{
    public partial class frmLogin : XtraForm
    {
        private Timer tmrDateTimeInfo;

        public frmLogin()
        {
            // Full Screen And Non Border...
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = System.Windows.Forms.FormWindowState.Maximized;

            GetDateTimeInfo();
            Application.DoEvents();

            tmrDateTimeInfo = new Timer();
            tmrDateTimeInfo.Interval = 1000;
            tmrDateTimeInfo.Tick += new EventHandler(tmr_DateTimeInfo_Trick);
            tmrDateTimeInfo.Start();

            InitializeComponent();

            LoadComputerAndUserName();
            CloseButtonTabStop();
            InitButton();

            //KeyDown += new KeyEventHandler(KeyDownProc);
            edtPassword.KeyDown += new KeyEventHandler(KeyDownProc);

            /*
            pictureEdit1.Image = Resources.background_transparent;
            pictureEdit1.TabStop = false;
            pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            pictureEdit1.Properties.Appearance.Options.UseBackColor = false;
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            */

            pboxLogo.BackColor = Color.Transparent;
            pboxLogo.Image = Resources.background_transparent;
            pboxLogo.Size = new Size(640, 640);
            pboxLogo.Location = new Point((Width / 2) - 100,182);

        }

        void LoadComputerAndUserName()
        {
            lblComputerName.Text = "Bilgisayar Adı: " + System.Environment.MachineName;
            lblUserName.Text = "Kullanıcı: " + System.Environment.UserName;
        }


        void CloseButtonTabStop()
        {
            foreach (Object item in this.Controls)
            {
                if (item is SimpleButton)
                    (item as SimpleButton).TabStop = false;
            }
        }


        void InitButton()
        {
            btn0.Tag = 0;
            btn0.Click += new EventHandler(NumericButtonClick);

            btn1.Tag = 1;
            btn1.Click += new EventHandler(NumericButtonClick);

            btn2.Tag = 2;
            btn2.Click += new EventHandler(NumericButtonClick);

            btn3.Tag = 3;
            btn3.Click += new EventHandler(NumericButtonClick);

            btn4.Tag = 4;
            btn4.Click += new EventHandler(NumericButtonClick);

            btn5.Tag = 5;
            btn5.Click += new EventHandler(NumericButtonClick);

            btn6.Tag = 6;
            btn6.Click += new EventHandler(NumericButtonClick);

            btn7.Tag = 7;
            btn7.Click += new EventHandler(NumericButtonClick);

            btn8.Tag = 8;
            btn8.Click += new EventHandler(NumericButtonClick);

            btn9.Tag = 9;
            btn9.Click += new EventHandler(NumericButtonClick);

            btnBackSpace.Click += new EventHandler(NumericButtonClick);
            btnEnter.Click += new EventHandler(NumericButtonClick);
        }

        void NumericButtonClick(object? sender, EventArgs e)
        {
            SimpleButton senderButton = (sender as SimpleButton);
            if (senderButton.Name == btnBackSpace.Name)
            {
                edtPassword.Text = "";
                edtPassword.Focus();

                return;
            }

            if (senderButton.Name == btnEnter.Name)
            {
                Authentication(edtPassword.Text);
                edtPassword.Text = "";
                edtPassword.Focus();

                return;
            }

            edtPassword.Text += (sender as SimpleButton).Tag.ToString();
            edtPassword.Focus();
        }

        string GetDateTimeInfo()
        {
            return DateTime.Now.ToString() + " " + DateTime.Now.ToString("dddd");
        }

        void tmr_DateTimeInfo_Trick(object sender, EventArgs e)
        {
            lblDateTimeInfo.Text = GetDateTimeInfo();
            Application.DoEvents();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
        }

        void KeyDownProc(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { Close(); return; }
            if (e.KeyCode == Keys.Enter) { Authentication(edtPassword.Text); return; }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            edtPassword.Text += (sender as SimpleButton).Tag;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool Authentication(string Password)
        {
            // Authentication Kontrolü ??

            MessageHelper.SuccessMsg("MaPos Giriş Ekranı", "Programa giriş yapıldı...");
            edtPassword.Text = "";

            return true;
        }
    }
}
