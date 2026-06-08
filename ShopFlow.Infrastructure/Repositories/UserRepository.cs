using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopFlow.Application.Interfaces;
using ShopFlow.Domain.Entities;
using ShopFlow.Infrastructure.Data;

namespace ShopFlow.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ShopFlowDbContext _context;

    public UserRepository(ShopFlowDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Email == email);
    }
}
