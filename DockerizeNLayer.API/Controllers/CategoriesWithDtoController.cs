using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DockerizeNLayer.API.Filters;
using DockerizeNLayer.Core.DTOs;
using DockerizeNLayer.Core.Models;
using DockerizeNLayer.Core.Services;
using DockerizeNLayer.Service.Services;

namespace DockerizeNLayer.API.Controllers
{
    public class CategoriesWithDtoController : CustomBaseController
    {
        private readonly IServiceWithDto<Category,CategoryDto> _categoryService;
      
        public CategoriesWithDtoController(IServiceWithDto<Category, CategoryDto> categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAction()
        {
            return CreateActionResult(await _categoryService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryDto request)
        {
            return CreateActionResult(await _categoryService.AddAsync(request));
        }

        //[HttpGet("[action]/{id}")]
        //public async Task<IActionResult> GetCategoryByIdWithProducts(int id)
        //{
        //    return CreateActionResult(await _categoryService.GetCategoryByIdWithProductsAsync(id)); 
        //}
    }
}
