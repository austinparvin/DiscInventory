using System.Collections.Generic;

namespace DiscInventory.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string ManagerName { get; set; }
        public string PhoneNumber { get; set; }

        //Navigation property
        public List<Disc> Discs { get; set; } = new List<Disc>();
    }
}