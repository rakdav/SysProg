using System.Drawing;
using System.IO;
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
using Path = System.IO.Path;

namespace PictureLoad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        public MainWindow ()
        {
            InitializeComponent();
        }

        private void cmdProcess_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(()=> ProcessFiles());
            this.Title = "Processing Complete";
        }
        private void ProcessFiles()
        {
            var basePath = Directory.GetCurrentDirectory();
            var pictureDirectory = Path.Combine(basePath, "TestPictures");
            var outputDirectory = Path.Combine(basePath, "ModifiedPictures");
            if (Directory.Exists(outputDirectory))
            {
                Directory.Delete(outputDirectory,true);
            }
            Directory.CreateDirectory(outputDirectory);
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = Environment.ProcessorCount;

            string[] files = Directory.GetFiles(pictureDirectory,"*.jpg",
                SearchOption.AllDirectories);
            //foreach (string item in files)
            //{
            try { 
            Parallel.ForEach(files, currentFile =>
            {
                parOpts.CancellationToken.ThrowIfCancellationRequested();
                string fileName = Path.GetFileName(currentFile);
                Dispatcher?.Invoke(()=>
                {
                    this.Title = $"Processing {fileName} on thread " +
                    $"{Thread.CurrentThread.ManagedThreadId}";
                });
                
                using (Bitmap bitmap = new Bitmap(currentFile))
                {
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(outputDirectory, fileName));
                }
            });
            }
            catch(OperationCanceledException ex)
            {
                Dispatcher?.Invoke(()=>this.Title=ex.Message);
            }
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            cancelToken.Cancel();
        }
    }
}