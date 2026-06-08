using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShopFlow.Domain.Entities;

namespace ShopFlow.Application.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);

    Task<User?> GetByEmailAsync(string email);
}
