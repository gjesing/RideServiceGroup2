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
    public class CreateReportModel : PageModel
    {
        public Ride Ride { get; set; }
        [BindProperty(SupportsGet = true)]
        Status status { get; set; }
        [BindProperty(SupportsGet = true)]
        string text { get; set; }
        [BindProperty(SupportsGet = true)]
        DateTime date { get; set; }
        public void OnGet(int id)
        {
            RideRepository rideRepo = new RideRepository();
            List<Ride> rides = rideRepo.GetAllRides();
            foreach (Ride ride in rides)
            {
                if (ride.Id == id)
                {
                    Ride = ride;
                }
            }
            Report report = new Report()
            {
                Ride = Ride,
                Status = status,
                Notes = text,
                ReportTime = date
            };

            ReportRepository reportRepo = new ReportRepository();
            reportRepo.CreateReport(report);
        }
    }
}