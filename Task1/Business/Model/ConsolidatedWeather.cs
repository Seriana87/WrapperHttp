using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Business.Model
{
    public class ConsolidatedWeather
    {
        public object Id { get; set; }
        public string Weather_state_name { get; set; }
        public string Weather_state_abbr { get; set; }
        public string Wind_direction_compass { get; set; }
        public DateTime Created { get; set; }
        public string Applicable_date { get; set; }
        public double Min_temp { get; set; }
        public double Max_temp { get; set; }
        public double The_temp { get; set; }
        public double Wind_speed { get; set; }
        public double Wind_direction { get; set; }
        public double Air_pressure { get; set; }
        public int Humidity { get; set; }
        public double Visibility { get; set; }
        public int Predictability { get; set; }
    }
}
