using api.Dtos;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [Route("api/product")]
  [ApiController]
  [Authorize]
  public class ProductController : ControllerBase
  {
    private readonly IProductRepository _productRepo;
    private readonly IProductCategoryRepository _productCategoryRepo;
    public ProductController(IProductRepository productRepo, IProductCategoryRepository productCategoryRepo)
    {
      _productRepo = productRepo;
      _productCategoryRepo = productCategoryRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var products = await _productRepo.GetAllAsync();
      return Ok(products.Select(p => p.ToResponse()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var existingProduct = await _productRepo.GetByIdAsync(id);
      if (existingProduct is null) return NotFound();
      return Ok(existingProduct.ToResponse());
    }

    //falta mostrar la info de los categorias
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest productDto)
    {
      var product = productDto.ToEntity();
      var createdProduct = await _productRepo.CreateAsync(product);
      
      foreach(var categoryId in productDto.CategoryIds)
      {
        var productCatgegory = new ProductCategory
        {
          ProductId = createdProduct.Id,
          CategoryId = categoryId
        };

        await _productCategoryRepo.AddAsync(productCatgegory);
      }

      await _productCategoryRepo.SaveChangesAsync();

      return CreatedAtAction(
        nameof(GetById),
        new { id = createdProduct.Id },
        createdProduct.ToResponse()
      );
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductRequest updateDto)
    {
      var updatedProduct = await _productRepo.UpdateAsync(id, updateDto);
      if (updatedProduct is null) return NotFound();
      return Ok(updatedProduct.ToResponse());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      var deletedProduct = await _productRepo.DeleteAsync(id);
      if(deletedProduct is null) return NotFound();
      return NoContent();
    }
  }
}