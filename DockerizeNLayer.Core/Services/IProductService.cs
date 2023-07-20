using DockerizeNLayer.Core.DTOs;
using DockerizeNLayer.Core.Models;
using System.Linq.Expressions;

namespace DockerizeNLayer.Core.Services
{
    public interface IProductService : IService<Product>
    {
        //Task<List<ProductWithCategoryDto>> GetProductsWithCategory();
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategoryAsync();
    }
}
