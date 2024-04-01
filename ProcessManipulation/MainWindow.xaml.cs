using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
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

namespace ProcessManipulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const uint WM_SETTEXT=0x0C;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage ( IntPtr hwnd,uint Msg,int wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);
        List<Process> processes = new List<Process>();
        int Counter = 0;
        public MainWindow ()
        {
            InitializeComponent();
            LoadAvailableAssemblies();
        }
        private void LoadAvailableAssemblies ()
        {
            string? except =new FileInfo(Process.GetCurrentProcess().ProcessName).DirectoryName;
            DirectoryInfo currentExe = new DirectoryInfo(Assembly.GetExecutingAssembly().GetName().CodeBase);
            FileInfo[] f = currentExe.GetFiles();
            var list = 0;
            
        }
    }
}