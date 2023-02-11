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
            this.components = new System.ComponentModel.Container();
            this.tileNavPane1 = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.navButton2 = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnMainPage = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton3 = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton4 = new DevExpress.XtraBars.Navigation.NavButton();
            this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
            this.tileMainGroup = new DevExpress.XtraEditors.TileGroup();
            this.tileTables = new DevExpress.XtraEditors.TileControl();
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // tileNavPane1
            // 
            this.tileNavPane1.AllowGlyphSkinning = true;
            this.tileNavPane1.Buttons.Add(this.navButton2);
            this.tileNavPane1.Buttons.Add(this.btnMainPage);
            this.tileNavPane1.Buttons.Add(this.navButton3);
            this.tileNavPane1.Buttons.Add(this.navButton4);
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
            // navButton2
            // 
            this.navButton2.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.navButton2.Appearance.BackColor = System.Drawing.Color.White;
            this.navButton2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.navButton2.Appearance.Options.UseBackColor = true;
            this.navButton2.Appearance.Options.UseForeColor = true;
            this.navButton2.Caption = "navButton2";
            this.navButton2.Name = "navButton2";
            // 
            // btnMainPage
            // 
            this.btnMainPage.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnMainPage.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMainPage.Appearance.Options.UseFont = true;
            this.btnMainPage.AppearanceHovered.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMainPage.AppearanceHovered.Options.UseFont = true;
            this.btnMainPage.AppearanceSelected.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMainPage.AppearanceSelected.Options.UseFont = true;
            this.btnMainPage.Caption = "Ana Sayfa";
            this.btnMainPage.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnMainPage.ImageOptions.ImageUri.Uri = "business%20objects/bo_address";
            this.btnMainPage.Name = "btnMainPage";
            this.btnMainPage.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnMainPage_ElementClick);
            // 
            // navButton3
            // 
            this.navButton3.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.navButton3.Appearance.Options.UseFont = true;
            this.navButton3.AppearanceHovered.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.navButton3.AppearanceHovered.Options.UseFont = true;
            this.navButton3.AppearanceSelected.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.navButton3.AppearanceSelected.Options.UseFont = true;
            this.navButton3.Caption = "Paket Satış";
            this.navButton3.ImageOptions.ImageUri.Uri = "business%20objects/bo_price_item";
            this.navButton3.Name = "navButton3";
            // 
            // navButton4
            // 
            this.navButton4.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.navButton4.Appearance.Options.UseFont = true;
            this.navButton4.AppearanceHovered.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.navButton4.AppearanceHovered.Options.UseFont = true;
            this.navButton4.AppearanceSelected.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.navButton4.AppearanceSelected.Options.UseFont = true;
            this.navButton4.Caption = "Hızlı Satış";
            this.navButton4.ImageOptions.ImageUri.Uri = "business%20objects/bo_order";
            this.navButton4.Name = "navButton4";
            // 
            // tileMainGroup
            // 
            this.tileMainGroup.Name = "tileMainGroup";
            // 
            // tileTables
            // 
            this.tileTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileTables.Groups.Add(this.tileMainGroup);
            this.tileTables.ItemContentAnimation = DevExpress.XtraEditors.TileItemContentAnimationType.ScrollDown;
            this.tileTables.Location = new System.Drawing.Point(0, 0);
            this.tileTables.MaxId = 21;
            this.tileTables.Name = "tileTables";
            this.tileTables.Size = new System.Drawing.Size(1120, 642);
            this.tileTables.TabIndex = 4;
            this.tileTables.Text = "tileControl1";
            // 
            // mainTableControl
            // 
            this.Controls.Add(this.tileTables);
            this.Controls.Add(this.tileNavPane1);
            this.Name = "mainTableControl";
            this.Size = new System.Drawing.Size(1120, 705);
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane1;
        private DevExpress.XtraBars.Navigation.NavButton btnMainPage;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraBars.Navigation.NavButton navButton2;
        private DevExpress.XtraBars.Navigation.NavButton navButton3;
        private DevExpress.XtraBars.Navigation.NavButton navButton4;
        private DevExpress.XtraEditors.TileGroup tileMainGroup;
        private DevExpress.XtraEditors.TileControl tileTables;
    }
}
