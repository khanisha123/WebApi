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
    public class AuthorController : ControllerBase
    {
        private readonly Context _context;
        public AuthorController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Author> Get()
        {
            return _context.authors.ToList();
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetOne(int id)
        {

            Author author = _context.authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                return StatusCode(404);
            }
            return StatusCode(200, author);
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {


            _context.authors.Add(author);
            _context.SaveChanges();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Author author)
        {

            Author dbAuthor = _context.authors.FirstOrDefault(x => x.Id == author.Id);
            if (dbAuthor == null)
            {
                return NotFound();
            }
            dbAuthor.Name = author.Name;
            _context.SaveChanges();
            return StatusCode(200);


        }
    }
}
