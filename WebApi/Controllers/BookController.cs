using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.DAL;
using WebApi.Data.Entity;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly Context _context;
        public BookController(Context context)
        {
            _context = context;
        }
        public List<Book> Get()
        {
            return _context.books.ToList();
        }
        [HttpPost("Create")]
        public IActionResult Create(Book book)
        {
            var per = _context.authors.Where(x => x.Id == book.author.Id).FirstOrDefault();
            book.author = per;
            _context.books.Add(book);
            _context.SaveChanges();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Book dbBook = _context.books.FirstOrDefault(p => p.Id == id);
            if (dbBook == null) return NotFound();
            _context.Remove(dbBook);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpPost("Update")]
        public IActionResult Update(int? id, Book book)
        {
            if (id == null) 
            {
                return NotFound();
            } 
            Book dbBook =  _context.books.Find(id);
            dbBook.Name = book.Name;
            var per = _context.authors.Where(x => x.Id == book.author.Id).FirstOrDefault();
            book.author = per;
            dbBook.author = book.author;

             _context.SaveChanges();
            return StatusCode(201);

        }
    }
}
