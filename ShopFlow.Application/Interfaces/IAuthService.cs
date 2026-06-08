using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopFlow.Application.DTOs;
using ShopFlow.Application.Responses;

namespace ShopFlow.Application.Interfaces;

public interface IAuthService
{
    Task<ApiResponse<string>> RegisterAsync(RegisterDto dto);

    Task<ApiResponse<string>> LoginAsync(LoginDto dto);
}
