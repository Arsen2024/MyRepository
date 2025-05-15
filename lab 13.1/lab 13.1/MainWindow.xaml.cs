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
using System.Threading;

namespace lab_13._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread pingThread;
        private bool isRunning = false;
        private Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PingServer()
        {
            while(isRunning)
            {
                string result = random.Next(0, 2) == 0 ? "Успішно" : "Помилка";
                string log = $"{DateTime.Now:T} - Статус: {result}";

                Dispatcher.Invoke(() =>
                {
                    logListBox.Items.Insert(0, log);
                });
                Thread.Sleep(3000);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            isRunning = false;
            base.OnClosed(e);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(pingThread == null || !pingThread.IsAlive)
            {
                isRunning=true;
                pingThread = new Thread(PingServer);
                pingThread.IsBackground = true;
                pingThread.Start();
            }
        }
    }
}