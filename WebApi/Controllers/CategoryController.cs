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
    public class CategoryController : ControllerBase
    {
        private readonly Context _context;
        public CategoryController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Category> Get()
        {
            return _context.categories.ToList();
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetOne(int id)
        {

            Category category = _context.categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return StatusCode(404);
            }
            return StatusCode(200, category);
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {


            _context.categories.Add(category);
            _context.SaveChanges();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Category category)
        {

            Category dbCategory = _context.categories.FirstOrDefault(x => x.Id == category.Id);
            if (dbCategory == null)
            {
                return NotFound();
            }
            dbCategory.Title = category.Title;
            _context.SaveChanges();
            return StatusCode(200);


        }
    }
}
