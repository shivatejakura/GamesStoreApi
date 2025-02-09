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

        public static GameSummaryDto ToDto(this Game game)
        {
           return  new GameSummaryDto(
                             game.id,
                             game.name,
                             game.Genre?.name ?? "Unknown", // Avoid null issues
                             game.price,
                             game.ReleaseDate);

        }

        public static GameDetailsDto ToGameDetailDto(this Game game)
        {
            return new GameDetailsDto(
                              game.id,
                              game.name,
                              game.GenreId, // Avoid null issues
                              game.price,
                              game.ReleaseDate);

        }

        public static Game ToEntity(this UpdateDto game, int id)
        {
            return new Game()
            {
                id = id,
                name = game.Name,
                GenreId = game.GenreId,
                price = game.price,
                ReleaseDate = game.ReleaseDate
            };
        }

    }
}




