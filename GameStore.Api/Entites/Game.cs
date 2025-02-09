using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Entites
{
    public class Game
    {
        [Key]
        public int id { get; set; }
        public required string name { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
        public decimal price { get; set; }

        public DateOnly ReleaseDate { get; set; }
    }
}
