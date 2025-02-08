using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Api.Entites
{
    public class Genre
    {
        [Key]
        public int id { get; set; }
        public required string name { get; set; }
    }
}
