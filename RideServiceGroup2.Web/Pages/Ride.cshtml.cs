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
    public class RideModel : PageModel
    {
        public Ride Ride { get; set; }
        public IActionResult OnGet(int id)
        {
            RideRepository rideRepo = new RideRepository();
            List<Ride> rides = rideRepo.GetAllRides();
            foreach (Ride ride in rides)
            {
                if (ride.Id == id)
                {
                    Ride = ride;
                    break;
                }
            }
            return Page();
        }
        public void OnPostDelete(int id)
        {
            RideRepository rideRepo = new RideRepository();
            List<Ride> rides = rideRepo.GetAllRides();
            foreach (Ride ride in rides)
            {
                if (ride.Id == id)
                {
                    Ride = ride;
                    break;
                }
            }
        }

        public IActionResult OnGetJson()
        {
            RideRepository rideRepo = new RideRepository();
            Ride = rideRepo.GetAllRides().First();
            return new JsonResult(Ride);
        }
    }
}