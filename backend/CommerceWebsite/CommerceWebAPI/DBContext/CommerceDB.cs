using CommerceWebAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace CommerceWebAPI.DBContext
{
    public class CommerceDB:DbContext
    {
        public CommerceDB(DbContextOptions options):base(options) 
        { 
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Items> Items { get; set; }
       public DbSet<WishListItems> WishListItems { get; set;}
    }
}
