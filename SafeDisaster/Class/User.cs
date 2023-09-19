using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public User(string userName, string email, string phoneNumber, string password)
        {
            this.UserName = userName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Password = password;
        }

        // Methods
        public bool Login(string enteredUserName, string enteredPassword)
        {
            if (enteredUserName == UserName && enteredPassword == Password)
            {
                Console.WriteLine("Login berhasil!");
                return true;
            }
            else
            {
                Console.WriteLine("Login gagal. Silakan coba lagi!");
                return false;
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
        public int getUserId()
        {
            return UserID;
        }
        public void getDisasterInformation()
        {
            
        }
    }
}
