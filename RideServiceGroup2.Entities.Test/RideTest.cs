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

        [Fact]
        public void NumberOfShutDowns_Return0WithNoReports()
        {
            Ride ride = new Ride();
            int expectedValue = 0;
            int actualValue = ride.NumberOfShutdowns();
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void NumberOfShutDowns_Return0WithNoBrokenReports()
        {
            Ride ride = new Ride() { Reports = new List<Report>() { new Report() } };
            int expectedValue = 0;
            int actualValue = ride.NumberOfShutdowns();
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void NumberOfShutDowns_Return1WithBrokenReport()
        {
            Ride ride = new Ride() { Reports = new List<Report>() { new Report() { Status = Status.Broken } } };
            int expectedValue = 1;
            int actualValue = ride.NumberOfShutdowns();
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void NumberOfShutDowns_ReturnCorrectWithMultipleBrokenReports()
        {
            Ride ride = new Ride() { Reports = new List<Report>() { new Report() { Status = Status.Broken }, new Report() { Status = Status.Broken } } };
            int ExpectedValue = 2;
            int actualValue = ride.NumberOfShutdowns();
            Assert.Equal(ExpectedValue, actualValue);
        }
    }
}
