using Npgsql;
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
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Window
    {
        public SignUpPage()
        {
            InitializeComponent();
        }


        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DatabaseConnection.OpenConnection();
                Console.WriteLine("Connected to database");

                string query = @"SELECT * from user_insert(:_name, :_email, :_phone_no, :_password)";

                NpgsqlCommand command = new NpgsqlCommand(query, DatabaseConnection.GetConnection());
                command.Parameters.AddWithValue("_name", txtSignUpUsername.Text);
                command.Parameters.AddWithValue("_email", txtSignUpEmail.Text);
                command.Parameters.AddWithValue("_phone_no", txtSignUpPhoneNumber.Text);
                command.Parameters.AddWithValue("_password", txtSignUpPassword.Password);
                if ((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Register Success");
                    DashboardPage dashboardPage = new DashboardPage();
                    this.Close();
                    dashboardPage.Show();
                }
                else
                {
                    MessageBox.Show("Register Failed, You are Already Have an Account");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }
    }
}
