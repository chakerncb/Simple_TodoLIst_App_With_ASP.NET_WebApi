using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {

        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {


            
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole{Id = "1a2b3c4d-0000-0000-0000-000000000001", Name = "Admin" , NormalizedName = "ADMIN" },
                new IdentityRole{Id = "1a2b3c4d-0000-0000-0000-000000000002", Name = "User" , NormalizedName = "USER" },
                new IdentityRole{Id = "1a2b3c4d-0000-0000-0000-000000000003", Name = "Responsable" , NormalizedName = "RESPONSABLE" },
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }


        
    }
}