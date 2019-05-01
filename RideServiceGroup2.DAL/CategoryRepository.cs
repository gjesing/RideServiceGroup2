﻿using RideServiceGroup2.Entities;
using System.Collections.Generic;
using System.Data;

namespace RideServiceGroup2.DAL
{
    public class CategoryRepository : BaseRepository
    {
        public List<RideCategory> GetAllRideCategories()
        {
            List<RideCategory> categories = new List<RideCategory>();
            DataTable categoriesTable = ExecuteQuery("SELECT * FROM RideCategories");
            foreach (DataRow row in categoriesTable.Rows)
            {
                int id = (int)row["RideCategoryId"];
                string name = (string)row["Name"];
                string description = (string)row["Description"];
                RideCategory category = new RideCategory()
                {
                    Id = id,
                    Name = name,
                    Description = description
                };
                categories.Add(category);
            }
            return categories;
        }
        public RideCategory GetCategory(int id)
        {
            DataTable categoriesTable = ExecuteQuery($"SELECT * FROM RideCategories WHERE RideCategoryId = {id}");
            DataRow categoriesRow = categoriesTable.Rows[0];
            int categoryId = (int)categoriesRow["RideCategoryId"];
            string name = (string)categoriesRow["Name"];
            string description = (string)categoriesRow["Description"];
            return new RideCategory()
            {
                Id = id,
                Name = name,
                Description = description
            };
        }
    }
}
