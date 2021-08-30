using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Contract.Weather
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

    public class Parent
    {
        public string Title { get; set; }
        public string Location_type { get; set; }
        public int Woeid { get; set; }
        public string Latt_long { get; set; }
    }

    public class Source
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Url { get; set; }
        public int Crawl_rate { get; set; }
    }

    public class WeatherSearchResponse
    {
        public List<ConsolidatedWeather> Consolidated_weather { get; set; }
        public DateTime Time { get; set; }
        public DateTime Sun_rise { get; set; }
        public DateTime Sun_set { get; set; }
        public string Timezone_name { get; set; }
        public Parent Parent { get; set; }
        public List<Source> Sources { get; set; }
        public string Title { get; set; }
        public string Location_type { get; set; }
        public int Woeid { get; set; }
        public string Latt_long { get; set; }
        public string Timezone { get; set; }
    }

}
