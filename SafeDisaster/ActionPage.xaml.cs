﻿using System;
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
    /// Interaction logic for ActionPage.xaml
    /// </summary>
    public partial class ActionPage : Window
    {
        public ActionPage()
        {
            InitializeComponent();
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
        private void WeatherButton_Click(object sender, RoutedEventArgs e)
        {
            WeatherPage weatherPage = new WeatherPage();
            weatherPage.Show();
            this.Close();
        }
        }
    }
