using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;

namespace TechXpress_V2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MongoTestController : ControllerBase
    {
        private readonly IMongoDatabase _database;
        private readonly ILogger<MongoTestController> _logger;

        // Inject the IMongoDatabase and a logger
        public MongoTestController(IMongoDatabase database, ILogger<MongoTestController> logger)
        {
            _database = database;
            _logger = logger;
        }

        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection()
        {
            try
            {
                // 1. Define a "ping" command
                var command = new BsonDocument("ping", 1);

                // 2. Run the command against the "admin" database (or your app's db)
                // This command is lightweight and just checks if the server is responsive.
                await _database.RunCommandAsync<BsonDocument>(command);

                // 3. If it doesn't throw an exception, the connection is successful
                _logger.LogInformation("MongoDB connection successful!");
                return Ok(new { status = "success", message = "MongoDB connection successful!" });
            }
            catch (Exception ex)
            {
                // 4. If it fails, log the exception and return a 500 error
                _logger.LogError(ex, "Failed to connect to MongoDB.");

                // This will return the error message to you so you can debug
                return StatusCode(500, new
                {
                    status = "error",
                    message = "MongoDB connection failed.",
                    error = ex.Message
                });
            }
        }
    }
}