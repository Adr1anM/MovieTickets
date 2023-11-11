using MessagePack;
using Microsoft.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class ShoppingCart
    {     
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey("MovieId")]
        public int MovieId { get; set; }    
        public Movie Movie { get; set; }

    }
}
