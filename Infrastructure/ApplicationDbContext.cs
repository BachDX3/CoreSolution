using Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext:IdentityDbContext<User,Role,Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        //lop nay cho phep chi dinh cau hinh mà khong can sua lop thuc the
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18,0)");
            });
            SeedRoles(modelBuilder);
        }

        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role() {Id =Guid.NewGuid(), Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new Role() { Id = Guid.NewGuid(), Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" },
                new Role() { Id = Guid.NewGuid(), Name = "HR", ConcurrencyStamp = "3", NormalizedName = "HR" }
            );
        }
    }
}
