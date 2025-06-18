using System.Collections.Generic;
using System;

namespace GardenShop2.Domain.Model
{
     public class Order
     {
          public int Id { get; set; }
          public int UserId { get; set; }
          public DateTime PlacedAt { get; set; } // corect
          public decimal TotalAmount { get; set; }
          public virtual List<OrderItem> OrderItems { get; set; } // corect
          public string ShippingAddress { get; set; }
          public string Phone { get; set; }
          public string Email { get; set; }
          public string PaymentMethod { get; set; }
     }
}