using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.Tassk
{
    public class CreateTasskDto
    {
        public string Title { get; set; } = string.Empty;
         public string Description { get; set; } = string.Empty;
         public int Duration  { get; set; }
         public DateTime createdAt { get; set; } = DateTime.Now;
         public DateTime updatedAt { get; set; }
        //  public int? UserId { get; set; } 
        //  public User? User { get; set; }
    }
}