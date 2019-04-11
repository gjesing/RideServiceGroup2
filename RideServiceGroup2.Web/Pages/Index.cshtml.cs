using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RideServiceGroup2.Entities;

namespace RideServiceGroup2.Web.Pages
{
    public class IndexModel : PageModel
    {
        public List<Ride> rides { get; set; }
        public void OnGet()
        {

        }
    }
}