using System;
using System.Windows;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grabacr07.KanColleViewer.Composition;
using Grabacr07.KanColleWrapper;
using System.Windows.Threading;

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

        }
    }
}