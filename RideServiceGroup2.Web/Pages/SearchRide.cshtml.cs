using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RideServiceGroup2.DAL;
using RideServiceGroup2.Entities;

namespace RideServiceGroup2.Web.Pages
{
    public class SearchRideModel : PageModel
    {
        public List<Ride> rides { get; set; } = new List<Ride>();
        [BindProperty(SupportsGet = true)]
        public string name { get; set; } = "";
        [BindProperty(SupportsGet = true)]
        public string category { get; set; } = "";
        [BindProperty(SupportsGet = true)]
        public int status { get; set; } = 4;


        public void OnGet()
        {
            if (status != 4)
            {
                RideRepository rideRepository = new RideRepository();
                rides = rideRepository.GetAllRides();

                if (name != "" && name != null)
                {
                    for (int i = rides.Count - 1; i >= 0; i--)
                    {
                        if (!rides[i].Name.ToLower().Contains(name.ToLower()))
                        {
                            rides.Remove(rides[i]);
                        }
                    }
                }
                if (category != "" && category != null)
                {
                    for (int i = rides.Count - 1; i >= 0; i--)
                    {
                        if (!rides[i].Category.Name.ToLower().Contains(category.ToLower()))
                        {
                            rides.Remove(rides[i]);
                        }
                    }
                }
            }
        }
    }
}