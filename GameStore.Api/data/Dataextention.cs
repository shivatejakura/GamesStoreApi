using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.data
{
    public static class Dataextention
    {
        public static async Task MigrateDBAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbcontext =scope.ServiceProvider.GetRequiredService<GamestoreContext>();
            dbcontext.Database.MigrateAsync();
        }
    }
}
