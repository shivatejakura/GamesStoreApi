using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.data
{
    public static class Dataextention
    {
        public static void MigrateDB(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbcontext =scope.ServiceProvider.GetRequiredService<GamestoreContext>();
            dbcontext.Database.Migrate();
        }
    }
}
