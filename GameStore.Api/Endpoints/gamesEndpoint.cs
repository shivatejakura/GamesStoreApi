using GameStore.Api.data;
using GameStore.Api.Dtos;
using GameStore.Api.Entites;
using GameStore.Api.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints
{
    public static class gamesEndpoint
    {
        private static List<GameSummaryDto> games = [new
    (
        1,
        "Street Fighter II",
        "Fighting",
        19.99m,
        new DateOnly(1992, 7, 15)
    ),
    new
    (
        2,
        "Final Fantasy XIV",
        "Roleplaying",
        59.99m,
        new DateOnly(2010, 9, 30)
    ),
    new
    (
        3,
        "The Legend of Zelda: Ocarina of Time",
        "Action-Adventure",
        39.99m,
        new DateOnly(1998, 11, 21)
    ),
    new
    (
        4,
        "Grand Theft Auto V",
        "Action",
        29.99m,
        new DateOnly(2013, 9, 17)
    ),
    new
    (
        5,
        "The Witcher 3: Wild Hunt",
        "RPG",
        49.99m,
        new DateOnly(2015, 5, 19)
    ),
    new
    (
        6,
        "Minecraft",
        "Sandbox",
        26.95m,
        new DateOnly(2011, 11, 18)
    ),
    new
    (
        7,
        "Red Dead Redemption 2",
        "Action-Adventure",
        59.99m,
        new DateOnly(2018, 10, 26)
    ),
    new
    (
        8,
        "Dark Souls III",
        "Action RPG",
        39.99m,
        new DateOnly(2016, 4, 12)
    ),
    new
    (
        9,
        "Super Mario Odyssey",
        "Platformer",
        49.99m,
        new DateOnly(2017, 10, 27)
    ),
    new
    (
        10,
        "Cyberpunk 2077",
        "RPG",
        59.99m,
        new DateOnly(2020, 12, 10)
    )
];
        public static RouteGroupBuilder MapGamesEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("games").WithParameterValidation();

            //Get Games
            group.MapGet("/", async(GamestoreContext dbcontext) => 
            await dbcontext.Games.Include(game=>game.Genre)
            .Select(game=>game.ToDto()).AsNoTracking().ToListAsync());

            //Get Games by id 
            group.MapGet("/{id}", async (int id,GamestoreContext dbContext) =>
            {
                var game = await dbContext.Games.FindAsync(id);
                return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailDto());

            }).WithName("GetGame");

            //POST /games
            group.MapPost("/", async (CreateGame newgame, GamestoreContext dbContext) =>
            {
                Game game = newgame.ToEntity();
                await dbContext.Games.AddAsync(game);
                dbContext.SaveChangesAsync();
                return Results.CreatedAtRoute("GetGame", new { id = game.id }
            , game.ToDto());
            }
            );



            //Update Game with ID
            group.MapPut("/{id}", async(int id, UpdateDto updatedGame,GamestoreContext dbContext) =>
            {
                var existingGame =  await dbContext.Games.FindAsync(id);

                if (existingGame is null)
                {
                    return Results.NotFound();
                }

                 dbContext.Entry(existingGame)
                         .CurrentValues
                         .SetValues(updatedGame.ToEntity(id));

                 await dbContext.SaveChangesAsync();

                return Results.NoContent();
            }
            );
            group.MapDelete("/{id}", async (int id, GamestoreContext dbContext) =>
            {
                ////var game = dbContext.Games.Find(id);
                ////if (game is null)
                ////    return Results.NotFound();
                ////dbContext.Remove(game);
                ////return Results.NoContent();
                ///
                await dbContext.Games.Where(g => g.id == id).ExecuteDeleteAsync();
                return Results.NoContent();
            }

            );
            return group;
        }

    }
}
