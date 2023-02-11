using DevExpress.XtraBars.Navigation;
using System;
using System.Drawing;
using System.Windows.Forms;
using MaSoft.MaPos.Windows.Properties;
using System.Xml;
using Animation = DevExpress.Utils.Animation;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;

namespace MaSoft.MaPos.Windows
{
    public partial class MaPosMainForm : DevExpress.XtraEditors.XtraForm
    {
        Timer tmrDateTimeInfo;

        mainTileControl ucMain;

        NavigationFrame pnlMain;
        mainTableControl ucTable;
        mainLoginControl ucLogin;

        NavigationPage pageLogin;
        NavigationPage pageMain;
        NavigationPage pageTable;

        public MaPosMainForm()
        {
            tmrDateTimeInfo = new Timer();
            tmrDateTimeInfo.Interval = 1000;
            tmrDateTimeInfo.Tick += new EventHandler(tmr_DateTimeInfo_Trick);
            tmrDateTimeInfo.Start();

            InitializeComponent();

            LoadDateTimeInfo();
            Application.DoEvents();

            CreatePanels();
            InitMainObjects();
        }

        void CreatePanels()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            #region NavigationPanel
            pnlMain = new NavigationFrame();
            pnlMain.Dock = DockStyle.Bottom;
            pnlMain.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);
            pnlMain.Location = new System.Drawing.Point(0, 40);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new System.Drawing.Size(956, 553);
            pnlMain.TabIndex = 0;
            pnlMain.Text = "";
            Controls.Add(pnlMain);

            pnlMain.TransitionAnimationProperties.FrameCount = 350;
            pnlMain.TransitionAnimationProperties.FrameInterval = 3000;
            pnlMain.TransitionType = Animation.Transitions.PushFade;
            pnlMain.SelectedPageChanged += SelectedPageChangedEventHandler;
            #endregion

            #region Login
            pageLogin = new NavigationPage();
            pnlMain.Pages.Add(pageLogin);

            ucLogin = new mainLoginControl();
            ucLogin.Dock = DockStyle.Fill;
            ucLogin.Name = "mainLoginControl";
            ucLogin.Visible = true;
            pageLogin.Controls.Add(ucLogin);
            #endregion

            #region TileControl
            pageMain = new NavigationPage();
            pnlMain.Pages.Add(pageMain);

            ucMain = new mainTileControl();
            ucMain.Dock = DockStyle.Fill;
            ucMain.Name = "mainTileControl";
            ucMain.Visible = true;
            pageMain.Controls.Add(ucMain);
            #endregion

            #region Tables
            pageTable = new NavigationPage();
            pnlMain.Pages.Add(pageTable);

            ucTable = new mainTableControl();
            ucTable.Dock = DockStyle.Fill;
            ucTable.Name = "mainTableControl";
            ucTable.Visible = true;
            pageTable.Controls.Add(ucTable);
            #endregion Tables


            pnlMain.SelectedPage = pageLogin;

            /*
            tnavbarMain.AllowGlyphSkinning = true;
            tnavbarMain.LookAndFeel.UseDefaultLookAndFeel = false;
            tnavbarMain.LookAndFeel.SkinName = "Basic";
            */
        }

        public void SelectedPageChangedEventHandler(object sender, SelectedPageChangedEventArgs e)
        {
            if (e.Page == pageLogin)
            {
                if (((NavigationPage)e.Page).Controls.Count > 0)
                {
                    var ucLogin = (((NavigationPage)e.Page).Controls[0] as mainLoginControl);
                    var edtControl = ucLogin.Controls["edtPassword"];
                    if (edtControl != null)
                        edtControl.Focus();
                }
            }

            //...
        }

        public void ShowMainMenu()
        {
            pnlMain.SelectedPage = pageMain;
        }
        public void ShowTableOrder()
        {
            pnlMain.SelectedPage = pageTable;
        }
        public void ShowLogin()
        {
            pnlMain.SelectedPage = pageLogin;
        }

        void InitMainObjects()
        {
            nbtnInfo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(Resources.mapos_white_logo));
            nbtnInfo.ImageOptions.SvgImageSize = new Size(125, 33);
            nbtnInfo.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;

            nbtnMin.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler((sender, e) => { this.WindowState = FormWindowState.Minimized; });
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

        private bool canCloseFunc(DialogResult parameter)
        {
            return parameter != DialogResult.Cancel;
        }

        public void CloseApp(bool IsQuestion = true)
        {
            if (IsQuestion)
            {
                
                DialogResult QuestionResult = MessageHelper.QuestionMsg("MaPos Adisyon", "Programı kapatmak istediğinize emin misiniz ?");
                if (QuestionResult == DialogResult.Yes)
                    Application.Exit();
                

                /*
                FlyoutAction action = new FlyoutAction() { Caption = "MaPos Adisyon", Description = "Programı kapatmak istediğinizden emin misiniz ?" };
                Predicate<DialogResult> predicate = canCloseFunc;
                
                FlyoutCommand cmdYes = new FlyoutCommand() { Text = "Evet", Result = System.Windows.Forms.DialogResult.Yes };
                FlyoutCommand cmdNo = new FlyoutCommand() { Text = "Hayır", Result = System.Windows.Forms.DialogResult.No };
                
                action.Commands.Add(cmdYes);
                action.Commands.Add(cmdNo);

                FlyoutProperties properties = new FlyoutProperties();
                properties.ButtonSize = new Size(100, 40);
                properties.Style = FlyoutStyle.MessageBox;
                properties.AllowHtmlDraw = true;
                properties.Appearance.BackColor = SystemColors.Highlight;

                if (FlyoutDialog.Show(this, action, properties, predicate) == System.Windows.Forms.DialogResult.Yes)
                    Application.Exit();
                */
                
            }
            else
                Application.Exit();
        }


        private void navButton2_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            pnlMain.SelectedPage = pageTable;
        }

        private void navButton3_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            pnlMain.SelectedPage = pageMain;
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

    }
}