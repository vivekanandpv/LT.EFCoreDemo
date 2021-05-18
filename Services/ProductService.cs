using LT.EFCoreDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.EFCoreDemo.Services
{
    public class ProductService : IProductService
    {
        public Task Create(ProductCreateViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductViewModel>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductUpdateViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
