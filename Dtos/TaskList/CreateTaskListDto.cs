using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.TaskList
{
    public class CreateTaskListDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [MinLength(10 , ErrorMessage = "Name cannot be longer than 10 characters.")]
        [MaxLength(100 , ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
    }
}