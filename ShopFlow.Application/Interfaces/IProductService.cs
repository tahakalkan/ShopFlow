using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopFlow.Application.DTOs;
using ShopFlow.Domain.Entities;
using ShopFlow.Application.Responses;

namespace ShopFlow.Application.Interfaces
{
    public interface IProductService
    {
        Task<ApiResponse<string>> AddProductAsync(CreateProductDto dto);

        Task<ApiResponse<List<ProductDto>>> GetAllProductsAsync();

        Task<ApiResponse<ProductDto>> GetProductByIdAsync(int id);

        Task<ApiResponse<string>> UpdateProductAsync(int id, UpdateProductDto dto);

        Task<ApiResponse<string>> DeleteProductAsync(int id);

        Task<ApiResponse<List<ProductDto>>> GetPagedProductsAsync(PaginationDto paginationDto);

        Task<ApiResponse<List<ProductDto>>> SearchProductsAsync(string keyword);
    }


}
