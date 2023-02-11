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
            this.transitionManager1 = new DevExpress.Utils.Animation.TransitionManager(this.components);
            this.lblDateTimeInfo = new DevExpress.XtraEditors.LabelControl();
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
            this.tnavbarMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tnavbarMain.Buttons.Add(this.nbtnInfo);
            this.tnavbarMain.Buttons.Add(this.nbtnMin);
            this.tnavbarMain.Buttons.Add(this.nbtnClose);
            // 
            // tileNavCategory1
            // 
            this.tnavbarMain.DefaultCategory.Name = "tileNavCategory1";
            // 
            // 
            // 
            this.tnavbarMain.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
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
            // transitionManager1
            // 
            this.transitionManager1.ShowWaitingIndicator = false;
            // 
            // lblDateTimeInfo
            // 
            this.lblDateTimeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateTimeInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDateTimeInfo.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblDateTimeInfo.Appearance.Options.UseFont = true;
            this.lblDateTimeInfo.Appearance.Options.UseForeColor = true;
            this.lblDateTimeInfo.Location = new System.Drawing.Point(556, 12);
            this.lblDateTimeInfo.Name = "lblDateTimeInfo";
            this.lblDateTimeInfo.Size = new System.Drawing.Size(90, 19);
            this.lblDateTimeInfo.TabIndex = 18;
            this.lblDateTimeInfo.Text = "01.01.2023";
            // 
            // MaPosMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 599);
            this.Controls.Add(this.lblDateTimeInfo);
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
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl lcntrlMain;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraBars.Navigation.TileNavPane tnavbarMain;
        private DevExpress.XtraBars.Navigation.NavButton nbtnInfo;
        private DevExpress.XtraBars.Navigation.NavButton nbtnMin;
        private DevExpress.XtraBars.Navigation.NavButton nbtnClose;
        private DevExpress.Utils.Animation.TransitionManager transitionManager1;
        private DevExpress.XtraEditors.LabelControl lblDateTimeInfo;
    }
}