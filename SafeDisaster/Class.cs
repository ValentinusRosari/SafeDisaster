using System;
using System.Collection.Generics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeDisaster{
    class User{
        //instance variables
        private string _userID;
        private string _userName;
        private string _email;
        private int _phoneNumber;
        private string _password;

        //property
        public string UserID{
            get {return _userID;}
        }
        public string UserName{
            get {return _userName;}
            set {_userName = value;}
        }
        public string Email{
            get {return _email;}
            set {_email = value;}
        }
        public int PhoneNumber{
            get {return _phoneNumber;}
            set {_phoneNumber = value;}
        }
        public string Password{
            get {return _password;}
            set {_password = value;}
        }

        //method
        public bool Login(string enteredUserName, string enteredPassword){
            if(enteredUserName == UserName && enteredPassword == Password){
                Console.WriteLine("Login berhasil!");
                return true;
            }
            else{
                Console.WriteLine("Login gagal. Silakan coba lagi!");
                return false;
            }
        }

        public User(string userID, string userName, string email, int phoneNumber, string password){
            _userID = userID;
            _userName = userName;
            _email = email;
            _phoneNumber = phoneNumber;
            _password = password;
        }

        public void SetProfile(string newUserName, string newEmail, int newPhoneNumber, string newPassword){
            string userID = Guid.NewGuid().ToString();
            
            UserID = userID;
            UserName = newUserName;
            Email = newEmail;
            PhoneNumber = newPhoneNumber;
            Password = newPassword;
        }

        public void DisplayProfile(){
            Console.WriteLine($"Username: {UserName}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
        }
    }
}