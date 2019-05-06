using System;
using System.Collections.Generic;
using System.Text;

namespace RideServiceGroup2.Entities.WeatherAPI
{
    public class WeatherInfo
    {
        public List<Weather> Weather { get; set; }
        public Main Main { get; set; }
    }
}
