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
    }
}
