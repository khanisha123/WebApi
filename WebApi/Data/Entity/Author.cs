using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data.Entity
{
    public class Author :BaseEntity
    {
        public int Name { get; set; }
        public IList<Book> books { get; set; }
    }
}
