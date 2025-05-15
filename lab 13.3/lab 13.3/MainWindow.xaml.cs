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
using System.Threading.Tasks;
using System.Collections.Generic;

namespace lab_13._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task<List<string>> GetDataFromDatabase()
        {
            await Task.Delay(4000);

            var fData = new List<string>()
            {
                "ID: 1, Name: Arsen",
                "ID: 2, Name: Illya",
                "ID: 3, Name: Petya"
            };
            return fData;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Clear();
            ListBox.Items.Add("Виконується запит до бази даних...");

            var data = await GetDataFromDatabase();

            ListBox.Items.Clear();
            foreach (var item in data)
            {
                ListBox.Items.Add(item);
            }
        }
    }
}