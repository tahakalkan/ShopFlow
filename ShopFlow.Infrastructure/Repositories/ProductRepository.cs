using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopFlow.Application.Interfaces;
using ShopFlow.Domain.Entities;
using ShopFlow.Infrastructure.Data;

namespace ShopFlow.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopFlowDbContext _context;

        public ProductRepository(ShopFlowDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetPagedAsync(int page, int pageSize)
        {
            return await _context.Products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<Product>> SearchAsync(string keyword)
        {
            return await _context.Products
                .Where(x => x.Name.Contains(keyword))
                .ToListAsync();
        }
    }
}
