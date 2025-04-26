using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Fname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; 
        public string Password { get; set; } = string.Empty; 

        // public List<Tassk> Tasks { get; set; } = new List<Tassk>();
        public ICollection<TaskList> TaskLists { get; set; } = new List<TaskList>();

    }
}