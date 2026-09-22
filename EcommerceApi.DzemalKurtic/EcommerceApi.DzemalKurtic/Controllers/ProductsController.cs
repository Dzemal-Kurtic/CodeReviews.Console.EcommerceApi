using EcommerceApi.DzemalKurtic.DTOs.Product.Request;
using EcommerceApi.DzemalKurtic.DTOs.Product.Response;
using EcommerceApi.DzemalKurtic.Mappings;
using EcommerceApi.DzemalKurtic.Models;
using EcommerceApi.DzemalKurtic.Repositories.CategoryRepo;
using EcommerceApi.DzemalKurtic.Repositories.ProductRepo;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.DzemalKurtic.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    public ProductsController(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<ResponseProductDto>>> GetAll()
    {
        var products = await _productRepository.GetAllAsync();
        var responseDtos = products.Select(p => p.ToResponseDto());
        return Ok(responseDtos);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ResponseProductDto>> GetById(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null)
        {
            return NotFound();
        }
        return Ok(product.ToResponseDto());
    }

    [HttpPost]
    public async Task<ActionResult<ResponseProductDto>> Create(CreateProductDto productDto)
    {
        var category = await _categoryRepository.GetByIdAsync(productDto.CategoryId);
        if (category is null)
        {
            return BadRequest("Category does not exist");
        }
        var product = new Product { Name = productDto.Name, Price = productDto.Price, CategoryId = productDto.CategoryId };
        await _productRepository.AddAsync(product);
        var newProduct = await _productRepository.GetByIdAsync(product.Id);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, newProduct!.ToResponseDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var isDeleted = await _productRepository.SoftDeleteAsync(id);
        if (!isDeleted)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult> Update(int id, UpdateProductDto productDto)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null)
        {
            return NotFound();
        }
        var category = await _categoryRepository.GetByIdAsync(productDto.CategoryId);
        if (category is null)
        {
            return BadRequest("Category does not exist");
        }
        product.Name = productDto.Name;
        product.Price = productDto.Price;
        product.CategoryId = productDto.CategoryId;
        await _productRepository.UpdateAsync(product);
        return NoContent();
    }
}
