using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Services;
using TK_Project.Domain.Entities;

namespace TK_Project.Persistance.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("User ID=postgres;Password=test;Host=localhost;Port=5432;Database=TK_DB;");
            optionsBuilder.UseSqlServer("Server=localhost;Database=e_commerce_tk;TrustServerCertificate=true;integrated security=true");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users  { get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<Capability> Capabilities { get; set; }

    }
}
