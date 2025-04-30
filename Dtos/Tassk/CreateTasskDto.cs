using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.Tassk
{
    public class CreateTasskDto
    {
        [Required]
         public int TaskListId { get; set; }

        [Required]
        [MinLength(3 , ErrorMessage = "Title must be at least 3 characters long")]
        [MaxLength(100 , ErrorMessage = "Title must be at most 100 characters long")]
         public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(10 , ErrorMessage = "Description must be at least 10 characters long")]
        [MaxLength(255 , ErrorMessage = "Description must be at most 255 characters long")]
         public string Description { get; set; } = string.Empty;
         public DateTime Deadline  { get; set; }
         public bool IsCompleted { get; set; } = false;
         public bool IsDeleted { get; set; } = false;
         public DateTime createdAt { get; set; } = DateTime.Now;
         public DateTime updatedAt { get; set; }
    }
}