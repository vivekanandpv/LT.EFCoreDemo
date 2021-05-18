using LT.EFCoreDemo.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LT.EFCoreDemo.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> Get();
        Task<ProductViewModel> Get(int id);
        Task Create(ProductCreateViewModel viewModel);
        Task Update(ProductUpdateViewModel viewModel);
        Task Delete(int id);
    }
}
