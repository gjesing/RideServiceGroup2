using System;
using System.Collections.Generic;
using System.Text;

namespace RideServiceGroup2.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public Ride Ride { get; set; }
        public Status Status { get; set; }
        public DateTime ReportTime { get; set; }
        public string Notes { get; set; }
    }
}
