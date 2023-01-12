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
    public partial class mainTableControl: XtraUserControl {
        public mainTableControl() {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            SetBackground();
            InitEvents();
        }

        public void InitEvents()
        {
            //
        }

        void SetBackground() {
            BackgroundImage = TileControlBackgroundImage;
        }
        void OnTileControlKeyUp(object sender, KeyEventArgs e) {
            if(e.KeyData == Keys.Escape)
                Application.Exit();
        }
        Image tileControlBackground = null;
        Image TileControlBackgroundImage {
            get {
                if(tileControlBackground == null)
                    tileControlBackground = CreateBackgroundImage();
                return tileControlBackground;
            }
        }
        Image CreateBackgroundImage() {
            Rectangle screenBounds = Screen.FromControl(this).Bounds;
            Image bottomImg = GetBottomImage();
            Bitmap img = new Bitmap(screenBounds.Width, screenBounds.Height);
            using(Graphics graphics = Graphics.FromImage(img)) {
                using(SolidBrush br = new SolidBrush(Color.FromArgb(36, 0, 64))) {
                    graphics.FillRectangle(br, new Rectangle(Point.Empty, img.Size));
                }
                graphics.DrawImage(bottomImg, 0, screenBounds.Bottom - bottomImg.Height);
            }
            return img;
        }
        Image GetBottomImage() { return MaSoft.MaPos.Windows.Properties.Resources.Background; }

        public event EventHandler OnDesktopClick;

        private void itemDesktop_ItemClick(object sender, TileItemEventArgs e) {
            OnDesktopClick.Invoke(this, new EventArgs());
        }
    }
}
