using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopFlow.Domain.Entities;

namespace ShopFlow.Application.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);

        Task<List<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int id);

        Task UpdateAsync(Product product);

        Task DeleteAsync(Product product);

        Task<List<Product>> GetPagedAsync(int page, int pageSize);

        Task<List<Product>> SearchAsync(string keyword);
    }
}
