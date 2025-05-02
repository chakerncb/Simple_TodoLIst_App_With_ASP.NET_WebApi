using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await _accountRepository.LoginAsync(loginDto);

                if (user == null)
                {
                    return Unauthorized("Invalid username or password.");
                }

                return Ok(user);
                
            } catch (Exception e){
                
                return StatusCode(500,e);
            }
        }


        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await _accountRepository.RegisterAsync(registerDto, "User");

                if (user == null)
                {
                    return BadRequest("An error occurred while registering the user.");
                }

                return Ok(user);

            } catch (Exception e)
            {
                return StatusCode(500,e);
            }
    }


    // [Authorize(Roles = "Admin")]
    // [HttpPost("Responsable/register")]

    //     public async Task<IActionResult> ResponsableRegister([FromBody] RegisterDto registerDto)
    //     {
    //         try {

    //             if (!ModelState.IsValid)
    //             {
    //                 return BadRequest(ModelState);
    //             }

    //             var user = new User()
    //             {
    //                 UserName = registerDto.Username,
    //                 Email = registerDto.Email,
    //             };

    //             if (string.IsNullOrWhiteSpace(registerDto.Password))
    //             {
    //                 return BadRequest("Password cannot be null or empty.");
    //             }

    //             var createdUser = await _userManager.CreateAsync(user, registerDto.Password);

    //             if (createdUser.Succeeded)
    //             {
    //                 var roleResult = await _userManager.AddToRoleAsync(user, "Responsable");

    //                 if (roleResult.Succeeded)
    //                 {
    //                     return Ok(
    //                         new NewUserDto
    //                         {
    //                             UserName = user.UserName,
    //                             Email = user.Email,
    //                             Token = _tokenService.CreateToken(user)
    //                         }
    //                     );
    //                 }
    //                 else
    //                 {
    //                     return StatusCode(500, roleResult.Errors);
    //                 }
    //             }
    //             else
    //             {
    //                 return StatusCode(500, createdUser.Errors);
    //             }
                                

    //         } catch (Exception e)
    //         {
    //             return StatusCode(500,e);
    //         }
    // }

    }


    
}