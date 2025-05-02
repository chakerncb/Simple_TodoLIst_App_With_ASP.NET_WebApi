using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{

    
    public class AccountRepository : IAccountRepository
    {

        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        public AccountRepository(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager){
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;	
        }

        public async Task<NewUserDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email.ToLower());

                if (user == null)
                {
                    return null;
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

                if (result.Succeeded)
                {
                    return new NewUserDto
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = _tokenService.CreateToken(user)
                    };
                }
                else
                {
                    return null;
                }
        }

        public async Task<NewUserDto> RegisterAsync(RegisterDto registerDto, string role)
        {
            var user = new User()
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                };

                if (string.IsNullOrWhiteSpace(registerDto.Password))
                {
                    return null;
                }

                var createdUser = await _userManager.CreateAsync(user, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, role);

                    if (roleResult.Succeeded)
                    {
                        return 
                            new NewUserDto
                            {
                                UserName = user.UserName,
                                Email = user.Email,
                                Token = _tokenService.CreateToken(user)
                            };
                    }
                    else
                    {
                        return null;
                    }
                 }
                else
                {
                    var error = createdUser.Errors;
                    return null;
                }
        }
    }
}