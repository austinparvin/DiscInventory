using System;

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
        public DateTime? DateOrdered { get; set; }
    }
}