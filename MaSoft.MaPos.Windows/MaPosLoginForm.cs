using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Serialization;
using DevExpress.XtraWaitForm;
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

            tmrDateTimeInfo = new Timer();
            tmrDateTimeInfo.Interval = 1000;
            tmrDateTimeInfo.Tick += new EventHandler(tmr_DateTimeInfo_Trick);
            tmrDateTimeInfo.Start();

            InitializeComponent();

            LoadDateTimeInfo();
            Application.DoEvents();

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

            //pboxCompanyLogo.Image = LocalHelper.ConvertSvgToBitmap_FromResource(Resources.mapos_svg, 307, 104);

            //pboxCompanyLogo.SvgImage = SvgImage.FromResources("mapos_svg", System.Reflection.Assembly.GetExecutingAssembly());
            //sSystem.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            //pboxCompanyLogo.SizeMode = SvgImageSizeMode.Stretch;

            //pboxCompanyLogo.SvgImage = LocalHelper.SvgFromByteArray(Properties.Resources.mapos_white_logo);

            nbtnInfo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(Resources.mapos_white_logo));
            nbtnInfo.ImageOptions.SvgImageSize = new Size(125, 33);
            nbtnInfo.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;

            nbtnMin.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler((sender, e) => { ((Form)this.Parent).WindowState = FormWindowState.Minimized; });
            nbtnClose.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler((sender, e) => { CloseApp(); });

            //itemTableOrder.ItemClick += new TileItemClickEventHandler((sender, e) => { ((Form)this.Parent.Controls.Add(ucTableOrder); });

            // Min..
            nbtnMin.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(Resources.minimize_svg));
            nbtnMin.ImageOptions.SvgImageSize = new Size(31, 31);
            nbtnMin.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;

            // Close..
            nbtnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(Resources.close_svg));
            nbtnClose.ImageOptions.SvgImageSize = new Size(28, 28);
            nbtnClose.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
        }

        void CloseApp()
        {
            DialogResult QuestionResult = MessageHelper.QuestionMsg("MaPos Adisyon", "Programı kapatmak istediğinize emin misiniz ?");
            if (QuestionResult == DialogResult.Yes)
                Application.Exit();
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

        void NumericButtonClick(object sender, EventArgs e)
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


        void LoadDateTimeInfo()
        {
            lblDateTimeInfo.Text = GetDateTimeInfo();
        }

        void tmr_DateTimeInfo_Trick(object sender, EventArgs e)
        {
            LoadDateTimeInfo();
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
            if (AppHelper.UserAuthentication(Password))
            {
                //MessageHelper.SuccessMsg("MaPos Giriş Ekranı", "Programa giriş yapıldı...");

                StaticVariables.UserAuthenticated = true;
                StaticVariables.UserPassword = Password;

                edtPassword.Text = "";
                Close();
            }
            else
            {
                MessageHelper.ErrorMsg("MaPos Giriş Ekranı", "Şifre yanlış veya hatalı !!");
                edtPassword.Text = "";
            }


            return true;
        }


    }
}
