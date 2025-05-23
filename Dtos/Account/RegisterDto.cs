using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; } 

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Required]
        [MinLength(6 , ErrorMessage = "Password must be at least 6 characters long.")]
        public string? Password { get; set; } 
        
    }
}