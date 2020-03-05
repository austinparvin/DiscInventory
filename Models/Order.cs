using System;
using System.Collections.Generic;

namespace DiscInventory.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime PlacedAt { get; set; } = DateTime.Now;

        // Navigation Property
        public List<DiscOrder> DiscOrders { get; set; } = new List<DiscOrder>();
    }
}