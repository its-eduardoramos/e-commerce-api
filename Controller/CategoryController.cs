using api.Dtos;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [Route("api/category")]
  [ApiController]
  [Authorize]
  public class CategoryController : ControllerBase
  {
    private readonly ICategoryRepository _categoryRepo;
    public CategoryController(ICategoryRepository categoryRepository)
    {
      _categoryRepo  = categoryRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var categories = await _categoryRepo.GetAllAsync();
      return Ok(categories.Select(c => c.ToResponse()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var category = await _categoryRepo.GetByIdAsync(id);
      if (category is null) return NotFound();
      return Ok(category.ToResponse());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest categoryDto)
    {
      var category = categoryDto.ToEntity();
      var createdCategory = await _categoryRepo.CreateAsync(category);
      return CreatedAtAction(
        nameof(GetById),
        new { id = createdCategory.Id },
        createdCategory.ToResponse()
      );
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequest updateDto)
    {
      var updatedCategory = await _categoryRepo.UpdateAsync(id, updateDto);
      if (updatedCategory is null) return NotFound();
      return Ok(updatedCategory.ToResponse());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      var deletedCategory = await _categoryRepo.DeleteAsync(id);
      if (deletedCategory is null) return NotFound();
      return NoContent();
    }
  }
}