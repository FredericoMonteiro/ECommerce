using ECommerce.Models;
using System;
using System.Collections;
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

        public static List<Category> GetCategories(int companyId)
        {

            //ordenação 
            var categories = db.Categories.Where(c => c.CompanyId == companyId).ToList();
            categories.Add(new Category
            {
                CategoryId = 0,
                Description = "[Select Category]"
            });

            return categories = categories.OrderBy(d => d.Description).ToList();

        }

        public static List<Tax> GetTaxes(int companyId)
        {

            //ordenação 
            var taxes = db.Taxes.Where(c => c.CompanyId == companyId).ToList();
            taxes.Add(new Tax
            {
                TaxId = 0,
                Description = "[Select Tax]"
            });

            return taxes = taxes.OrderBy(d => d.Description).ToList();

        }

        public static List<Customer> GetCustomer(int companyId)
        {

            //ordenação 
            var customer = db.Customers.Where(c => c.CompanyId == companyId).ToList();
            customer.Add(new Customer
            {
                CustomerId = 0,
                FirstName = "[Select Client]"
            });

            return customer = customer.OrderBy(d => d.FirstName).ThenBy(d => d.LastName).ToList();

        }

        public static List<Products> GetProducts(int companyId)
        {

            //ordenação 
            var product = db.Products.Where(c => c.CompanyId == companyId).ToList();
            product.Add(new Products
            {
                ProductsId = 0,
                Description = "[Select Product]"
            });

            return product = product.OrderBy(d => d.Description).ToList();

        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}