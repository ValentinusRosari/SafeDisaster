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
    /// Interaction logic for WeatherPage.xaml
    /// </summary>
    public partial class WeatherPage : Window
    {
        private List<string> listLocation;

        public WeatherPage()
        {
            InitializeComponent();
            listLocation = Weather.GetLocationList();

            cmbLocation.ItemsSource = listLocation;
        }

        private void cmbLocation_DropDownOpened(object sender, EventArgs e)
        {
            TextBox textBox = cmbLocation.Template.FindName("PART_EditableTextBox", cmbLocation) as TextBox;

            if (textBox != null)
            {
                textBox.TextChanged += cmbLocation_TextChanged;
            }
        }
        private void btnSearchClick(object sender, EventArgs e)
        {
            List<Weather> listWeather = Weather.GetWeatherList(GetIdLocation(cmbLocation.Text));

            weatherListView.ItemsSource = listWeather;

        }
        private string GetIdLocation(string kota)
        {
            string idLocation = "-1";
            idLocation = Weather.GetLocationId(kota);
            return idLocation;
        }

        private void cmbLocation_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = cmbLocation.Text;
            cmbLocation.ItemsSource = listLocation.Where(location => location.Contains(filter)).ToList();
        }
        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardPage dashboardPage = new DashboardPage();
            dashboardPage.Show();
            this.Close();
        }
        private void DisasterButton_Click(object sender, RoutedEventArgs e)
        {
            DisasterPage disasterPage = new DisasterPage();
            disasterPage.Show();
            this.Close();
        }
        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            ActionPage actionPage = new ActionPage();
            actionPage.Show();
            this.Close();
        }
        private void OnListViewLoaded(object sender, RoutedEventArgs e)
        {
            AdjustColumnWidths();
        }
        private void AdjustColumnWidths()
        {
            if (weatherListView.View is GridView gridView)
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
