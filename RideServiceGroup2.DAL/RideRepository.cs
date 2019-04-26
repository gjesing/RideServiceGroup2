using RideServiceGroup2.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RideServiceGroup2.DAL
{
    public class RideRepository : BaseRepository
    {
        public List<Ride> GetAllRides()
        {
            List<Ride> rides = new List<Ride>();
            string sql = $"SELECT * FROM Rides";
            DataTable ridesTable = ExecuteQuery(sql);
            CategoryRepository categoryRepo = new CategoryRepository();
            foreach (DataRow row in ridesTable.Rows)
            {
                int id = (int)row["RideId"];
                string name = (string)row["Name"];
                string imgUrl = (string)row["ImgUrl"];
                string description = (string)row["Description"];
                int categoryId = (int)row["CategoryId"];

                Ride ride = new Ride()
                {
                    Id = id,
                    Name = name,
                    ImgUrl = imgUrl,
                    Description = description,
                    Category = categoryRepo.GetCategory(categoryId)
                };
                rides.Add(ride);
            }
            ReportRepository reportRepository = new ReportRepository();
            foreach (Ride ride in rides)
            {
                ride.Reports = reportRepository.GetReportsFor(ride.Id);
            }

            return rides;
        }
        public Ride GetRide(int id)
        {
            string sql = $"SELECT * FROM Rides WHERE RideId = {id}";

            DataTable table = ExecuteQuery(sql);
            DataRow row = table.Rows[0];
            Ride ride = new Ride()
            {
                Id = (int)row["RideId"],
                Name = (string)row["Name"],
                ImgUrl = (string)row["ImgUrl"],
                Description = (string)row["Description"],
            };
            CategoryRepository categoryRepo = new CategoryRepository();
            ride.Category = categoryRepo.GetCategory(ride.Id);

            ReportRepository reportRepo = new ReportRepository();
            ride.Reports = reportRepo.GetReportsFor(ride.Id);

            return ride;
        }
    }
}
