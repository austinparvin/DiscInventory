namespace DiscInventory.Models
{
    public class DiscOrder
    {
        public int Id { get; set; }

        // Disc Navigation Property
        public int DiscId { get; set; }
        public Disc Disc { get; set; }

        // Order Navigation Property
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}