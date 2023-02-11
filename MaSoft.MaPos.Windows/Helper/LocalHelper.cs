using DevExpress.Images;
using DevExpress.Utils;
using DevExpress.Utils.Animation;
using DevExpress.Utils.Svg;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraGauges.Win;
using DevExpress.XtraGrid;
using DevExpress.XtraPdfViewer;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit;
using DevExpress.XtraSpreadsheet;
using MaSoft.MaPos.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaSoft.MaPos.Windows
{
    public static class LocalHelper
    {
        public static void WarmUp()
        {
            // Amaç, ilk açılış sonrasında, yazılımı hızlandırmak...
            RuntimeHelpers.RunClassConstructor(typeof(ImagesAssemblyType).TypeHandle);
            RuntimeHelpers.RunClassConstructor(typeof(TileControl).TypeHandle);
            RuntimeHelpers.RunClassConstructor(typeof(AppearanceObject).TypeHandle);
            RuntimeHelpers.RunClassConstructor(typeof(BaseEdit).TypeHandle);
            RuntimeHelpers.RunClassConstructor(typeof(DevExpress.DataAccess.Sql.SqlDataSource).TypeHandle);
            RuntimeHelpers.RunClassConstructor(typeof(DevExpress.DataAccess.UI.FilterEditorControl).TypeHandle);
            RuntimeHelpers.RunClassConstructor(typeof(GridControl).TypeHandle);
            RuntimeHelpers.RunClassConstructor(typeof(SpreadsheetControl).TypeHandle);
            RuntimeHelpers.RunClassConstructor(typeof(ChartControl).TypeHandle);
            RuntimeHelpers.RunClassConstructor(typeof(GaugeControl).TypeHandle);
            RuntimeHelpers.RunClassConstructor(typeof(PivotGridControl).TypeHandle);
            RuntimeHelpers.RunClassConstructor(typeof(XtraReport).TypeHandle);
            RuntimeHelpers.RunClassConstructor(typeof(PdfViewer).TypeHandle);
        }

        public static void ApplyTouchMode()
        {
            WindowsFormsSettings.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.True;
            WindowsFormsSettings.ApplyDemoSettings();
        }

        public static void WaitInternetConnection(int Seconds)
        {
            int CurrTickCount = Environment.TickCount;

            int MiliSeconds = (Seconds * 1000);
            while (((Environment.TickCount - CurrTickCount) <= MiliSeconds) && (!AppHelper.InternetConnectionExist()))
            {
                Thread.Sleep(25);
                Application.DoEvents();
            }

            Application.DoEvents();
        }

        public static void Wait(int Seconds)
        {
            int CurrTickCount = Environment.TickCount;

            int MiliSeconds = (Seconds * 1000);
            while ((Environment.TickCount - CurrTickCount) <= MiliSeconds)
            {
                Thread.Sleep(25);
                Application.DoEvents();
            }

            Application.DoEvents();
        }

        public static void WaitMiliSecond(int MiliSeconds)
        {
            int CurrTickCount = Environment.TickCount;
            while ((Environment.TickCount - CurrTickCount) <= MiliSeconds)
            {
                Thread.Sleep(25);
                Application.DoEvents();
            }

            Application.DoEvents();
        }

        public static Image ConvertSvgToBitmap_FromResource(byte[] byteArray, int width, int height)
        {
            DevExpress.Utils.Svg.SvgImage svgImage = DevExpress.XtraEditors.Controls.SvgImageBinaryConverter.FromByteArray((byte[])byteArray);
            DevExpress.Utils.Svg.SvgBitmap svgBitmap = new DevExpress.Utils.Svg.SvgBitmap(svgImage);
            return svgBitmap.Render(new Size(width, height),
                                        DevExpress.Utils.Svg.SvgPaletteHelper.GetSvgPalette(DevExpress.LookAndFeel.UserLookAndFeel.Default,
                                        DevExpress.Utils.Drawing.ObjectState.Normal));
        }

        public static SvgImage SvgFromByteArray(byte[] resource)
        {
            using (MemoryStream stream = new MemoryStream(resource))
            {
                return SvgImage.FromStream(stream);
            }
        }
    }

    public class BatchTransition: IDisposable
    {
        private TransitionManager manager;
        public BatchTransition(TransitionManager manager, Control control)
        {
            this.manager = manager;
            manager.StartTransition(control);
        }

        public void Dispose()
        {
            manager.EndTransition();
            manager = null;
        }
    }

}
