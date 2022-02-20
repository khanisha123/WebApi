using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.DAL;
using WebApi.Data.Entity;
using WebApi.Dto.Genre;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly Context _context;

        public GenreController(Context context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDto>> GetOne(int id)
        {
            var genre = await _context.genres.Include(b => b.BookGenres).ThenInclude(b => b.Book).FirstOrDefaultAsync(b => b.Id == id);

            GenreDto genreDto = new GenreDto()
            {
                Name = genre.Name,
                Books = genre.BookGenres.Select(b => b.Book.Name).ToList()
            };

            return genreDto;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetAll()
        {
            List<GenreDto> genreDtos = new List<GenreDto>();
            var genres = await _context.genres.Include(b => b.BookGenres).ThenInclude(b => b.Book).ToListAsync();

            foreach (var item in genres)
            {
                GenreDto genreDto = new GenreDto
                {
                    Name = item.Name,
                    Books = item.BookGenres.Select(b => b.Book.Name).ToList()
                };
                genreDtos.Add(genreDto);
            }

            return genreDtos;
        }
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre g)
        {
            _context.genres.Add(g);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOne", new { id = g.Id }, g);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _context.genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.genres.Remove(genre);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
