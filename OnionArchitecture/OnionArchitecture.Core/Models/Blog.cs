using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnionArchitecture.Core.Models
{
    public class Blog
    {
        private string? _publisher;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("title")]
        public required string Title { get; set; }

        [BsonElement("content")]
        public required string Content { get; set; }

        [BsonElement("publisher")]
        public string Publisher { get => _publisher!; set
            {
                _publisher = string.IsNullOrEmpty(value) ? "Unknown" : value;
            } }
    }

    public class BlogSample
    {
        public string Id { get; set; }
    }
}
