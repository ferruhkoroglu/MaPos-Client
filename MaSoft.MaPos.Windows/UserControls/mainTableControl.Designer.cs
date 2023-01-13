namespace MaSoft.MaPos.Windows {
    partial class mainTableControl  {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainTableControl));
            this.tileNavPane1 = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btnMainPage = new DevExpress.XtraBars.Navigation.NavButton();
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).BeginInit();
            this.SuspendLayout();
            // 
            // tileNavPane1
            // 
            this.tileNavPane1.Buttons.Add(this.btnMainPage);
            // 
            // tileNavCategory1
            // 
            this.tileNavPane1.DefaultCategory.Name = "tileNavCategory1";
            // 
            // 
            // 
            this.tileNavPane1.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileNavPane1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tileNavPane1.Location = new System.Drawing.Point(0, 642);
            this.tileNavPane1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tileNavPane1.Name = "tileNavPane1";
            this.tileNavPane1.Size = new System.Drawing.Size(1120, 63);
            this.tileNavPane1.TabIndex = 3;
            // 
            // btnMainPage
            // 
            this.btnMainPage.Caption = "Ana Sayfa";
            this.btnMainPage.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnMainPage.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMainPage.ImageOptions.SvgImage")));
            this.btnMainPage.Name = "btnMainPage";
            this.btnMainPage.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnMainPage_ElementClick);
            // 
            // mainTableControl
            // 
            this.Controls.Add(this.tileNavPane1);
            this.Name = "mainTableControl";
            this.Size = new System.Drawing.Size(1120, 705);
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane1;
        private DevExpress.XtraBars.Navigation.NavButton btnMainPage;
    }
}
