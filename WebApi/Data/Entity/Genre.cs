using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data.Entity
{
    public class Genre :BaseEntity
    {
        public string Name { get; set; }

        public List<BookGenre> BookGenres { get; set; }
    }
}
