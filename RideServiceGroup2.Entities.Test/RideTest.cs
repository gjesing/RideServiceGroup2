using RideServiceGroup2.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace RideServiceGroup2.EntitiesTest
{
    public class RideTest
    {
        [Fact]
        public void DaySinceLastShutDown_ReturnHighNumberWithNoReports()
        {
            Ride ride = new Ride();
            int expectedValue = (DateTime.Now - new DateTime()).Days;
            int actualValue = ride.DaysSinceLastShutdown();
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void DaySinceLastShutDown_ReturnHighNumberWithNoBrokenReports()
        {
            Ride ride = new Ride() { Reports = new List<Report>() { new Report() } };
            int expectedValue = (DateTime.Now - new DateTime()).Days;
            int actualValue = ride.DaysSinceLastShutdown();
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void DaySinceLastShutDown_ReturnCorrectWithOneBrokenReport()
        {
            Ride ride = new Ride() { Reports = new List<Report>() { new Report() { Status = Status.Broken, ReportTime = DateTime.Now.AddDays(-5) } } };
            int expectedValue = (DateTime.Now - ride.Reports[ride.Reports.Count - 1].ReportTime).Days;
            int actualValue = ride.DaysSinceLastShutdown();
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void DaySinceLastShutDown_ReturnCorrectWithMultipleBrokenReports()
        {
            Ride ride = new Ride() { Reports = new List<Report>() { new Report() { Status = Status.Broken, ReportTime = DateTime.Now.AddDays(-10) }, new Report() { Status = Status.Broken, ReportTime = DateTime.Now.AddDays(-5) } } };
            int expectedValue = (DateTime.Now - ride.Reports[ride.Reports.Count - 1].ReportTime).Days;
            int actualValue = ride.DaysSinceLastShutdown();
            Assert.Equal(expectedValue, actualValue);
        }
    }
}
