using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using TechXpress_V2.Domain.Models;

namespace TechXpress_V2.Infrastructure
{
    public static class MongoDbClassMapper
    {
        // Call this method once from Program.cs at startup
        public static void RegisterClassMaps()
        {
            // --- 1. ProductReview Map ---
            BsonClassMap.RegisterClassMap<ProductReview>(cm =>
            {
                cm.AutoMap(); // Maps all properties with matching names
                cm.SetIgnoreExtraElements(true); // Ignores extra fields in Mongo

                // Map the Id field, tell it to be the _id, and store as ObjectId
                cm.MapIdMember(c => c.Id)
                  .SetIdGenerator(StringObjectIdGenerator.Instance) // Generates a string ObjectId
                  .SetSerializer(new StringSerializer(BsonType.ObjectId)); // Serializes as ObjectId

                // Map C# property names (PascalCase) to MongoDB field names (camelCase)
                cm.MapMember(c => c.ProductId).SetElementName("productId");
                cm.MapMember(c => c.UserId).SetElementName("userId");
                cm.MapMember(c => c.IsVerifiedPurchase).SetElementName("isVerifiedPurchase");
                cm.MapMember(c => c.CreatedAt).SetElementName("createdAt");
            });

            // --- 2. ProductSpecification Map ---
            BsonClassMap.RegisterClassMap<ProductSpecification>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
                cm.MapIdMember(c => c.Id)
                  .SetIdGenerator(StringObjectIdGenerator.Instance)
                  .SetSerializer(new StringSerializer(BsonType.ObjectId));

                cm.MapMember(c => c.ProductId).SetElementName("productId");
                cm.MapMember(c => c.SpecificationGroups).SetElementName("specificationGroups");
            });

            // --- 3. SpecificationGroup (Nested Class) Map ---
            BsonClassMap.RegisterClassMap<SpecificationGroup>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
                cm.MapMember(c => c.GroupName).SetElementName("groupName");
            });

            // --- 4. SpecAttribute (Nested Class) Map ---
            BsonClassMap.RegisterClassMap<SpecAttribute>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
                // 'Name' and 'Value' map to 'name' and 'value' automatically
                // or you can be explicit:
                // cm.MapMember(c => c.Name).SetElementName("name");
                // cm.MapMember(c => c.Value).SetElementName("value");
            });

            // --- 5. BrowsingHistory Map ---
            BsonClassMap.RegisterClassMap<BrowsingHistory>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
                cm.MapIdMember(c => c.Id)
                  .SetIdGenerator(StringObjectIdGenerator.Instance)
                  .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapMember(c => c.UserId).SetElementName("userId");
                cm.MapMember(c => c.VariantId).SetElementName("variantId");
                cm.MapMember(c => c.ViewedAt).SetElementName("viewedAt");
            });
        }
    }
}
