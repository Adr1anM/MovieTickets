using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Models
{
    public class ApplicationUser : IdentityUser
    {

        public List<ShoppingCart> ShoppingCarts { get; set; }

    }
}
