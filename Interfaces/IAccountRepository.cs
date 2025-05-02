using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Models;

namespace api.Interfaces
{
    public interface IAccountRepository
    {
        Task<NewUserDto> RegisterAsync(RegisterDto registerDto, string role);
        Task<NewUserDto> LoginAsync(LoginDto loginDto);
        
    }
}