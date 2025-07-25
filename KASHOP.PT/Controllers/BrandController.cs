using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(brandService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var brand = brandService.GetById(id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }
        [HttpPost]
        public IActionResult Create([FromBody] BrandRequest request)
        {
            var id = brandService.Create(request);
            return CreatedAtAction(nameof(Get), new { id });

        }
        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] BrandRequest request)
        {
            var updated = brandService.Update(id, request);
            return updated > 0 ? Ok(new { message = "update successfully" }) : NotFound();
        }
        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {
            var updated = brandService.ToggleStatus(id);
            return updated ? Ok(new { message = "status updated" }) : NotFound(new { message = "brand not found" });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = brandService.Delete(id);
            return deleted > 0 ? Ok(new { message = "Deleted Successfully" }) : NotFound();
        }
    }
}
