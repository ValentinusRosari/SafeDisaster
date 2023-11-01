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
            try
            {
                DatabaseConnection.OpenConnection();
                Console.WriteLine("Connected to database");

                string query = @"SELECT * from users_check(:_username_or_email, :_password)";

                NpgsqlCommand command = new NpgsqlCommand(query, DatabaseConnection.GetConnection());
                command.Parameters.AddWithValue("_username_or_email", txtUsernameOrEmail.Text);
                command.Parameters.AddWithValue("_password", txtPassword.Password);
                if ((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Login Success");
                    DashboardPage dashboardPage = new DashboardPage();
                    this.Close();
                    dashboardPage.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed, Please Sign Up First");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
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
