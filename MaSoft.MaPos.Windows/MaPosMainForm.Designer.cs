namespace MaSoft.MaPos.Windows
{
    partial class MaPosMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaPosMainForm));
            this.lcntrlMain = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tnavbarMain = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.nbtnInfo = new DevExpress.XtraBars.Navigation.NavButton();
            this.nbtnMin = new DevExpress.XtraBars.Navigation.NavButton();
            this.nbtnClose = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton2 = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton3 = new DevExpress.XtraBars.Navigation.NavButton();
            this.transitionManager1 = new DevExpress.Utils.Animation.TransitionManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lcntrlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tnavbarMain)).BeginInit();
            this.SuspendLayout();
            // 
            // lcntrlMain
            // 
            this.lcntrlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcntrlMain.Location = new System.Drawing.Point(1, 1);
            this.lcntrlMain.Name = "lcntrlMain";
            this.lcntrlMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1165, 208, 650, 400);
            this.lcntrlMain.Root = this.Root;
            this.lcntrlMain.Size = new System.Drawing.Size(954, 551);
            this.lcntrlMain.TabIndex = 0;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(954, 551);
            this.Root.TextVisible = false;
            // 
            // tnavbarMain
            // 
            this.tnavbarMain.Buttons.Add(this.nbtnInfo);
            this.tnavbarMain.Buttons.Add(this.nbtnMin);
            this.tnavbarMain.Buttons.Add(this.nbtnClose);
            this.tnavbarMain.Buttons.Add(this.navButton2);
            this.tnavbarMain.Buttons.Add(this.navButton3);
            // 
            // tileNavCategory1
            // 
            this.tnavbarMain.DefaultCategory.Name = "tileNavCategory1";
            // 
            // 
            // 
            this.tnavbarMain.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tnavbarMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tnavbarMain.Location = new System.Drawing.Point(0, 0);
            this.tnavbarMain.Name = "tnavbarMain";
            this.tnavbarMain.Size = new System.Drawing.Size(956, 40);
            this.tnavbarMain.TabIndex = 6;
            this.tnavbarMain.Text = "tileNavPane1";
            // 
            // nbtnInfo
            // 
            this.nbtnInfo.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.nbtnInfo.Caption = null;
            this.nbtnInfo.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.nbtnInfo.ImageOptions.SvgImageSize = new System.Drawing.Size(125, 30);
            this.nbtnInfo.Name = "nbtnInfo";
            // 
            // nbtnMin
            // 
            this.nbtnMin.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.nbtnMin.Caption = null;
            this.nbtnMin.Name = "nbtnMin";
            // 
            // nbtnClose
            // 
            this.nbtnClose.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.nbtnClose.Caption = null;
            this.nbtnClose.Name = "nbtnClose";
            // 
            // navButton2
            // 
            this.navButton2.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButton2.Caption = "navButton2";
            this.navButton2.Name = "navButton2";
            this.navButton2.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.navButton2_ElementClick);
            // 
            // navButton3
            // 
            this.navButton3.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButton3.Caption = "navButton3";
            this.navButton3.Name = "navButton3";
            this.navButton3.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.navButton3_ElementClick);
            // 
            // transitionManager1
            // 
            this.transitionManager1.ShowWaitingIndicator = false;
            // 
            // MaPosMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 553);
            this.Controls.Add(this.tnavbarMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("MaPosMainForm.IconOptions.LargeImage")));
            this.IconOptions.ShowIcon = false;
            this.Name = "MaPosMainForm";
            this.Text = "MaPos Adisyon Çözümleri";
            ((System.ComponentModel.ISupportInitialize)(this.lcntrlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tnavbarMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl lcntrlMain;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraBars.Navigation.TileNavPane tnavbarMain;
        private DevExpress.XtraBars.Navigation.NavButton nbtnInfo;
        private DevExpress.XtraBars.Navigation.NavButton nbtnMin;
        private DevExpress.XtraBars.Navigation.NavButton nbtnClose;
        private DevExpress.XtraBars.Navigation.NavButton navButton2;
        private DevExpress.XtraBars.Navigation.NavButton navButton3;
        private DevExpress.Utils.Animation.TransitionManager transitionManager1;
    }
}