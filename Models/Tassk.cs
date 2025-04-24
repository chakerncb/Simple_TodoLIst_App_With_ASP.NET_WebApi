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
         public string Description { get; set; } = string.Empty;
         public int Duration  { get; set; }

         public DateTime createdAt { get; set; } = DateTime.Now;
         public DateTime updatedAt { get; set; } 



         public int? UserId { get; set; }
         public User? User { get; set; }

    }
}