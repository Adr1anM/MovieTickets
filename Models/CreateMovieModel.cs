namespace OnlineShop.Models
{
    public class CreateMovieModel
    {

        public Cinema Cinema { get; set; }
        public Producer Producer { get; set; }
        public Dictionary<string ,int> keyValuePairs { get; set; }

    }
}
