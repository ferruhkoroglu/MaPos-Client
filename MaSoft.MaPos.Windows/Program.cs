using DevExpress.Data.Filtering;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;

using MaSoft.MaPos.Core;
using MessageHelper = MaSoft.MaPos.Core.MessageHelper;
using MaSoft.MaPos.Windows.Helper;
using System.Drawing;

namespace MaSoft.MaPos.Windows
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("tr-TR");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            // Custom MessageBoxes...
            MessageHelper.Initialize();

            // DevEx Touch Mode Enabled...
            LocalHelper.ApplyTouchMode();

            //DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Segoe UI", 9);
            // ilk açılışta round corner lar düzgün gözükmesi için...
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.WXI);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // Load Config Info..
            #region LoadConfig Info
            try
            {
                StaticVariables.HostIp = ConfigurationManager.AppSettings["HostIp"];
                StaticVariables.UserName = ConfigurationManager.AppSettings["UserName"];

                StaticVariables.Db = ConfigurationManager.AppSettings["Db"];
                StaticVariables.DbPassword = ConfigurationManager.AppSettings["DbPassword"];
            }
            catch
            {
                // Bağlantı bilgileri alınamadı...
                // Exc.Message..
                MessageHelper.ErrorMsg("Veritabanı Bilgileri", "app.config dosyasındaki bağlantı bilgilerini kontrol ediniz, bilgiler eksik veya hatalı !");

                Application.Exit();
                return;
            }
            #endregion 


            // SQL Server 'a bağlantı var mı ?
            if (!AppHelper.ConnectTest())
            {
                MessageHelper.ErrorMsg("Veritabanı Bağlantısı", "Veritabanı bağlantısı sağlanamadı,Lütfen bağlantı ayarlarını kontrol ediniz !");

                Application.Exit();
                return;
            }
            else 
            {
                //MessageHelper.SuccessMsg("Veritabanı Bağlantısı", "Bağlantı Başarı ile sağlandı..");
                // İşleme devam...
            }

            MaPosSplashForm splashForm = new MaPosSplashForm(() => { LocalHelper.WarmUp(); });
            splashForm.ShowDialog();


            // Wxi Sharpness özellikle set ediliyor..           
            UserLookAndFeel.Default.SetSkinStyle(SkinSvgPalette.WXICompact.Sharpness);

            Application.Run(new frmLogin());
        }
    }
}
