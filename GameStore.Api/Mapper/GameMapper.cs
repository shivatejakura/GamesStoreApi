using GameStore.Api.data;
using GameStore.Api.Dtos;
using GameStore.Api.Entites;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Mapper
{
    public static class GameMapper
    {
        public static Game ToEntity(this CreateGame newgame)
        {
            return new Game ()
            {
                name = newgame.Name,
                GenreId = newgame.GenreId,
                price = newgame.price,
                ReleaseDate = newgame.ReleaseDate
            };

        }

        public static GameDto ToDto(this Game game)
        {
           return  new GameDto(
                             game.id,
                             game.name,
                             game.Genre?.name ?? "Unknown", // Avoid null issues
                             game.price,
                             game.ReleaseDate);

        }
    }
}




