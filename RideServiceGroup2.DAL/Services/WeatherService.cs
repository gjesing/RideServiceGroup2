using Newtonsoft.Json;
using RideServiceGroup2.Entities.WeatherAPI;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RideServiceGroup2.DAL.Services
{
    public class WeatherService
    {
        public WeatherInfo GetWeatherInfo(string cityName, string countryCode)
        {
            string json;
            using (WebClient webClient = new WebClient())
            {
                json = webClient.DownloadString($"http://api.openweathermap.org/data/2.5/weather?q={cityName},{countryCode}&appid=be3af3fd5849838c549f1d557af0e382&units=metric");
            }
            return JsonConvert.DeserializeObject<WeatherInfo>(json);
        }
    }
}
