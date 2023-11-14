using SafeDisaster.Class;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SafeDisaster
{
    /// <summary>
    /// Interaction logic for DisasterPage.xaml
    /// </summary>
    public partial class DisasterPage : Window
    {
        public DisasterPage()
        {
            InitializeComponent();
            List<Disaster> listDisaster = Disaster.GetDisasterList();
            disasterListView.ItemsSource = listDisaster;
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardPage dashboardPage = new DashboardPage();
            dashboardPage.Show();
            this.Close();
        }
        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            ActionPage actionPage = new ActionPage();
            actionPage.Show();
            this.Close();
        }
        private void WeatherButton_Click(object sender, RoutedEventArgs e)
        {
            WeatherPage weatherPage = new WeatherPage();
            weatherPage.Show();
            this.Close();
        }
        private void OnListViewLoaded(object sender, RoutedEventArgs e)
        {
            AdjustColumnWidths();
        }

        private void AdjustColumnWidths()
        {
            if (disasterListView.View is GridView gridView)
            {
                foreach (var column in gridView.Columns)
                {
                    // Set lebar kolom berdasarkan isi kontennya
                    column.Width = column.ActualWidth;
                    column.Width = double.NaN;
                }
            }
        }
    }
}
