using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LT.EFCoreDemo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double BasePrice { get; set; }
        public double TaxRate { get; set; }
        public double DiscountRate { get; set; }

        //  Navigational properties
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }

        //  One to many
        public ICollection<ProductWarehouse> ProductWarehouseMappings { get; set; } = new HashSet<ProductWarehouse>();
    }

    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
    }

    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProductWarehouse> ProductWarehouseMappings { get; set; } = new HashSet<ProductWarehouse>();
    }


    //  Join entity
    public class ProductWarehouse
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
