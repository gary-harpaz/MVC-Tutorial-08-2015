using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace Lab1.Models
{
    public class Employee3Map:ClassMap<Employee3>
    {
        public Employee3Map()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Salary);
            References(x => x.Store,"StoreId");
            Table("employees");
        }
    }


    public class StoreMap : ClassMap<Store>
    {
        public StoreMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasMany(x => x.Staff).KeyColumn("StoreId")
              .Inverse()
              .Cascade.All();
            HasManyToMany(x => x.Products)
             .Cascade.All()
             .Table("store_product");
        }
    }


    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Price);
            Table("stores");
            HasManyToMany(x => x.StoresStockedIn)
              .Cascade.All()
              .Inverse()
              .Table("store_product");
        }
    }
}