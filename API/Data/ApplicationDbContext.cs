using Bn_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using My_Api.Models;
using System.Reflection.Emit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Bn_API.Data
{
    public class ApplicationDbContext:IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

       
        public DbSet<OrderHeader> orderHeader { get; set; }
        public DbSet<OrderLine> orderLine { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Products> products { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",

                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",

                }
            };
            builder.Entity<IdentityRole>().HasData(roles);


           builder.Entity<OrderHeader>()
          .HasMany(c => c.orderLines)
          .WithOne(e => e.OrderHeader);

        }


    



        }
   
}
