using System;
using System.Collections.Generic;

namespace DiscInventory.Models
{
    public class Disc
    {
        public int Id { get; set; }
        public int SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberInStock { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOrdered { get; set; }

        // Navigation Properties
        public int? LocationId { get; set; }
        public Location Location { get; set; }

        // Navigation Property
        public List<DiscOrder> DiscOrders { get; set; } = new List<DiscOrder>();
    }
}