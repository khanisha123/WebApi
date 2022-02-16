using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto.ProductDto
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool isDelete { get; set; }
    }
}
