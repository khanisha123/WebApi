using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Entity;

namespace WebApi.Dto.ProductDto
{
    public class ProductReturnDto
    {
        public int TotalCount { get; set; }
        public List<ProductItemDto> Items { get; set; }
    }
}
