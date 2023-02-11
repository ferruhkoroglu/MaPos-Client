using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;


namespace MaSoft.MaPos.Windows
{
    public class MaPosUserControl: XtraUserControl
    {
        public static MaPosMainForm mainForm = null;

        public void CloseApp(bool IsQuestion = true)
        {
            if (mainForm != null)
                mainForm.CloseApp(IsQuestion);
        }

        public void ShowMainMenu()
        {
            if (mainForm != null) 
                mainForm.ShowMainMenu();
        }

        public void ShowTableOrderPage()
        {
            if (mainForm != null)
                mainForm.ShowTableOrder();
        }
        public void ShowLoginPage()
        {
            if (mainForm != null)
                mainForm.ShowLogin();
        }

        protected void TileControlKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Application.Exit();
        }

        Image tileControlBackground = null;
        protected Image TileControlBackgroundImage
        {
            get
            {
                if (tileControlBackground == null)
                    tileControlBackground = CreateBackgroundImage();
                return tileControlBackground;
            }
        }
        protected Image CreateBackgroundImage()
        {
            Rectangle screenBounds = Screen.FromControl(this).Bounds;
            Image bottomImg = GetBottomImage();
            Bitmap img = new Bitmap(screenBounds.Width, screenBounds.Height);
            using (Graphics graphics = Graphics.FromImage(img))
            {
                using (SolidBrush br = new SolidBrush(Color.FromArgb(36, 0, 64)))
                {
                    graphics.FillRectangle(br, new Rectangle(Point.Empty, img.Size));
                }
                graphics.DrawImage(bottomImg, 0, screenBounds.Bottom - bottomImg.Height);
            }
            return img;
        }
        Image GetBottomImage() { return MaSoft.MaPos.Windows.Properties.Resources.Background; }
    }
}
