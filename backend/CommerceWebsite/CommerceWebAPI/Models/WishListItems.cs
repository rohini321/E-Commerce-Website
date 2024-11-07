using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceWebAPI.Models
{
    public class WishListItems
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Items")]
        public int ItemId { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; } 
    }
}
