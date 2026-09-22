using EcommerceApi.DzemalKurtic.DTOs.Category.Request;
using EcommerceApi.DzemalKurtic.DTOs.Category.Response;
using EcommerceApi.DzemalKurtic.Mappings;
using EcommerceApi.DzemalKurtic.Models;
using EcommerceApi.DzemalKurtic.Repositories.CategoryRepo;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.DzemalKurtic.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<ResponseCategoryDto>>> GetAll()
    {
        var categories = await _categoryRepository.GetAllAsync();
        var responseDtos = categories.Select(c => c.ToResponseDto());
        return Ok(responseDtos);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ResponseCategoryDto>> GetById(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category is null)
        {
            return NotFound();
        }
        return Ok(category.ToResponseDto());
    }

    [HttpPost]
    public async Task<ActionResult<ResponseCategoryDto>> Create(CreateCategoryDto categoryDto)
    {
        var category = new Category { Name = categoryDto.Name };
        var returned = await _categoryRepository.AddAsync(category);
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, returned.ToResponseDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var hasProducts = await _categoryRepository.HasProductsAsync(id);
        if (hasProducts)
        {
            return Conflict("Category still has products");
        }
        var isDeleted = await _categoryRepository.SoftDeleteAsync(id);
        if (!isDeleted)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult> Update(int id, UpdateCategoryDto categoryDto)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if(category is null)
        {
            return NotFound();
        }
        category.Name = categoryDto.Name; 
        await _categoryRepository.UpdateAsync(category);
        return NoContent();
    }
}
