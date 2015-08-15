using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class Employee3
    {
        public virtual int Id { get; protected set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Salary { get; set; }
        public virtual Store Store { get; set; }
    }

    public class Product
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual IList<Store> StoresStockedIn { get; protected set; }

        public Product()
        {
            StoresStockedIn = new List<Store>();
        }
    }


    public class Store
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual IList<Product> Products { get; set; }
        public virtual IList<Employee3> Staff { get; set; }

        public Store()
        {
            Products = new List<Product>();
            Staff = new List<Employee3>();
        }

        public virtual void AddProduct(Product product)
        {
            product.StoresStockedIn.Add(this);
            Products.Add(product);
        }

        public virtual void AddEmployee(Employee3 employee)
        {
            employee.Store = this;
            Staff.Add(employee);
        }
    }
}