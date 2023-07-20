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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<Product>> GetProductsWithCategoryAsync()
        {
            //Include ile anında catoreileri de çektik : Eager Loading
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }
    }
}
