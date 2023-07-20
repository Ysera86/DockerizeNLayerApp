using Microsoft.EntityFrameworkCore;
using DockerizeNLayer.Core.Models;
using DockerizeNLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerizeNLayer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    { 
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Category> GetCategoryByIdWithProductsAsync(int id)
        {
            return await _context.Categories.Include(c => c.Products).Where(c=> c.Id == id).SingleOrDefaultAsync();
        }
    }
}
