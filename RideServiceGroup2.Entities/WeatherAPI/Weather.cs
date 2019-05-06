using System;
using System.Collections.Generic;
using System.Text;

namespace RideServiceGroup2.Entities.WeatherAPI
{
    public class Weather
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string GetIconUrl()
        {
            return $"http://openweathermap.org/img/w/{Icon}.png";
        }
    }
}
