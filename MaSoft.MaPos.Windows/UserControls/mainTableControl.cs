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


namespace MaSoft.MaPos.Windows {
    public partial class mainTableControl: MaPosUserControl
    {
        public mainTableControl() {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            //SetBackground();
            InitEvents();

            tileNavPane1.LookAndFeel.UseDefaultLookAndFeel = false;
            tileNavPane1.LookAndFeel.SkinName = "Basic";

            //tileControl1.StartItemDragging += TileItemDragEventHandler;
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
