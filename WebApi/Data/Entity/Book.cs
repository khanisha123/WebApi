using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data.Entity
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public Author author { get; set; }
        public List<BookGenre> BookGenres { get; set; }
    }
}
