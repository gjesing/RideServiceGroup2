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
        public List<RideCategory> rideCategories { get; set; } = new List<RideCategory>();
        [BindProperty(SupportsGet = true)]
        public string name { get; set; } = "";
        [BindProperty(SupportsGet = true)]
        public string category { get; set; } = "";
        [BindProperty(SupportsGet = true)]
        public string status { get; set; } = "";


        public void OnGet()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            rideCategories = categoryRepository.GetAllRideCategories();

            if (status != "")
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
                if (category != "all")
                {
                    for (int i = rides.Count - 1; i >= 0; i--)
                    {
                        if (rides[i].Category.Name != category)
                        {
                            rides.Remove(rides[i]);
                        }
                    }
                }
                if (status != "all" )
                {
                    for(int i = rides.Count - 1; i >= 0; i--)
                    {
                        if (!rides[i].Status.ToString().Contains(status))
                        {
                            rides.Remove(rides[i]);
                        }
                    }
                }
            }
        }
    }
}