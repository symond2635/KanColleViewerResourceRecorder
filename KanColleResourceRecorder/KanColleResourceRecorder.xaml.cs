using System;
using System.Windows;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grabacr07.KanColleViewer.Composition;
using Grabacr07.KanColleWrapper;
using System.Windows.Threading;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace KanColleResourceRecorder
{
    [Export(typeof(IPlugin))]
    [Export(typeof(ITool))]
    [ExportMetadata("Title", "KanColleResourceRecorder")]
    [ExportMetadata("Description", "資源をワンクリックでExcelに入力するプラグイン")]
    [ExportMetadata("Version", "1.0.0")]
    [ExportMetadata("Author", "@tkmd2525")]
    [ExportMetadata("Guid", "5C0AC743-6A93-4D87-B36D-65E3C7B43ABC")]

    public class Plugin : IPlugin, ITool
    {
        public void Initialize() { }
        public string Name => "KanColleResourceRecorder";
        public object View => new KanColleResourceRecorder();
    }

    public partial class KanColleResourceRecorder
    {
        /// <summary>
        /// 時計
        /// </summary>
        private DispatcherTimer timer;
        private DispatcherTimer Timer()
        {
            // タイマー生成（優先度はアイドル時に設定）
            var t = new DispatcherTimer(DispatcherPriority.SystemIdle);

            // タイマーイベントの発生間隔を300ミリ秒に設定
            t.Interval = TimeSpan.FromMilliseconds(300);

            // タイマーイベントの定義
            t.Tick += (sender, e) => {
                // タイマーイベント発生時の処理をここに書く

                // 現在の時分秒をテキストに設定
                Clock.Text = DateTime.Now.ToString("HH:mm:ss");
            };

            // 生成したタイマーを返す
            return t;
        }

        public KanColleResourceRecorder()
        {
            InitializeComponent();
            timer = Timer();
            timer.Start();
        }

        private void record(object sender, RoutedEventArgs e)
        {
            string fuel = KanColleClient.Current.Homeport.Materials.Fuel.ToString();
            string ammunition = KanColleClient.Current.Homeport.Materials.Ammunition.ToString();
            string steel = KanColleClient.Current.Homeport.Materials.Steel.ToString();
            string bauxite = KanColleClient.Current.Homeport.Materials.Bauxite.ToString();
            string developmentMaterials = KanColleClient.Current.Homeport.Materials.DevelopmentMaterials.ToString();
            string instantBuildMaterials = KanColleClient.Current.Homeport.Materials.InstantBuildMaterials.ToString();
            string instantRepairMaterials = KanColleClient.Current.Homeport.Materials.InstantRepairMaterials.ToString();
            string improvementMaterials = KanColleClient.Current.Homeport.Materials.ImprovementMaterials.ToString();


        }
           
        private void writeText(String value)
        {
            // シートを開く。
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Visible = true;

            Workbooks ExcelWBs = ExcelApp.Workbooks;
            Workbook ExcelWB = ExcelWBs.Open(@"C:\Users\xxx\source\repos\excel_test\excel_test\excel_test\bin\Debug\test.xlsx");
            Worksheet ExcelWorksheet = ExcelWB.Sheets[1];
            ExcelWorksheet.Select();

            // シートへ書き込みする。
            /*
            Range OutputRange1 = ExcelWorksheet.Range[ExcelWorksheet.Cells[1, 1], ExcelWorksheet.Cells[1, 5]];
            OutputRange1.Value2 = StringInput;

            Range OutputRange2 = ExcelWorksheet.Range[ExcelWorksheet.Cells[2, 1], ExcelWorksheet.Cells[2, 5]];
            OutputRange2.Value2 = ObjectInput;

            Range OutputRange3 = ExcelWorksheet.Range[ExcelWorksheet.Cells[3, 1], ExcelWorksheet.Cells[3, 5]];
            OutputRange3.Formula = ObjectInput;

            // ファイルへ書き込みする。
            ExcelWB.SaveAs(@"C:\Users\xxx\source\repos\excel_test\excel_test\excel_test\bin\Debug\test.xlsx");
            ExcelWB.Close();

            // オブジェクトを破棄する。
            Marshal.ReleaseComObject(OutputRange1);
            OutputRange1 = null;
            Marshal.ReleaseComObject(OutputRange2);
            OutputRange2 = null;
            Marshal.ReleaseComObject(OutputRange3);
            OutputRange3 = null;
            Marshal.ReleaseComObject(ExcelWorksheet);
            ExcelWorksheet = null;
            Marshal.ReleaseComObject(ExcelWB);
            ExcelWB = null;
            Marshal.ReleaseComObject(ExcelWBs);
            ExcelWBs = null;
            
            */
            // ガベージコレクションを実行する。
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            // アプリケーションを終了する。
            ExcelApp.Quit();

            // Appricationオブジェクトを破棄する。
            Marshal.ReleaseComObject(ExcelApp);
            ExcelApp = null;

            // Appricationオブジェクトのガベージコレクションを実行する。
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}