using EcommerceApi.DzemalKurtic.DTOs.Sale.Request;
using EcommerceApi.DzemalKurtic.DTOs.Sale.Response;
using EcommerceApi.DzemalKurtic.Mappings;
using EcommerceApi.DzemalKurtic.Models;
using EcommerceApi.DzemalKurtic.Repositories.ProductRepo;
using EcommerceApi.DzemalKurtic.Repositories.SaleRepo;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.DzemalKurtic.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;
    public SalesController(ISaleRepository saleRepository, IProductRepository productRepository)
    {
        _saleRepository = saleRepository;
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<ResponseSaleDto>>> GetAll(DateTime? from = null, DateTime? to = null)
    {

        var sales = (from.HasValue && to.HasValue)
            ? await _saleRepository.GetByDateRangeAsync(from.Value, to.Value)
            : await _saleRepository.GetAllAsync();

        var responseDto = sales.Select(s => s.ToResponseDto());
        return Ok(responseDto);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ResponseSaleDto>> GetById(int id)
    {
        var sale = await _saleRepository.GetByIdAsync(id);
        if (sale is null)
        {
            return NotFound();
        }
        return Ok(sale.ToResponseDto());
    }

    [HttpPost]
    public async Task<ActionResult<ResponseSaleDto>> Create(CreateSaleDto saleDto)
    {
        var sale = new Sale();

        foreach (var line in saleDto.Items)
        {
            var product = await _productRepository.GetByIdAsync(line.ProductId);
            if (product is null)
            {
                return BadRequest("Product does not exist");
            }

            sale.Items.Add(new SaleItem
            {
                ProductId = product.Id,
                Quantity = line.Quantity,
                SalePrice = product.Price
            });
        }

        await _saleRepository.AddAsync(sale);
        var newSale = await _saleRepository.GetByIdAsync(sale.Id);
        return CreatedAtAction(nameof(GetById), new { id = sale.Id }, newSale!.ToResponseDto());
    }
}
