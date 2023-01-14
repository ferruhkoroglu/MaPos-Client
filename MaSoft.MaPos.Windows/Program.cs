using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;

using DevExpress.LookAndFeel;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

using MaSoft.MaPos.Core;
using MaSoft.MaPos.Models;

using MaSoft.MaPos.Models.MaPos;
using MessageHelper = MaSoft.MaPos.Windows.MessageHelper;

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
            StaticVariables.cultureInfo = CultureInfo.GetCultureInfo("tr-TR");
            Thread.CurrentThread.CurrentCulture = StaticVariables.cultureInfo;
            Thread.CurrentThread.CurrentUICulture = StaticVariables.cultureInfo;

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

                /*
                StaticVariables.HostIp = ".\\SQLEXPRESS01";
                StaticVariables.UserName = "sa";
                StaticVariables.DbPassword = "123";
                StaticVariables.Db = "MaPos";
                */

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
                // ...
                // MessageHelper.SuccessMsg("Veritabanı Bağlantısı", "Bağlantı Başarı ile sağlandı..");
                // İşleme devam...
            }

            MaPosSplashForm splashForm = new MaPosSplashForm(() => { LocalHelper.WarmUp(); });
            splashForm.ShowDialog();

            // Wxi Sharpness özellikle set ediliyor..           
            UserLookAndFeel.Default.SetSkinStyle(SkinSvgPalette.WXI.Sharpness);

            
            frmLogin lgnForm = new frmLogin();
            lgnForm.ShowDialog();

            // Eğer User Authentication sağlanmamış ise !
            if (!StaticVariables.UserAuthenticated)
            {
                Application.Exit();
                return;
            }
            

            // ORM Initialize...            
            // DevExpress.Xpo.DB.IDataStore store = XPOHelper.GetConnectionProvider(AutoCreateOption.SchemaAlreadyExists);
            XpoDefault.DataLayer = XPOHelper.GetDataLayer(AutoCreateOption.SchemaAlreadyExists);

            // Unit Of Work...
            XpoDefault.Session.AutoCreateOption = DevExpress.Xpo.DB.AutoCreateOption.None;
            XpoDefault.Session = new UnitOfWork(XpoDefault.DataLayer);

            // Test Load...            
            //var xpCollection = new XPCollection(typeof(Users));
            //var userInfo = XpoDefault.Session.Query<Users>().Where(a => a.Password == StaticVariables.UserPassword).ToList().FirstOrDefault();
            //MessageHelper.SuccessMsg("Hoşgeldiniz, Kullanıcı Adı:", userInfo.UserName);

            //var xpCollection = new XPCollection(typeof(Tables));
            //var tblInfo = XpoDefault.Session.Query<Tables>().ToList();


            // Load Program Settings...
            ProgramVariables.ProgSettings = XpoDefault.Session.Query<ProgramSettings>().ToList().FirstOrDefault();

            MaPosMainForm mainForm = new MaPosMainForm();
            MaPosUserControl.mainForm = mainForm;

            Application.Run(mainForm);
        }
    }
}
