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
using WMS_app.Model;

namespace WMS_app
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var dataGrid = new DataGrid();
            this.WMS_Grid.Children.Add(dataGrid);

            for (int i = 0; i < 3; i++)
            {
                var dataColumn = new DataGridTextColumn();
                dataColumn.Header = "Column " + i;
                dataColumn.Binding = new Binding("Column " + i);
                dataGrid.Columns.Add(dataColumn);
            }

            dataGrid.Items.Add(new DataModel { Id = 1, ItemName = "Keyboard", ItemQuantity = 25 });
            dataGrid.Items.Add(new DataModel { Id = 2, ItemName = "Monitor", ItemQuantity = 15 });
            dataGrid.Items.Add(new DataModel { Id = 3, ItemName = "Mouse", ItemQuantity = 30 });
            dataGrid.Items.Add(new DataModel { Id = 4, ItemName = "Headset", ItemQuantity = 20 });
        }
    }
}