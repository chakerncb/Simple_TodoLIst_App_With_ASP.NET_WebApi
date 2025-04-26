using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.Tassk
{
    public class UpdateTasskDto
    {
         public int TaskListId { get; set; }
         public string Title { get; set; } = string.Empty;
         public string Description { get; set; } = string.Empty;
         public DateTime Deadline  { get; set; }
         public bool IsCompleted { get; set; } = false;
         public bool IsDeleted { get; set; } = false;
         public DateTime createdAt { get; set; } = DateTime.Now;
         public DateTime updatedAt { get; set; }

    }
}