using LT.EFCoreDemo.Models;
using LT.EFCoreDemo.Repositories;
using LT.EFCoreDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace LT.EFCoreDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(ProductCreateViewModel viewModel)
        {
            await _repository.Create(ToProduct(viewModel));
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<ProductViewModel>> Get()
        {
            return (await _repository.Get()).Select(p => ToViewModel(p));

        }

        public async Task<ProductViewModel> Get(int id)
        {
            var productDb = await _repository.Get(id);

            if (productDb != null)
            {
                return ToViewModel(productDb);
            }
            else
            {
                return null;
            }
        }

        public async Task Update(ProductUpdateViewModel viewModel)
        {
            await _repository.Update(ToProduct(viewModel));
        }

        private Product ToProduct(ProductUpdateViewModel viewModel)
        {
            return new Product
            {
                BasePrice = viewModel.BasePrice,
                Category = viewModel.Category,
                DiscountRate = viewModel.DiscountRate,
                Name = viewModel.Name,
                TaxRate = viewModel.TaxRate,
                Id = viewModel.Id,
            };
        }

        private Product ToProduct(ProductCreateViewModel viewModel)
        {
            return new Product
            {
                BasePrice = viewModel.BasePrice,
                Category = viewModel.Category,
                DiscountRate = viewModel.DiscountRate,
                Name = viewModel.Name,
                TaxRate = viewModel.TaxRate,
            };
        }

        private ProductViewModel ToViewModel(Product product)
        {
            return new ProductViewModel
            {
                BasePrice = product.BasePrice,
                Category = product.Category,
                DiscountRate = product.DiscountRate,
                Name = product.Name,
                TaxRate = product.TaxRate,
                Id = product.Id,
                TotalPrice = GetTotalPrice(product.BasePrice, product.TaxRate, product.DiscountRate)
            };
        }

        private double GetTotalPrice(double basePrice, double taxRate, double discountRate)
        {
            var effectivePrice = basePrice - (basePrice * discountRate);
            return effectivePrice + (effectivePrice * taxRate);
        }
    }
}
