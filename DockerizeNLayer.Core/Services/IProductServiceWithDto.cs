using DockerizeNLayer.Core.DTOs;
using DockerizeNLayer.Core.Models;
using System.Linq.Expressions;

namespace DockerizeNLayer.Core.Services
{
    public interface IProductServiceWithDto : IServiceWithDto<Product, ProductDto>
    {
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategoryAsync();

        Task<CustomResponseDto<ProductDto>> AddAsync(ProductCreateDto dto);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(ProductUpdateDto dto);
    }
}
