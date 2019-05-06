using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RideServiceGroup2.Entities;
using RideServiceGroup2.DAL;
using RideServiceGroup2.Entities.WeatherAPI;
using RideServiceGroup2.DAL.Services;

namespace RideServiceGroup2.Web.Pages
{
    public class IndexModel : PageModel
    {
        public List<Ride> Rides { get; set; }
        public WeatherInfo Weather { get; set; }
        public void OnGet()
        {
            RideRepository rideRepository = new RideRepository();
            Rides = rideRepository.GetAllRides();
            WeatherService weatherService = new WeatherService();
            Weather = weatherService.GetWeatherInfo("Blokhus", "dk");
        }
    }
}