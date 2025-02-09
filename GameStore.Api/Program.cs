using GameStore.Api.data;
using GameStore.Api.Dtos;
using GameStore.Api.Endpoints;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

//  Add Controllers API Explorer (required for Swagger to work)
builder.Services.AddControllers();

//  Add Endpoints API Explorer (required for Swagger to work)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRateLimiter(options =>

        options.AddSlidingWindowLimiter("sliding", limiterOption =>
        {
            limiterOption.PermitLimit = 1;
            limiterOption.Window = TimeSpan.FromSeconds(30); // Window size = 30 sec
            limiterOption.SegmentsPerWindow = 3; // Each segment = 10 sec (30 sec / 3)
            limiterOption.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
            limiterOption.QueueLimit = 1;
        })
);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GamestoreContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapGamesEndpoint();
app.MapGenresEndpoints();
//  Map Controllers (required for Swagger)
app.MapControllers();

//Ensure Swagger is only enabled in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
await app.MigrateDBAsync();

app.Run();
