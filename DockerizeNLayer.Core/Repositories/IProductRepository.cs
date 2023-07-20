using DockerizeNLayer.Core.Models;
using System.Linq.Expressions;

namespace DockerizeNLayer.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product> 
    {       
        Task<List<Product>> GetProductsWithCategoryAsync(); 
    }
}
