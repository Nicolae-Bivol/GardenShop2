using System.Collections.Generic;
using System.Data.Entity;
using GardenShop2.Domain.Model;
using GardenShop2.Domain.Data;

namespace GardenShop2.Domain.Data
{
     public class ApplicationDbContext : DbContext
{
     public ApplicationDbContext() : base("GardenShop") { }

     public DbSet<Product> Products { get; set; }
     public DbSet<User> Users { get; set; }
}
}
