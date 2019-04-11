using RideServiceGroup2.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RideServiceGroup2.DAL
{
    class ReportRepository : BaseRepository
    {
        public List<Report> GetReportsFor(int id)
        {
            List<Report> reports = new List<Report>();

            string sql = $"SELECT * FROM Reports WHERE RideId = {id} ORDER BY ReportTime DESC";

            DataTable reportsTable = ExecuteQuery(sql);
            foreach (DataRow row in reportsTable.Rows)
            {
                int reportId = (int)row["ReportId"];
                Status status = (Status)row["Status"];
                DateTime reportTime = (DateTime)row["reportTime"];
                string notes = (string)row["Notes"];

                Report report = new Report()
                {
                    Id = reportId,
                    Status = status,
                    ReportTime = reportTime,
                    Notes = notes
                };
            }

            return reports;
        }
    }
}
