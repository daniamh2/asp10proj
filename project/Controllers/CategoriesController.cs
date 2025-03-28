using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Context;
using project.Models;
using project.Services;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategory_services categoryServices) : ControllerBase
    {
        private readonly ICategory_services categoryServices = categoryServices;
        
        [HttpGet("")]
        public IActionResult GetAll()
        {
             var categories =categoryServices.GetAll();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var category = categoryServices.Get(c => c.Id == id);
            return category== null ?NotFound():Ok(category);
        }

        [HttpPost("")]
        public IActionResult create([FromBody] Category category)
        {
           var categoryInDb = categoryServices.Add(category);
            return CreatedAtAction(nameof(GetById), new { categoryInDb.Id }, categoryInDb);
        }

        [HttpPut("{id}")]
        public IActionResult edit([FromRoute] int id, [FromBody] Category category)
        {
            var categoryInDb = categoryServices.Edit(id,category);

            if (!categoryInDb) return NotFound();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult remove([FromRoute] int id)
        {
            var categoryInDb = categoryServices.Remove(id);

            if (!categoryInDb) return NotFound();

            return NoContent();
        }
    }
}
