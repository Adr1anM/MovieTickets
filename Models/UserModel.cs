using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Models
{
    public class UserModel : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }    


    }
}
