using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto.Genre
{
    public class GenreDto
    {
        public string Name { get; set; }
        public List<string> Books { get; set; }
    }
}
