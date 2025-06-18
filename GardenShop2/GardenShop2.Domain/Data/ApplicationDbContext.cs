using System.Collections.Generic;
using System.Data.Entity;
using GardenShop2.Domain.Model;

namespace GardenShop2.Domain.Data
{
     public class ApplicationDbContext : DbContext
     {
          public ApplicationDbContext() : base("GardenShop") { }

          public DbSet<Product> Products { get; set; }
          public DbSet<User> Users { get; set; }
          public DbSet<Order> Orders { get; set; }
          public DbSet<OrderItem> OrderItems { get; set; }

          protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
               // Relația many-to-many: un user poate avea mai multe favorite, un produs poate fi în favoritele mai multor useri
               modelBuilder.Entity<User>()
                   .HasMany(u => u.FavoriteProducts)
                   .WithMany(p => p.FavoritedByUsers)
                   .Map(m =>
                   {
                        m.ToTable("UserFavorites"); // numele tabelului din DB
                        m.MapLeftKey("UserId");
                        m.MapRightKey("ProductId");
                   });

               base.OnModelCreating(modelBuilder);
          }
     }
}
