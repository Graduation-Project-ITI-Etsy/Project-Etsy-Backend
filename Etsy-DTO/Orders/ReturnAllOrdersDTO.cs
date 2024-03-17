﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.Orders
{
    public class ReturnAllOrdersDTO
    {
        public int OrdersId { get; set; }
        public string? Status { get; set; }
        public string Address { get; set; }
        public double TotalPrice { get; set; }
        public DateTime? OrderedAt { get; set; }
        public DateTime? ArrivedOn { get; set; }

        public int CustomerId { get; set; }

        //>>Should I Put List or Prop From class that exist in Model ??? 

        //public CustomerDTO Customer { get; set; } // Nested DTO for Customer
        //public List<OrderItemDTO> OrderItems { get; set; } // List of nested DTOs for OrderItems
       // public PaymentsDTO Payments { get; set; } // Nested DTO for Payments


    }
}
