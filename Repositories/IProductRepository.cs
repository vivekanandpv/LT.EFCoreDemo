using LT.EFCoreDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LT.EFCoreDemo.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(int id);
        Task Create(Product product);
        Task Update(Product product);
        Task Delete(int id);
    }
}
