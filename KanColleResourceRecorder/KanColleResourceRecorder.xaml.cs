using System;
using System.Windows;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grabacr07.KanColleViewer.Composition;
using Grabacr07.KanColleWrapper;

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
        public KanColleResourceRecorder()
        {
            InitializeComponent();
        }

        private void Fuel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show(KanColleClient.Current.Homeport.Materials.Fuel.ToString());
        }
        private void Ammunition_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show(KanColleClient.Current.Homeport.Materials.Ammunition.ToString());
        }
        private void Steel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show(KanColleClient.Current.Homeport.Materials.Steel.ToString());
        }
        private void Bauxite_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show(KanColleClient.Current.Homeport.Materials.Bauxite.ToString());
        }
    }
}