using GameStore.Api.data;
using GameStore.Api.Mapper;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints
{
    public static class GenreEndpoint
    {
        public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("genres");

            group.MapGet("/", async (GamestoreContext dbContext) =>
                await dbContext.Genre
                               .Select(genre => genre.ToDto())
                               .AsNoTracking()
                               .ToListAsync());

            return group;
        }
    }
}
