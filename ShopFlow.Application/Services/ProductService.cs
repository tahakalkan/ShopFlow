using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using ShopFlow.Application.DTOs;
using ShopFlow.Application.Interfaces;
using ShopFlow.Application.Responses;
using ShopFlow.Domain.Entities;


namespace ShopFlow.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IValidator<CreateProductDto> _validator;

        private readonly IValidator<UpdateProductDto> _updateValidator;

        private readonly IMapper _mapper;

        private readonly IProductRepository _productRepository;

        public ProductService(
            IProductRepository productRepository,
            IMapper mapper,
            IValidator<CreateProductDto> validator,
            IValidator<UpdateProductDto> updateValidator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _validator = validator;
            _updateValidator = updateValidator;
        }

        public async Task<ApiResponse<string>> AddProductAsync(CreateProductDto dto)
        {
            var validationResult = await _validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                throw new Exception(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            var product = _mapper.Map<Product>(dto);

            await _productRepository.AddAsync(product);

            return new ApiResponse<string>
            {
                Success = true,
                Message = "Ürün başarıyla eklendi",
                Data = null
            };
        }

        public async Task<ApiResponse<List<ProductDto>>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();

            var productDtos = _mapper.Map<List<ProductDto>>(products);

            return new ApiResponse<List<ProductDto>>
            {
                Success = true,
                Message = "Ürünler listelendi",
                Data = productDtos
            };
        }

        public async Task<ApiResponse<ProductDto>> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product is null)
            {
                throw new Exception("Ürün bulunamadı");
            }

            var productDto = _mapper.Map<ProductDto>(product);

            return new ApiResponse<ProductDto>
            {
                Success = true,
                Message = "Ürün bulundu",
                Data = productDto
            };
        }

        public async Task<ApiResponse<string>> UpdateProductAsync(int id, UpdateProductDto dto)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                throw new Exception(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            var product = await _productRepository.GetByIdAsync(id);

            if (product is null)
            {
                throw new Exception("Ürün bulunamadı");
            }

            _mapper.Map(dto, product);

            await _productRepository.UpdateAsync(product);

            return new ApiResponse<string>
            {
                Success = true,
                Message = "Ürün güncellendi",
                Data = null
            };
        }

        public async Task<ApiResponse<string>> DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product is null)
            {
                throw new Exception("Ürün bulunamadı");
            }

            await _productRepository.DeleteAsync(product);

            return new ApiResponse<string>
            {
                Success = true,
                Message = "Ürün silindi",
                Data = null
            };
        }

        public async Task<ApiResponse<List<ProductDto>>> GetPagedProductsAsync(PaginationDto paginationDto)
        {
            var products = await _productRepository.GetPagedAsync(
                paginationDto.Page,
                paginationDto.PageSize);

            var productDtos = _mapper.Map<List<ProductDto>>(products);

            return new ApiResponse<List<ProductDto>>
            {
                Success = true,
                Message = "Ürünler listelendi",
                Data = productDtos
            };
        }

        public async Task<ApiResponse<List<ProductDto>>> SearchProductsAsync(string keyword)
        {
            var products = await _productRepository.SearchAsync(keyword);

            var productDtos = _mapper.Map<List<ProductDto>>(products);

            return new ApiResponse<List<ProductDto>>
            {
                Success = true,
                Message = "Ürünler listelendi",
                Data = productDtos
            };
        }
    }
}