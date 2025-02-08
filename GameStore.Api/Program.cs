using GameStore.Api.data;
using GameStore.Api.Dtos;
using GameStore.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GamestoreContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapGamesEndpoint();

app.MigrateDB();

app.Run();
