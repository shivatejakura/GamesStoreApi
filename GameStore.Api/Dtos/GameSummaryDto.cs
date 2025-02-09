namespace GameStore.Api.Dtos
{
    public record class GameSummaryDto
        (int id ,string Name, string Genre,decimal price ,DateOnly ReleaseDate);

}
