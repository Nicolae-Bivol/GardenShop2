﻿namespace GardenShop2.Domain.Model
{
     public class OrderItem
     {
          public int Id { get; set; }

          public int OrderId { get; set; }
          public virtual Order Order { get; set; } // Relație spre Order

          public int ProductId { get; set; }
          public virtual Product Product { get; set; } // 🔥 Relație spre Product

          public string ProductName { get; set; }
          public int Quantity { get; set; }
          public decimal UnitPrice { get; set; }
     }
}
