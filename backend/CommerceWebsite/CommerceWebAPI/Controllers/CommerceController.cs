using CommerceWebAPI.Models;
using CommerceWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommerceController : ControllerBase
    {
        private readonly ICommerceRepo _repo;
        public CommerceController(ICommerceRepo repo)
        {
            _repo = repo;
        }
        // GET: api/<CommerceController>
        [HttpGet("validate")]
        public async Task<IActionResult> ValidateUser(string Phno, string password)
        {
            // string user=_repo.ValidateUser(email, password);

            string name = _repo.ValidateUser(Phno, password);
            return Ok(name);

        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = _repo.GetAllUsers();
            if (users != null)
                return Ok(users);
            else
                return BadRequest("No users found");
        }
        [HttpPost("PostUser")]
        public async Task<IActionResult> PostUser([FromBody] Users user)
        {
            string Username = _repo.PostUser(user);
            if (Username != null)
            {
                return Ok(Username);
            }
            else
            {
                return BadRequest("User not added");
            }
        }

        [HttpPost("PostItem")]
        public async Task<IActionResult> PostItem(Items item)
        {
            var ItemId = _repo.PostItem(item);
            if (ItemId != -1)
                return Ok(ItemId);
            return BadRequest(-1);
        }
        [HttpGet("GetAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            var items = _repo.GetAllItems();
            if (items != null)
                return Ok(items);
            return BadRequest(-1);
        }


        [HttpGet("GetWishListItems")]
        public async Task<IActionResult> GetAllWishListItems()
        {
            var wishListItems=_repo.GetAllWishListItems();
            if(wishListItems != null)
                return Ok(wishListItems);
            return BadRequest(-1);
        }

        [HttpPost("AddToWishList")]
        public async Task<IActionResult> AddToWishList(WishListItems wishListItem)
        {
            var res=_repo.AddToWishList(wishListItem);
            if(res!=-1)
                return Ok(res);
            return BadRequest("No item has added");
        }

        [HttpDelete("RemoveFromWishList")]
        public async Task<IActionResult> RemoveFromWishList(int ItemId)
        {
            int DeleteItemId=_repo.RemoveFromWishList(ItemId);
            if (DeleteItemId!=-1)
                return Ok(DeleteItemId);
            return BadRequest("No Item has deleted");
        }

      
    }
}
