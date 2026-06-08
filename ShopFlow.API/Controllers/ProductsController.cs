using Microsoft.AspNetCore.Mvc;
using ShopFlow.Application.Interfaces;
using ShopFlow.Domain.Entities;
using ShopFlow.Application.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace ShopFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddProduct(CreateProductDto dto)
    {
        var response = await _productService.AddProductAsync(dto);

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);

        return Ok(product);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto dto)
    {
        var response = await _productService.UpdateProductAsync(id, dto);

        return Ok(response);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var response = await _productService.DeleteProductAsync(id);

        return Ok(response);
    }

    [HttpGet("paged")]
    public async Task<IActionResult> GetPagedProducts([FromQuery] PaginationDto paginationDto)
    {
        var response = await _productService.GetPagedProductsAsync(paginationDto);

        return Ok(response);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchProducts(string keyword)
    {
        var response = await _productService.SearchProductsAsync(keyword);

        return Ok(response);
    }
}
