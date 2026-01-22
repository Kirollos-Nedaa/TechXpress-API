using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress_V2.Domain.Models;

namespace TechXpress_V2.Infrastructure.Contexts
{
    public class MongoDbInitializer
    {
        private readonly IMongoDatabase _database;
        private readonly ILogger<MongoDbInitializer> _logger;

        public MongoDbInitializer(IMongoDatabase database, ILogger<MongoDbInitializer> logger)
        {
            _database = database;
            _logger = logger;
        }

        public async Task InitializeAsync()
        {
            _logger.LogInformation("Starting MongoDB initialization...");

            // --- 1. ProductReviews Collection ---
            _logger.LogInformation("Setting up 'product_reviews' collection indexes...");
            var reviewsCollection = _database.GetCollection<ProductReview>("product_reviews");

            // Index: Find reviews by product, sort by rating
            var reviewIndexModel = new CreateIndexModel<ProductReview>(
                Builders<ProductReview>.IndexKeys.Ascending(r => r.ProductId).Descending(r => r.Rating)
            );
            await reviewsCollection.Indexes.CreateOneAsync(reviewIndexModel);

            // --- 2. ProductSpecifications Collection ---
            _logger.LogInformation("Setting up 'product_specifications' collection indexes...");
            var specsCollection = _database.GetCollection<ProductSpecification>("product_specifications");

            // Index: Find a spec sheet by its product ID (must be unique)
            var specIndexModel = new CreateIndexModel<ProductSpecification>(
                Builders<ProductSpecification>.IndexKeys.Ascending(s => s.ProductId),
                new CreateIndexOptions { Unique = true }
            );
            await specsCollection.Indexes.CreateOneAsync(specIndexModel);

            // --- 3. BrowsingHistory Collection ---
            _logger.LogInformation("Setting up 'browsing_history' collection indexes...");
            var historyCollection = _database.GetCollection<BrowsingHistory>("browsing_history");

            // Index 1: Find a user's history, sorted by newest
            var historyIndexModel = new CreateIndexModel<BrowsingHistory>(
                Builders<BrowsingHistory>.IndexKeys.Ascending(h => h.UserId).Descending(h => h.ViewedAt)
            );
            await historyCollection.Indexes.CreateOneAsync(historyIndexModel);

            // Index 2: TTL (Time-To-Live) index to auto-delete history after 90 days
            var ttlIndexModel = new CreateIndexModel<BrowsingHistory>(
                Builders<BrowsingHistory>.IndexKeys.Ascending(h => h.ViewedAt),
                new CreateIndexOptions { ExpireAfter = TimeSpan.FromDays(90) }
            );
            await historyCollection.Indexes.CreateOneAsync(ttlIndexModel);

            _logger.LogInformation("MongoDB initialization complete.");
        }
    }
}
