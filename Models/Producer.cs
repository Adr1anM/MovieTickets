using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Producer
    {

        [Key]
        public int Id { get; set; }      

        [Display(Name = "Profile Picture")]
        [Required]
        public string? ProfilePicture { get; set; }

        [Display(Name = "Full Name")]
        [Required]
        public string? FullName { get; set; }

        [Display(Name = "Biography")]
        [Required]
        public string? Bio { get; set; }

        //Relationships

        public List<Movie>? Movies { get; set; }

    }
}
