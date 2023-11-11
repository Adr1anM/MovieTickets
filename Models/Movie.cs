using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Data.Enum;

namespace OnlineShop.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = " Name is Required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = " Description is Required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = " StartDate is Required")]
        public DateTime StartDate {get; set; }

        [Required(ErrorMessage = " EndDate is Required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = " Price is Required")]
        public double Price { get; set; }

        [Required(ErrorMessage = " Image is Required")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = " MovieCategory is Required")]
        public MovieCategory MovieCategory { get; set; }   
        
        //RelationShip
        public List<Actor_Movie>? Actors_Movies { get; set; }

        //Cinema 
        [ForeignKey("CinemaId")]
        public int? CinemaId     { get; set; }
        
        public Cinema? Cinema { get; set; }

        //ProduceR 
        [ForeignKey("ProducerId")]
        public int? ProducerId { get; set; }
      
        public Producer? Producer { get; set; }
                
        public List<ShoppingCart>? ShopingCarts { get; set; }   

    }
}
