using System.Collections.Generic;

namespace GardenShop2.Domain.Model
{
     public class OrderDisplayViewModel
     {
          public int OrderId { get; set; }
          public string Username { get; set; }
          public List<OrderItemDisplay> Items { get; set; }
     }

     public class OrderItemDisplay
     {
          public string ProductName { get; set; }
          public int Quantity { get; set; }
          public decimal PricePerUnit { get; set; }
     }
}
