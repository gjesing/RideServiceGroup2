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
    public class CreateRideModel : PageModel
    {
        [BindProperty]
        public Ride Ride { get; set; }
        [BindProperty]
        public List<RideCategory> Categories { get; set; }
        [BindProperty]
        public int CategoryId { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
            CategoryRepository categoryRepo = new CategoryRepository();
            Categories = categoryRepo.GetAllRideCategories();
        }
        public void OnPost()
        {
            CategoryRepository categoryRepo = new CategoryRepository();
            Categories = categoryRepo.GetAllRideCategories();
            Ride.Category = categoryRepo.GetCategory(CategoryId);
            RideRepository rideRepo = new RideRepository();
            rideRepo.CreateRide(Ride);
            Message = $"Forlystelsen {Ride.Name} er oprettet";
        }
    }
}