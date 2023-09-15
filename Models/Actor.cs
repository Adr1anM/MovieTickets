using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
            
        [Display(Name ="Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is Required")]
        public string? ProfilePicture { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage ="Full Name is Required")]
        [StringLength(50,MinimumLength=3,ErrorMessage ="Full Name Must be between 3 and 50 chars")]
        public string? FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is Required")]
        public string? Bio { get; set; }

      
        public List<Actor_Movie>? Actors_Movies { get; set; }


    }
}
    