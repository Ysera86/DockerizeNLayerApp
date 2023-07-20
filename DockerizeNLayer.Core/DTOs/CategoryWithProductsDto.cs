using DockerizeNLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerizeNLayer.Core.DTOs
{
    public class CategoryWithProductsDto : CategoryDto
    {
        public ICollection<ProductDto>? Products { get; set; }
    }
}
