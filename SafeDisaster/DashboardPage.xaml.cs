using SafeDisaster.Class;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Window
    {
        private List<string> listLocation;
        public DashboardPage()
        {
            InitializeComponent();
            LoadEarthquakeData();
            listLocation = Weather.GetLocationList();
            cmbLocation.ItemsSource = listLocation;
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
        private void WeatherButton_Click(object sender, RoutedEventArgs e)
        {
            WeatherPage weatherPage = new WeatherPage();
            weatherPage.Show();
            this.Close();
        }
        private void LoadEarthquakeData()
        {
            try
            {
                Disaster newestDisaster = Disaster.GetNewestDisaster();

                // Menetapkan nilai TextBlock
                tanggalTextBlock.Text = $"Tanggal: {newestDisaster.Tanggal}";
                jamTextBlock.Text = $"Jam: {newestDisaster.Jam}";
                magnitudeTextBlock.Text = $"Magnitude: {newestDisaster.Magnitude}";
                kedalamanTextBlock.Text = $"Kedalaman: {newestDisaster.Kedalaman}";
                wilayahTextBlock.Text = $"Wilayah: {newestDisaster.Wilayah}";
                potensiTextBlock.Text = $"Potensi: {newestDisaster.Potensi}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
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

            int count = 0;
            foreach (Weather weather in listWeather)
            {
                if (count >= 4)
                    break; 

                weatherListView.Items.Add(weather);

                count++;
            }
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
    }
}
