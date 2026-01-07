using Microsoft.AspNetCore.Mvc;
using MyApp.Dto;
using MyApp.Service;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController:ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetCategoryDto>> GetByIdAsync(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category is null) return NotFound();
            return Ok(category);
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCategoryDto dto)
        {

            if(!ModelState.IsValid) return BadRequest(ModelState);

            var res = await _categoryService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = res.Id }, dto);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateCategoryDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (dto.Id != dto.Id) return BadRequest("ID mismatch");

            try
            {
                await _categoryService.UpdateAsync(dto);
                return NoContent();
            }



            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }





















    }
}
