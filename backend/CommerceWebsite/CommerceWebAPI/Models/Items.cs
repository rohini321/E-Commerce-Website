using System.ComponentModel.DataAnnotations;

namespace CommerceWebAPI.Models
{
    public class Items
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; } 
        public double  Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
