using LT.EFCoreDemo.Data;
using LT.EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.EFCoreDemo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventoryContext _context;

        public ProductRepository(InventoryContext context)
        {
            _context = context;
        }

        public async Task Create(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var productDb = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productDb != null)
            {
                _context.Remove(productDb);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Update(Product product)
        {
            var productDb = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (productDb != null)
            {
                //  map the properties
                productDb.Name = product.Name;
                productDb.TaxRate = product.TaxRate;
                productDb.DiscountRate = product.DiscountRate;
                productDb.BasePrice = product.BasePrice;
                productDb.Category = product.Category;

                await _context.SaveChangesAsync();
            }
        }
    }
}
