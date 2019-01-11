using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Classes
{
    public class CombosHelper : IDisposable
    {
        private static ECommerceContext db = new ECommerceContext();
        public static List<Departments> GetDepartments()
        {
         
        //ordenação 
        var departments = db.Departments.ToList();
        departments.Add(new Departments
            {
                DepartmentsId = 0,
                Name = "[Select Department]"
            });

           return departments = departments.OrderBy(d => d.Name).ToList();
  
        }

        public static List<City> GetCities()
        {

            //ordenação 
            var cities = db.Cities.ToList();
            cities.Add(new City
            {
                DepartmentsId = 0,
                Name = "[Select City]"
            });

            return cities = cities.OrderBy(d => d.Name).ToList();

        }

        public static List<Company> GetCompanies()
        {

            //ordenação 
            var companies = db.Companies.ToList();
            companies.Add(new Company
            {
                CompanyId = 0,
                Name = "[Select Company]"
            });

            return companies = companies.OrderBy(c => c.Name).ToList();

        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}