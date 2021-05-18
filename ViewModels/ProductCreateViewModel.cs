using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LT.EFCoreDemo.ViewModels
{
    public class ProductCreateViewModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double BasePrice { get; set; }
        public double TaxRate { get; set; }
        public double DiscountRate { get; set; }
    }
}
