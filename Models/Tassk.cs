using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Tassk
    {
         public int Id { get; set; }
         public string Title { get; set; } = string.Empty;
         public int TaskListId { get; set; }
         public string Description { get; set; } = string.Empty;
         public DateTime Deadline { get; set; }
         public bool IsCompleted { get; set; } = false;
         public bool IsDeleted { get; set; } = false;

         public DateTime createdAt { get; set; } = DateTime.Now;
         public DateTime updatedAt { get; set; } 

         public TaskList? TaskList { get; set; }

    }
}