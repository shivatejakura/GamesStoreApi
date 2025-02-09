namespace GameStore.Api.Dtos
{
    public record class GameDetailsDto(int id, string Name, int Genreid, decimal price, DateOnly ReleaseDate);
}
