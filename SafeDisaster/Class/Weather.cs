using RestSharp;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace SafeDisaster.Class
{
    internal class Weather
    {
        private string _category;
        private string _humidity;
        private string _time;
        private string _tempC;
        private string _tempF;

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
        public string Humidity
        {
            get { return _humidity; }
            set { _humidity = value; }
        }
        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }
        public string TempC
        {
            get { return _tempC; }
            set { _tempC = value; }
        }
        public string TempF
        {
            get { return _tempF; }
            set { _tempF = value; }
        }
        public Weather(string time, string category, string humidity, string tempC, string tempF)
        {
            this.Time = time;
            this.Category = category;
            this.Humidity = humidity;
            this.TempC = tempC;
            this.TempF = tempF;
        }
        public static List<string> GetLocationList()
        {
            List<string> locationList = new List<string>();
            var client = new RestClient("https://ibnux.github.io/BMKG-importer/cuaca/wilayah.json");
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);
            JsonArray locationListArray = (JsonArray)SimpleJson.DeserializeObject(response.Content);
            foreach(JsonObject location in locationListArray)
            {
                locationList.Add((string)location["kota"]);
            }
            return locationList;
        }
        public static string GetLocationId(string city)
        {
            string idLocation = "-1";
            var client = new RestClient("https://ibnux.github.io/BMKG-importer/cuaca/wilayah.json");
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);
            JsonArray locationListArray = (JsonArray)SimpleJson.DeserializeObject(response.Content);
            foreach(JsonObject location in locationListArray)
            {
                if (((string)location["kota"]) == city)
                {
                    idLocation = (string)location["id"];
                    break;
                }
            }
            return idLocation;
        }
        public static List<Weather> GetWeatherList(string idLocation)
        {
            List<Weather> weatherList = new List<Weather>();
            var client = new RestClient($"https://ibnux.github.io/BMKG-importer/cuaca/{idLocation}.json");
            var request = new RestRequest(Method.GET);

            try
            {
                IRestResponse response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    JsonArray weatherListArray = (JsonArray)SimpleJson.DeserializeObject(response.Content);

                    foreach (JsonObject weatherJson in weatherListArray)
                    {
                        Weather weather  = new Weather(
                            Convert.ToString(weatherJson.TryGetValue("jamCuaca", out var jamCuaca) ? jamCuaca : ""),
                            Convert.ToString(weatherJson.TryGetValue("cuaca", out var cuaca) ? cuaca : ""),
                            Convert.ToString(weatherJson.TryGetValue("humidity", out var humidity) ? humidity : ""),
                            Convert.ToString(weatherJson.TryGetValue("tempC", out var tempC) ? tempC : ""),
                            Convert.ToString(weatherJson.TryGetValue("tempF", out var tempF) ? tempF : "")
                        );

                        weatherList.Add(weather);
                    }
                }
                else
                {
                    weatherList.Add(new Weather($"Error: Kode status HTTP {response.StatusCode}", "", "", "", ""));
                }
            }
            catch (Exception ex)
            {
                weatherList.Add(new Weather($"Error: {ex.Message}", "", "", "", ""));
            }

            return weatherList;
        }
    }
}

