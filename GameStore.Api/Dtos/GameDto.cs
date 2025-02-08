namespace GameStore.Api.Dtos
{
    public record class GameDto
        (int id ,string Name, string Genre,decimal price ,DateOnly ReleaseDate);

}
