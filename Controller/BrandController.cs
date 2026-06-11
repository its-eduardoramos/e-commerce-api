using api.Dtos;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [Route("api/brand")]
  [ApiController]
  [Authorize]
  public class BrandController : ControllerBase
  {
    private readonly IBrandRepository _brandRepo;
    public BrandController(IBrandRepository brandRepo)
    {
      _brandRepo = brandRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var brands = await _brandRepo.GetAllAsync();
      return Ok(brands.Select(b => b.ToResponse()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var brand = await _brandRepo.GetByIdAsync(id);
      if(brand is null) return NotFound();
      return Ok(brand.ToResponse());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBrandRequest brandDto)
    {
      var brand = brandDto.ToEntity();
      var createdBrand = await _brandRepo.CreateAsync(brand);
      return CreatedAtAction(
        nameof(GetById),
        new { id = createdBrand.Id },
        createdBrand.ToResponse()
      );
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBrandRequest updateDto)
    {
      var updatedBrand = await _brandRepo.UpdateAsync(id, updateDto);
      if (updatedBrand is null) return NotFound();
      return Ok(updatedBrand.ToResponse());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      var deletedBrand = await _brandRepo.DeleteAsync(id);
      if (deletedBrand is null) return NotFound();
      return NoContent();
    }
  }
}