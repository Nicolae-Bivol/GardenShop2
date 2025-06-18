namespace GardenShop2.Domain.Model
{
     public class OrderItem
     {
          public int Id { get; set; }
          public int OrderId { get; set; }
          public int ProductId { get; set; }

          public string ProductName { get; set; }
          public int Quantity { get; set; }
          public decimal UnitPrice { get; set; } // NU Price!

          public virtual Order Order { get; set; }
     }
}
