using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GardenShop2.Domain.Model;

namespace GardenShop2.Domain.Model
{
     public class Product
     {
          public int Id { get; set; }
          public string Category { get; set; }

          public string Name { get; set; }
          public string Description { get; set; }
          public string ImageUrl { get; set; }
          public decimal Price { get; set; }

          public string FullDescription { get; set; }
          public string PreferredEnvironment { get; set; }
          public string PlantingInstructions { get; set; }
          public string CareInstructions { get; set; }
          public virtual ICollection<User> FavoritedByUsers { get; set; }
          public virtual ICollection<Comment> Comments { get; set; }

     }
}