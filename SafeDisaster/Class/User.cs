using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SafeDisaster.Class
{
    class User
    {
        // Instance variables
        private int _userID;
        private string _userName;
        private string _email;
        private string _phoneNumber;
        private string _password;

        // Properties
        public int UserID
        {
            get { return _userID; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        // Constructor
        public User()
        {
          
        }

        // Methods
        public void Login(string enteredUserName, string enteredPassword, Window window)
        {
            UserName = enteredUserName;
            Password = enteredPassword;
            try
            {
                DatabaseConnection.OpenConnection();
                Console.WriteLine("Connected to database");

                string query = @"SELECT * from users_check(:_username_or_email, :_password)";

                NpgsqlCommand command = new NpgsqlCommand(query, DatabaseConnection.GetConnection());
                command.Parameters.AddWithValue("_username_or_email", UserName);
                command.Parameters.AddWithValue("_password", Password);
                if ((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Login Success");
                    DashboardPage dashboardPage = new DashboardPage();
                    window.Close();
                    dashboardPage.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed, Please Sign Up First");
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

        public void SignUp(string enteredUsername, string enteredEmail, string enteredPhoneNo, string enteredPasswword, Window window)
        {
            UserName = enteredUsername;
            Email = enteredEmail;
            PhoneNumber = enteredPhoneNo;
            Password = enteredPasswword;
            try
            {
                DatabaseConnection.OpenConnection();
                Console.WriteLine("Connected to database");

                string query = @"SELECT * from user_insert(:_name, :_email, :_phone_no, :_password)";

                NpgsqlCommand command = new NpgsqlCommand(query, DatabaseConnection.GetConnection());
                command.Parameters.AddWithValue("_name", UserName);
                command.Parameters.AddWithValue("_email", Email);
                command.Parameters.AddWithValue("_phone_no", PhoneNumber);
                command.Parameters.AddWithValue("_password", Password);
                if ((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Register Success");
                    DashboardPage dashboardPage = new DashboardPage();
                    window.Close();
                    dashboardPage.Show();
                }
                else
                {
                    MessageBox.Show("Register Failed, You Already Have an Account");
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

        public void SetProfile(string newUserName, string newEmail, string newPhoneNumber, string newPassword)
        {
            UserName = newUserName;
            Email = newEmail;
            PhoneNumber = newPhoneNumber;
            Password = newPassword;
        }

        public void DisplayProfile()
        {
            Console.WriteLine($"Username: {UserName}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
        }
        public void getDisasterInformation()
        {
            
        }
    }
}
