using CommerceWebAPI.Models;

namespace CommerceWebAPI.Repository
{
    public interface ICommerceRepo
    {
        public string ValidateUser(string email,string password);
        public List<Users> GetAllUsers();
        public string PostUser(Users user);

        public int PostItem (Items item);

        public List<Items> GetAllItems();

        public int AddToWishList(WishListItems wishListItem);

        public int RemoveFromWishList(int ItemId);

        public List<WishListItems> GetAllWishListItems();


    }
}
