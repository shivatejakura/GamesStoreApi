using GameStore.Api.Dtos;
using GameStore.Api.Entites;

namespace GameStore.Api.Mapper
{
    public static class GenreMapper
    {
        public static GenreDto ToDto(this Genre genre)
        {
            return new GenreDto(genre.id, genre.name);
        }
    }
}
