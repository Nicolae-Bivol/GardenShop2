﻿namespace GardenShop2.Domain.Model
{
     public class CheckoutViewModel
     {
          public string FullName { get; set; }
          public string Address { get; set; }
          public string PhoneNumber { get; set; }
          public string Email { get; set; }
          public string PaymentMethod { get; set; } // "Card" sau "Cash"
     }
}
