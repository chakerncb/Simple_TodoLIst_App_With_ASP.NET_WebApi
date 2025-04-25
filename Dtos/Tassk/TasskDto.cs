using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Tassk
{
    public class TasskDto
    {
         public int Id { get; set; }
         public string Title { get; set; } = string.Empty;
         public string Description { get; set; } = string.Empty;
         public int Duration  { get; set; }
         public DateTime createdAt { get; set; } = DateTime.Now;
         public DateTime updatedAt { get; set; } 

    }
}