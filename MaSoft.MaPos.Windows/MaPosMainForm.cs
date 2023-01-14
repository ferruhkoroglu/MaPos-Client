using DevExpress.XtraBars.Navigation;
using System;
using System.Drawing;
using System.Windows.Forms;
using MaSoft.MaPos.Windows.Properties;
using System.Xml;

namespace MaSoft.MaPos.Windows
{
    public partial class MaPosMainForm : DevExpress.XtraEditors.XtraForm
    {
        mainTileControl ucMain;

        NavigationFrame pnlMain;
        mainTableControl ucTable;

        NavigationPage pageMain;
        NavigationPage pageTable;

        public MaPosMainForm()
        {
            InitializeComponent();

            CreatePanels();
            InitMainObjects();
        }

        void CreatePanels()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

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
            pnlMain.TransitionType = DevExpress.Utils.Animation.Transitions.PushFade;

            pageMain = new NavigationPage();
            pnlMain.Pages.Add(pageMain);

            ucMain = new mainTileControl();
            ucMain.Dock = DockStyle.Fill;
            ucMain.Name = "mainTileControl";
            ucMain.Visible = true;
            pageMain.Controls.Add(ucMain);

            pageTable = new NavigationPage();
            pnlMain.Pages.Add(pageTable);

            ucTable = new mainTableControl();
            ucTable.Dock = DockStyle.Fill;
            ucTable.Name = "mainTableControl";
            ucTable.Visible = true;
            pageTable.Controls.Add(ucTable);

            pnlMain.SelectedPage = pageMain;

            /*
            tnavbarMain.AllowGlyphSkinning = true;
            tnavbarMain.LookAndFeel.UseDefaultLookAndFeel = false;
            tnavbarMain.LookAndFeel.SkinName = "Basic";
            */
        }

        public void ShowMainMenu()
        {
            pnlMain.SelectedPage = pageMain;
        }
        public void ShowTableOrder()
        {
            pnlMain.SelectedPage = pageTable;
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

        void CloseApp()
        {
            DialogResult QuestionResult = MessageHelper.QuestionMsg("MaPos Adisyon", "Programı kapatmak istediğinize emin misiniz ?");
            if (QuestionResult == DialogResult.Yes)
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
    }
}