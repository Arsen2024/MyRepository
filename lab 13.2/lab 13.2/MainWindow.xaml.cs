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
using System.Threading.Tasks;

namespace lab_13._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isRunning = false;
        private Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartPingTask(string serverName, int delay)
        {
            Task.Run(async () =>
            {
                while(isRunning)
                {
                    string status = random.Next(0, 2) == 0 ? "Успішно" : "Помилка";
                    string log = $"{DateTime.Now:T} - {serverName}: {status}";

                    Dispatcher.Invoke(() =>
                    {
                        logListBox.Items.Insert(0, log);
                    });

                    await Task.Delay(delay);
                }
            });
        }

        protected override void OnClosed(EventArgs e)
        {
            isRunning = false;
            base.OnClosed(e);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!isRunning)
            {
                isRunning=true;

                StartPingTask("Сервер 1", 3000);
                StartPingTask("Сервер 2", 5000);
                StartPingTask("Сервер 3", 7000);
            }
        }
    }
}