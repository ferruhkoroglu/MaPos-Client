using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;

using MaSoft.MaPos.Core;
using MaSoft.MaPos.Windows.Properties;
using DevExpress.XtraBars.Navigation;
using DevExpress.Xpo;
using MaSoft.MaPos.Models.MaPos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using DevExpress.Mvvm.Native;
using DevExpress.Utils;
using DevExpress.Office.Utils;

namespace MaSoft.MaPos.Windows {
    public partial class mainTableControl : MaPosUserControl
    {
        Dictionary<int, NavButton> tableGroups;

        public mainTableControl() {
            InitializeComponent();
            tableGroups = new Dictionary<int, NavButton>();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            //SetBackground();
            InitEvents();

            tileNavPane1.LookAndFeel.UseDefaultLookAndFeel = false;
            tileNavPane1.LookAndFeel.SkinName = "Basic";

            tileTables.StartItemDragging += TileItemDragEventHandler;

            LoadTableGroups();
        }

        void LoadTableGroups()
        {
            // Tüm Butonlar siliniyor...
            tileNavPane1.Buttons.Clear();
            tableGroups.Clear();

            // Sonrasında tüm salon butonları dinamik olarak ekleniyor..
            List<TableGroups> tableGroupList = XpoDefault.Session.Query<TableGroups>().ToList();
            NavButton navButton;
            int loop = 0;
            string pictureUrl = "";

            foreach (var item in tableGroupList)
            {
                navButton = new NavButton();
                loop++;

                navButton.Appearance.Font = new Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                navButton.AppearanceHovered.Font = new Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                navButton.AppearanceSelected.Font = new Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);

                navButton.Appearance.Options.UseFont = true;
                navButton.AppearanceHovered.Options.UseFont = true;
                navButton.AppearanceSelected.Options.UseFont = true;

                navButton.Alignment = NavButtonAlignment.Left;
                navButton.ImageOptions.AllowGlyphSkinning = DefaultBoolean.True;

                navButton.Caption = item.GroupName;
                navButton.Padding = new Padding(35, 10, 35, 10);

                if ((loop % 2) == 0) { pictureUrl = "dashboards/totals"; } else { pictureUrl = "richedit/selecttablerow"; };

                navButton.ImageOptions.ImageUri.Uri = pictureUrl;
                navButton.Name = navButton.Caption;

                // Table Group ID;
                navButton.Tag = item.ID;

                navButton.ElementClick += new NavElementClickEventHandler(TableGroupClick);

                tileNavPane1.Buttons.Add(navButton);

                // listeye bilerek ekleniyor ki, sonrasında direk o nesneye ulaşabilelim...
                tableGroups.Add(item.ID, navButton);

                //tableGroups.Add(navButton);
            }

            // Varsayılan da ilk masa grubu load ediliyor...
            if (tableGroupList.Count > 0)
                LoadTables(tableGroupList[0].ID);

            // Ana Sayfa butonu önce ekleniyor...
            btnMainPage = new NavButton();
            btnMainPage.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnMainPage.AppearanceHovered.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnMainPage.AppearanceSelected.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);

            btnMainPage.Appearance.Options.UseFont = true;
            btnMainPage.AppearanceHovered.Options.UseFont = true;
            btnMainPage.AppearanceSelected.Options.UseFont = true;

            btnMainPage.Alignment = NavButtonAlignment.Right;

            btnMainPage.Caption = "Ana Menü";
            btnMainPage.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnMainPage.ImageOptions.ImageUri.Uri = "business%20objects/bo_address";
            btnMainPage.Name = "btnMainPage";
            btnMainPage.ElementClick += new NavElementClickEventHandler(this.btnMainPage_ElementClick);

            tileNavPane1.Buttons.Add(btnMainPage);

            navButton3 = new NavButton();
            navButton3.Alignment = NavButtonAlignment.Right;
            navButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            navButton3.Appearance.Options.UseFont = true;
            navButton3.AppearanceHovered.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            navButton3.AppearanceHovered.Options.UseFont = true;
            navButton3.AppearanceSelected.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            navButton3.AppearanceSelected.Options.UseFont = true;
            navButton3.Caption = "Paket Satış";
            navButton3.ImageOptions.ImageUri.Uri = "business%20objects/bo_price_item";
            navButton3.Name = "btnPackageOrder";

