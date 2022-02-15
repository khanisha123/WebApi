﻿using Microsoft.AspNetCore.Http;
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
    public class ProductController : ControllerBase
    {
        private readonly Context _context;
        public ProductController(Context context)
        {
            _context = context;
        }
        
        [HttpGet]
        public List<Product> Get() 
        {
            return _context.Products.ToList();
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetOne(int id) 
        {
            
            Product product = _context.Products.FirstOrDefault(x=>x.Id == id);
            if (product == null)
            {
                return StatusCode(404);
            }
            return StatusCode(200,product);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {


            _context.Products.Add(product);
            _context.SaveChanges();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,Product product)
        {

            Product dbproduct = _context.Products.FirstOrDefault(x=>x.Id == product.Id);
            if (dbproduct ==null)
            {
                return NotFound();
            }
            dbproduct.Name = product.Name;
            dbproduct.Price = product.Price;
            _context.SaveChanges();
            return StatusCode(200);


        }

    }
}
