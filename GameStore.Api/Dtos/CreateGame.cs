using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos
{
    public record class CreateGame(
         [Required][StringLength(50)]
         string Name,
         int GenreId,
        [Required][Range(1,100)]
        decimal price,
        DateOnly ReleaseDate);

}
