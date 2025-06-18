using System;
using System.Collections.Generic;

namespace GardenShop2.Domain.Model
{
     public class Order
     {
          public int Id { get; set; }

          public int UserId { get; set; }
          public virtual User User { get; set; } // 🔥 Relație către User

          public DateTime PlacedAt { get; set; }
          public decimal TotalAmount { get; set; }

          public virtual List<OrderItem> OrderItems { get; set; }

          public string ShippingAddress { get; set; }
          public string Phone { get; set; }
          public string Email { get; set; }
          public string PaymentMethod { get; set; }
     }
}
