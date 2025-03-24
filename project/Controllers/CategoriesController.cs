using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Context;
using project.Models;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        ApplicationDbContext _context;
        public CategoriesController (ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var categories = _context.Categories;
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var category = _context.Categories.Find(id);
            return category== null ?NotFound():Ok(category);
        }

        [HttpPost("")]
        public IActionResult create([FromBody] Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { category.Id }, category);
        }

        [HttpPut("{id}")]
        public IActionResult create([FromRoute] int id, [FromBody] Category category)
        {
            var categoryInDb = _context.Categories.AsNoTracking().FirstOrDefault(c => c.Id == id);
            if (categoryInDb == null) return NotFound();
            category.Id = categoryInDb.Id;
            _context.Categories.Update(category);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult remove([FromRoute] int id)
        {
            var category = _context.Categories.Find(id);
            if(category==null) return NotFound();
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
