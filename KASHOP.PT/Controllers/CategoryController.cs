using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("")]
        public IActionResult Get() 
        { 
            return Ok( categoryService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var category = categoryService.GetById(id);
            if (category == null) { 
                return NotFound();
            }
            return Ok( category );
        }
        [HttpPost]
        public IActionResult Create([FromBody] CategoryRequest request)
        {
           var id = categoryService.Create(request);
            return CreatedAtAction(nameof(Get), new {id});

        }
        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CategoryRequest request)
        {
            var updated = categoryService.Update(id, request);
            return updated > 0 ? Ok(new { message="update successfully"} ) : NotFound();
        }
        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {
            var updated = categoryService.ToggleStatus(id);
            return updated ? Ok(new { message = "status updated" }) : NotFound(new { message = "category not found"});
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = categoryService.Delete(id);
            return deleted > 0 ? Ok(new { message="Deleted Successfully"}) : NotFound();
        }
    }
}
