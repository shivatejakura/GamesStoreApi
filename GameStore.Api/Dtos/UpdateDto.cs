namespace GameStore.Api.Dtos
{
    public record class UpdateDto(string Name,
        int GenreId,
        decimal price,
        DateOnly ReleaseDate);
}
