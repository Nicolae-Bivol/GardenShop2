using System;

namespace GardenShop2.Domain.Model
{
     public class Comment
     {
          public int Id { get; set; }
          public string Content { get; set; }
          public DateTime CreatedAt { get; set; }

          public int UserId { get; set; }
          public virtual User User { get; set; }

          public int ProductId { get; set; }
          public virtual Product Product { get; set; }
     }
}
