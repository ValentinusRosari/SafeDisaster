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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SafeDisaster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Lakukan validasi kredensial (contoh: username=admin, password=admin)
            if (username == "admin" && password == "admin")
            {
                // Berhasil login, tambahkan logika navigasi atau tindakan lainnya di sini
                MessageBox.Show("Sign In Success");
                DashboardPage dashboardPage = new DashboardPage();
                dashboardPage.Show();
                this.Close();
            }
            else
            {
                // Gagal login, tampilkan pesan kesalahan
                MessageBox.Show("Sign In Failed. Try Again.");
            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpPage signUpPage = new SignUpPage();
            signUpPage.Show();
            this.Close();
        }
      

    }
}
