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
using Npgsql;

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
            Class.User user = new Class.User();
            user.Login(txtUsernameOrEmail.Text, txtPassword.Password, this);
        }


        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpPage signUpPage = new SignUpPage();
            signUpPage.Show();
            this.Close();
        }

        private void LoginPage_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection();
                Console.WriteLine("Database connect success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
