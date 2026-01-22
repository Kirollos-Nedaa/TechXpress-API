using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using DotNetEnv;
using TechXpress_V2.Infrastructure;
using TechXpress_V2.Infrastructure.Contexts;
using TechXpress_V2.Infrastructure.Settings;

MongoDbClassMapper.RegisterClassMaps();
Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(options =>
{
    options.ConnectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");
    options.DatabaseName = Environment.GetEnvironmentVariable("MONGODB_DATABASE_NAME");
});
builder.Services.AddSingleton<IMongoClient>(s =>
{
    var settings = s.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});
builder.Services.AddSingleton<IMongoDatabase>(s =>
{
    var mongoClient = s.GetRequiredService<IMongoClient>();
    var settings = s.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return mongoClient.GetDatabase(settings.DatabaseName);
});
builder.Services.AddSingleton<MongoDbInitializer>();

var conn = Environment.GetEnvironmentVariable("CONN_STRING");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(conn, sqlOptions => sqlOptions.EnableRetryOnFailure()));

builder.Services.AddControllers();

var app = builder.Build();

try
{
    var mongoInitializer = app.Services.GetRequiredService<MongoDbInitializer>();
    await mongoInitializer.InitializeAsync();
}
catch (Exception ex)
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during MongoDB initialization.");
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();