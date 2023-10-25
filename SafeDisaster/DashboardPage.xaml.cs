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
        public DashboardPage()
        {
            InitializeComponent();
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
    }
}
