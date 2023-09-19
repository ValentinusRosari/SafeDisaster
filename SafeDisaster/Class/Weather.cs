using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeDisaster.Class
{
    internal class Weather
    {
        private string _category;
        private float _humidity;
        private float _windVelocity;
        private DateTime _time;

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
        public float Humidity
        {
            get { return _humidity; }
            set { _humidity = value; }
        }
        public float WindVelocity
        {
            get { return _windVelocity; }
            set { _windVelocity = value; }
        }
        public DateTime Time{
            get { return _time; }
            set { _time = value; }
        }
        public Weather(string category, float humidity, float windVelocity, DateTime time)
        {
            this.Category = category;
            this.Humidity = humidity;
            this.WindVelocity = windVelocity;
            this.Time = time;
        }
        public Weather GetWeather(string category, float humidity, float windVelocity, DateTime time)
        {
            Weather weather = new Weather(category, humidity, windVelocity, time);
            return weather;
        }
    }
}