            tileNavPane1.Buttons.Add(navButton3);

            navButton4 = new NavButton();
            navButton4.Alignment = NavButtonAlignment.Right;
            navButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            navButton4.Appearance.Options.UseFont = true;
            navButton4.AppearanceHovered.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            navButton4.AppearanceHovered.Options.UseFont = true;
            navButton4.AppearanceSelected.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            navButton4.AppearanceSelected.Options.UseFont = true;
            navButton4.Caption = "POS <Hızlı Satış>";
            navButton4.ImageOptions.ImageUri.Uri = "business%20objects/bo_order";
            navButton4.Name = "btnFastOrder";

            tileNavPane1.Buttons.Add(navButton4);
        }

        void LoadTables(int TableID = 0)
        {
            // Gruptaki mevcut nesneler öncelikler silinir...
            tileMainGroup.Items.Clear();

            tileTables.LayoutMode = TileControlLayoutMode.Standard;

            // Tüm Kategoriler normale döndürülüyor...
            foreach (var tblGroup in tableGroups)
            {
                (tblGroup.Value as NavButton).Appearance.BackColor = Color.Transparent;
                (tblGroup.Value as NavButton).Appearance.ForeColor = Color.Transparent;
            }

            //...
            if (tableGroups[TableID] != null)
            {
                tableGroups[TableID].Appearance.BackColor = Color.White;
                tableGroups[TableID].Appearance.ForeColor = Color.Black;
            }


            var tableList = XpoDefault.Session.Query<Tables>().Where(s => s.TableGroupID == TableID).ToList();
            //XtraMessageBox.Show(tableList.Count.ToString());

            int loop = 0;
            foreach (var item in tableList)
            {
                loop++;

                /*
                TileItem tileItem = new TileItem();

                TileItemElement tileItemElement = new DevExpress.XtraEditors.TileItemElement();
                tileItem.Text = item.TableName;

                tileItem.AppearanceItem.Normal.Font = new Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                tileItem.AppearanceItem.Hovered.Font = new Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                tileItem.AppearanceItem.Selected.Font = new Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                tileItem.AppearanceItem.Pressed.Font = new Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);

                tileItem.Elements.Add(tileItemElement);

                tileItem.Id = loop;
                tileItem.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
                tileItem.Name = "tileItem" + Convert.ToString(loop);

                tileMainGroup.Items.Add(tileItem);
                */

                TileItem tileItem = new TileItem();

                tileItem.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(14,134,153);
                tileItem.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                tileItem.AppearanceItem.Normal.Options.UseBackColor = true;
                tileItem.AppearanceItem.Normal.Options.UseFont = true;

                TileItemElement tileItemElement = new TileItemElement();

                tileItemElement.Appearance.Normal.Font = new Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                tileItemElement.Appearance.Normal.Options.UseFont = true;
                tileItemElement.TextLocation = new Point(2, 2);

                tileItemElement.ImageOptions.Image = Properties.Resources.masa_satis;
                tileItemElement.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleRight;
                tileItemElement.ImageOptions.ImageLocation = new Point(-5, -10);
                tileItemElement.ImageOptions.ImageScaleMode = TileItemImageScaleMode.NoScale;
                tileItemElement.ImageOptions.ImageSize = new Size(248, 120);
                
                tileItemElement.Text = item.TableName;
                //tileItemElement.TextAlignment = TileItemContentAlignment.BottomLeft;

                tileItem.Elements.Add(tileItemElement);
                tileItem.Id = loop;
                tileItem.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
                tileItem.Name = "itemTableOrder";
                tileItem.TextShowMode = TileItemContentShowMode.Always;

                //itemTableOrder.ItemClick += new TileItemClickEventHandler(null);

                tileMainGroup.Items.Add(tileItem);
            }

        }

        protected void TableGroupClick(object sender, NavElementEventArgs e)
        {
            // Table ID pass Parameter...
            LoadTables(Convert.ToInt32((sender as NavButton).Tag));
        }

        public void TileItemDragEventHandler(object sender, TileItemDragEventArgs e)
        {
            e.Cancel = true;
        }

        public void InitEvents()
        {
            // Runtime Customization kapatılıyor...
            //lytcntrlMain.AllowCustomization = false;
        }

        private void btnMainPage_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            ShowMainMenu();
        }


    }
}
