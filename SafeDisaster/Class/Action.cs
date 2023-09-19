using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeDisaster.Class
{
    internal class Action
{
     private string _disasterName;

        public string DisasterName
        {
            get { return _disasterName; }
            set { _disasterName = value; }
        }

    // Properties
    private string _earthquakeInstruction =
        "Instruksi ketika terjadi gempa bumi:\n1. Melindungi kepala dengan menggunakan bantal atau helm, atau berdirilah di bawah pintu.\n2. Berlindung di bawah meja untuk menghindari dari benda-benda yang dimungkinkan akan jatuh seperti atap atau benda berbahaya lainnya.\n3. Bila keluar rumah, perhatikan kemungkinan pecahan kaca, genteng atau material lain. Tetap lindungi kepala anda dan segera menuju ke lapangan terbuka.\n4. Jangan berdiri di dekat tiang, pohon atau sumber listrik atau gedung yang mungkin roboh.\n5. Kenali bagian bangunan gedung atau rumah yang memiliki struktur kuat, seperti pada sudut bangunan untuk berlindung.\n6. Ikuti instruksi evakuasi dari pengelola, penjaga, atau petugas yang berwenang.\n7. Pilihlah menggunakan tangga darurat untuk melakukan evakuasi keluar bangunan. Apabila sedang berada di dalam elevator, tekan semua tombol atau gunakan interphone untuk melakukan panggilan kepada pengelola gedung.";
    private string _floodInstruction =
        "Instruksi ketika terjadi banjir:\n1. Melakukan evakuasi diri dan keluarga ke tempat yang lebih tinggi atau lebih aman.\n2. Menyiapkan peralatan yang diperlukan selama evakuasi, seperti senter, korek api, alat penerangan dan peralatan darurat lainnya.\n3. Menyiapkan makanan kering atau instan.\n4. Menggunakan sepatu boot dan sarung tangan.\n5. Menyiapkan berbagai macam obat-obatan yang diperlukan untuk melakukan pertolongan pertama.";
    private string _fireInstruction =
        "Instruksi ketika terjadi kebakaran:\n1. Segera dapatkan alat pemadam api.\n2. Beritahu orang sekitar\n3. Tinggalkan barang berharga jika tidak bisa lagi diselamatkan.\n4. Cari tempat evakuasi yang aman.\n5. Segera hubungi petugas pemadam kebakaran";

    // Methods
    public string ShowEarthquakeInstruction()
    {
        return _earthquakeInstruction;
    }

    public string ShowFloodInstruction()
    {
        return _floodInstruction;
    }

    public string ShowFireInstruction()
    {
        return _fireInstruction;
    }

     public string getDisasterAction(string disasterName)
        {
            if (disasterName == "Gempa")
            {
                return ShowEarthquakeInstruction();
            }
            else if (disasterName == "Banjir")
            {
                return ShowFloodInstruction();
            }
            else if (disasterName == "Kebakaran")
            {
                return ShowFireInstruction();
            }
            else
            {
                return "Kami akan segera mengupdate langkah-langkah untuk menanggulangi bencana yang lain.";
            }
        }
}


}
