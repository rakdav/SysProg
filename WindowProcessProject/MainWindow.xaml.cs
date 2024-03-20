using Microsoft.Win32;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowProcessProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow ()
        {
            InitializeComponent();
            Load();
        }
        private void Load ()
        {
            lvProcessList.ItemsSource = null;
            lvProcessList.ItemsSource= Process.GetProcesses();
        }

        private void MenuItem_Click ( object sender, RoutedEventArgs e )
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.exe)|*.exe";
            if (ofd.ShowDialog() == true)
            {
                string path = ofd.FileName;
                Process.Start(@$"{path}");
            }
        }

        private void MenuItem_Click_1 ( object sender, RoutedEventArgs e )
        {
            this.Close();
        }
    }
}