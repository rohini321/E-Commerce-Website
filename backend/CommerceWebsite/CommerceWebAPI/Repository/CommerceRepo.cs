using CommerceWebAPI.DBContext;
using CommerceWebAPI.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace CommerceWebAPI.Repository
{
    public class CommerceRepo : ICommerceRepo
    {
        // private readonly IConfiguration _configuration;
        //public readonly SqlConnection _conn;
        public CommerceDB _db;

        public CommerceRepo(CommerceDB db)
        {
            _db = db;
            
        } 
        public string ValidateUser(string Phno, string password)
        {
            Users CurrentUser = _db.Users.Where(e => e.Phno == Phno && e.password == password).FirstOrDefault();
            if(CurrentUser!=null)
            {
                return CurrentUser.name;
            }
            else
            {
                return "Invalid credentials";
            }
        }

        public List<Users> GetAllUsers()
        {
            List<Users> usersList=_db.Users.ToList();
            return usersList;
        }

        public string PostUser(Users user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user.name;
        }

        public List<Items> GetAllItems()
        {
            try
            {
                _db.Items.ToList();
                return _db.Items.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int PostItem(Items item)
        {
            try
            {
                _db.Items.Add(item);
                _db.SaveChanges();
                return item.ItemId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        public int AddToWishList(WishListItems wishListItem)
        {
            try
            {
                WishListItems Item=_db.WishListItems.Where(w=>w.ItemId==wishListItem.ItemId).FirstOrDefault();
                if(Item==null)
                {
                    _db.WishListItems.Add(wishListItem);
                    _db.SaveChanges();
                    return wishListItem.ItemId;
                }
                return -1;
                
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int RemoveFromWishList(int ItemId)
        {
            try
            {
                WishListItems DeletedItem = _db.WishListItems.Where(x => x.ItemId == ItemId).FirstOrDefault();
                _db.WishListItems.Remove(DeletedItem);
                _db.SaveChanges();
                return DeletedItem.ItemId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        public List<WishListItems> GetAllWishListItems()
        {
            var wishListItems=_db.WishListItems.ToList();
            return wishListItems;

        }

       
    }
}
