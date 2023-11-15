using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace SafeDisaster.Class
{
    internal class Disaster
    {
        private string _tanggal;
        private string _jam;
        private string _magnitude;
        private string _kedalaman;
        private string _wilayah;
        private string _potensi;
        public string Tanggal { 
            get { return _tanggal; }
            set { _tanggal = value; }
        }
        public string Jam
        {
            get { return _jam; }
            set { _jam = value; }
        }
        public string Magnitude
        {
            get { return _magnitude; }
            set { _magnitude = value; }
        }
        public string Kedalaman
        {
            get { return _kedalaman; }
            set { _kedalaman = value; }
        }
        public string Wilayah
        {
            get { return _wilayah; }
            set { _wilayah = value; }
        }
        public string Potensi
        {
            get { return _potensi; }
            set { _potensi = value; }
        }
        public Disaster(string tanggal, string jam, string magnitude, string kedalaman, string wilayah, string potensi)
        {
            Tanggal = tanggal;
            Jam = jam;
            Magnitude = magnitude;
            Kedalaman = kedalaman;
            Wilayah = wilayah;
            Potensi = potensi;
        }

        public static List<Disaster> GetDisasterList()
        {
            List<Disaster> returnList = new List<Disaster>();
            var client = new RestClient("https://data.bmkg.go.id/DataMKG/TEWS/gempaterkini.json");
            var request = new RestRequest(Method.GET);

            try
            {
                IRestResponse response = client.Execute(request);

                // Periksa apakah permintaan HTTP berhasil
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    JsonObject obj = (JsonObject)SimpleJson.DeserializeObject(response.Content);
                    JsonObject gempaObj = (JsonObject)obj["Infogempa"];

                    // Pastikan obj["gempa"] ada dan merupakan array
                    if (gempaObj.ContainsKey("gempa") && gempaObj["gempa"] is JsonArray disasterListArray)
                    {
                        foreach (JsonObject disasterJson in disasterListArray)
                        {
                            // Ubah JsonObject menjadi objek Disaster
                            Disaster disaster = new Disaster(
                                Convert.ToString(disasterJson.TryGetValue("Tanggal", out var tanggal) ? tanggal : ""),
                                Convert.ToString(disasterJson.TryGetValue("Jam", out var jam) ? jam : ""),
                                Convert.ToString(disasterJson.TryGetValue("Magnitude", out var magnitude) ? magnitude : 0.0),
                                Convert.ToString(disasterJson.TryGetValue("Kedalaman", out var kedalaman) ? kedalaman : 0.0),
                                Convert.ToString(disasterJson.TryGetValue("Wilayah", out var wilayah) ? wilayah : ""),
                                Convert.ToString(disasterJson.TryGetValue("Potensi", out var potensi) ? potensi : "")
                            );

                            returnList.Add(disaster);
                        }
                    }
                    else
                    {
                        returnList.Add(new Disaster("Error", "Error", "Error", "Error", "Error", "Error"));
                    }
                }
                else
                {
                    // Tanggapi jika permintaan HTTP tidak berhasil
                    // Dalam kasus ini, Anda bisa menambahkan objek Disaster dengan nilai default atau null ke dalam koleksi
                    returnList.Add(new Disaster($"Error: Kode status HTTP {response.StatusCode}", "", "", "", "", ""));
                }
            }
            catch (Exception ex)
            {
                // Tanggapi jika terjadi kesalahan lainnya
                // Dalam kasus ini, Anda bisa menambahkan objek Disaster dengan nilai default atau null ke dalam koleksi
                returnList.Add(new Disaster($"Error: {ex.Message}", "", "", "", "", ""));
            }

            return returnList;
        }
        public static Disaster GetNewestDisaster()
        {
            var client = new RestClient("https://data.bmkg.go.id/DataMKG/TEWS/autogempa.json");
            var request = new RestRequest(Method.GET);

            try
            {
                IRestResponse response = client.Execute(request);

                // Periksa apakah permintaan HTTP berhasil
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    JsonObject obj = (JsonObject)SimpleJson.DeserializeObject(response.Content);
                    JsonObject infoGempaObj = (JsonObject)obj["Infogempa"];
                    JsonObject gempaObj = (JsonObject)infoGempaObj["gempa"];


                    // Mengambil data dari JSON dan membuat objek Disaster
                    Disaster newestDisaster = new Disaster(
                        Convert.ToString(gempaObj.TryGetValue("Tanggal", out var tanggalObj) ? tanggalObj : ""),
                        Convert.ToString(gempaObj.TryGetValue("Jam", out var jamObj) ? jamObj : ""),
                        Convert.ToString(gempaObj.TryGetValue("Magnitude", out var magnitudeObj) ? magnitudeObj : ""),
                        Convert.ToString(gempaObj.TryGetValue("Kedalaman", out var kedalamanObj) ? kedalamanObj : ""),
                        Convert.ToString(gempaObj.TryGetValue("Wilayah", out var wilayahObj) ? wilayahObj : ""),
                        Convert.ToString(gempaObj.TryGetValue("Potensi", out var potensiObj) ? potensiObj : "")
                    );

                    return newestDisaster;
                }
                else
                {
                    // Tanggapi jika permintaan HTTP tidak berhasil
                    // Dalam kasus ini, Anda bisa menambahkan objek Disaster dengan nilai default atau null
                    return new Disaster("Error", "Error", "Error", "Error", "Error", "Error");
                }
            }
            catch (Exception ex)
            {
                // Tanggapi jika terjadi kesalahan lainnya
                // Dalam kasus ini, Anda bisa menambahkan objek Disaster dengan nilai default atau null
                return new Disaster($"Error: {ex.Message}", "", "", "", "", "");
            }
        }

    }
}
