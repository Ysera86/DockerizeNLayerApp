using AutoMapper;
using DockerizeNLayer.Core.DTOs;
using DockerizeNLayer.Core.Models;
using DockerizeNLayer.Core.Repositories;
using DockerizeNLayer.Core.Services;
using DockerizeNLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerizeNLayer.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IGenericRepository<Category> repository, ICategoryRepository categoryRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryByIdWithProductsAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdWithProductsAsync(id);
              
            return CustomResponseDto<CategoryWithProductsDto>.Success(200, _mapper.Map<CategoryWithProductsDto>(category));
        }
    }
}
