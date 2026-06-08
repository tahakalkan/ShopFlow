using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using ShopFlow.Application.DTOs;
using ShopFlow.Application.Interfaces;
using ShopFlow.Application.Responses;
using ShopFlow.Domain.Entities;

namespace ShopFlow.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;

    public AuthService(
    IUserRepository userRepository,
    IMapper mapper,
    ITokenService tokenService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _tokenService = tokenService;
    }

    public async Task<ApiResponse<string>> RegisterAsync(RegisterDto dto)
    {
        var user = _mapper.Map<User>(dto);

        user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        await _userRepository.AddAsync(user);

        return new ApiResponse<string>
        {
            Success = true,
            Message = "Kullanıcı başarıyla oluşturuldu",
            Data = null
        };
    }


    public async Task<ApiResponse<string>> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);

        if (user is null)
        {
            throw new Exception("Kullanıcı bulunamadı");
        }

        if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
        {
            throw new Exception("Şifre hatalı");
        }

        var token = _tokenService.CreateToken(user);

        return new ApiResponse<string>
        {
            Success = true,
            Message = "Giriş başarılı",
            Data = token
        };
    }
}
