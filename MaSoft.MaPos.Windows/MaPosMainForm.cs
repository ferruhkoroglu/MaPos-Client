using DevExpress.XtraCharts.Designer.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using MaSoft.MaPos.Windows.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaSoft.MaPos.Windows
{
    public partial class MaPosMainForm : DevExpress.XtraEditors.XtraForm
    {
        mainTileControl tblControl;
        
        PanelControl pnlMain;
        mainTableControl tblControl2;

        public MaPosMainForm()
        {
            InitializeComponent();

            CreatePanels();
            InitObjects();
        }

        void CreatePanels()
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = System.Windows.Forms.FormWindowState.Maximized;

            //pnlMain = new SidePanel();
            pnlMain = new PanelControl();
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new System.Drawing.Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new System.Drawing.Size(956, 553);
            pnlMain.TabIndex = 0;
            pnlMain.Text = "";
            Controls.Add(pnlMain);

            tblControl = new mainTileControl();
            tblControl.Dock = DockStyle.Fill;
            tblControl.Name = "mainTileControl";
            tblControl.Visible = true;
            pnlMain.Controls.Add(tblControl);

            tblControl2 = new mainTableControl();
            tblControl2.Dock = DockStyle.Fill;
            tblControl2.Name = "mainTableControl";
            tblControl2.Visible = false;
            pnlMain.Controls.Add(tblControl2);
        }

        void InitObjects()
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
            using (BatchTransition TempBatchTransition = new BatchTransition(transitionManager1, pnlMain))
            {
                tblControl2.Visible = true;
                tblControl.Visible = false;
            }
        }

        private void navButton3_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            using (BatchTransition TempBatchTransition = new BatchTransition(transitionManager1, pnlMain))
            {
                tblControl.Visible = true;
                tblControl2.Visible = false;
            }
        }
    }
}