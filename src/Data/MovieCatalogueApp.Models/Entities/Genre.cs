namespace MovieCatalogueApp.Models.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Movie Movie { get; set; }
    }
}
