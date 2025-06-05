using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GardenShop2.Domain.Model;
using GardenShop2.Domain.Data;




namespace GardenShop2.Domain.Data
{
     public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
     {
          protected override void Seed(ApplicationDbContext context)
          {
               var products = new List<Product>
            {
                new Product { Name = "Apple Tree", Category = "Trees", Description = "Green apple tree", ImageUrl = "/img/AppleTree.png", Price = 25 },
                new Product { Name = "Cherry Blossom", Category = "Trees", Description = "Beautiful cherry blossom", ImageUrl = "/img/CherryBlossom.png", Price = 30 },
                new Product { Name = "Rose", Category = "Flowers", Description = "Red rose", ImageUrl = "/img/Rose.png", Price = 10 },
                new Product { Name = "Shovel", Category = "Tools", Description = "Metal shovel", ImageUrl = "/img/Shovel.png", Price = 15 }
            };

               context.Products.AddRange(products);
               context.SaveChanges();
          }
     }
}