namespace movie_restapi_web.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public String? Title { get; set; }
        public String? Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
