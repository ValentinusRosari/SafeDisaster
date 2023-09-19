using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeDisaster.Class
{
    internal class Disaster
    {
        private string _type;
        private string _location;
        private DateTime _time;
        private string _magnitude;

        public string Type { 
            get { return _type; }
            set { _type = value; }
        }
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }
        public string Magnitude
        {
            get { return _magnitude; }
            set { _magnitude = value; }
        }
        public Disaster(string type, string location, DateTime time, string magnitude)
        {
            this.Type = type;
            this.Location = location;
            this.Time = time;
            this.Magnitude = magnitude;
        }
        public Disaster GetDisaster(string type, string location, DateTime time, string magnitude)
        {
            Disaster disaster = new Disaster(type, location, time, magnitude);
            return disaster;
        }

    }
}
