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

    class Action{
        //property
        private string earthquakeInstruction =
        "Instruksi ketika terjadi gempa bumi:\n1. Melindungi kepala dengan menggunakan bantal atau helm, atau berdirilah di bawah pintu.\n2. Berlindung di bawah meja untuk menghindari dari benda-benda yang dimungkinkan akan jatuh seperti atap atau benda berbahaya lainnya.\n3. Bila keluar rumah, perhatikan kemungkinan pecahan kaca, genteng atau material lain. Tetap lindungi kepala anda dan segera menuju ke lapangan terbuka.\n4. Jangan berdiri di dekat tiang, pohon atau sumber listrik atau gedung yang mungkin roboh.\n5. Kenali bagian bangunan gedung atau rumah yang memiliki struktur kuat, seperti pada sudut bangunan untuk berlindung.\n6. Ikuti instruksi evakuasi dari pengelola, penjaga, atau petugas yang berwenang.\n7. Pilihlah menggunakan tangga darurat untuk melakukan evakuasi keluar bangunan. Apabila sedang berada di dalam elevator, tekan semua tombol atau gunakan interphone untuk melakukan panggilan kepada pengelola gedung.";
        private string floodInstruction =
        "Instruksi ketika terjadi banjir:\n1. Melakukan evakuasi diri dan keluarga ke tempat yang lebih tinggi atau lebih aman.\n2. Menyiapkan peralatan yang diperlukan selama evakuasi, seperti senter, korek api, alat penerangan dan peralatan darurat lainnya.\n3. Menyiapkan makanan kering atau instan.\n4. Menggunakan sepatu boot dan sarung tangan.\n5. Menyiapkan berbagai macam obat-obatan yang diperlukan untuk melakukan pertolongan pertama.";
        private string fireInstruction =
        "Instruksi ketika terjadi kebakaran:\n1. Segera dapatkan alat pemadam api.\n2. Beritahu orang sekitar\n3. Tinggalkan barang berharga jika tidak bisa lagi diselamatkan.\n4. Cari tempat evakuasi yang aman.\n5. Segera hubungi petugas pemadam kebakaran";

        //method
        public void ShowEarthquakeInstruction(){
            Console.WriteLine(earthquakeInstructions);
        }
        public void ShowFloodInstruction(){
            Console.WriteLine(floodInstructions);
        }
        public void ShowFireInstruction(){
            Console.WriteLine(fireInstructions);
        }

    }
}