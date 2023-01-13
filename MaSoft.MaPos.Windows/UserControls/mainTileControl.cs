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

namespace MaSoft.MaPos.Windows {
    public partial class mainTileControl: MaPosUserControl
    {
        public mainTileControl() {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            SetBackground();
            InitEvents();
        }

        public void InitEvents()
        {
            tileControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(TileControlKeyUp);
        }

        void SetBackground()
        {
            tileControl1.BackgroundImage = TileControlBackgroundImage;
        }

        private void itemTableOrder_ItemClick(object sender, TileItemEventArgs e)
        {
            ShowTableOrderPage();
        }

        private void tileControl1_StartItemDragging(object sender, TileItemDragEventArgs e)
        {
            // Tile da drag and drop yapısına şu an gerek yok, daha sonra ana ekran tasarımı kayıt edilebilir ama şu an değil...
            e.Cancel = true;
        }
    }
}
