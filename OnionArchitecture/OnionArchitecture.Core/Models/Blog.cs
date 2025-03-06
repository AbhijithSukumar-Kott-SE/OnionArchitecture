using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnionArchitecture.Core.Models
{
    class Blog
    {
        private string? _publisher;

        [BsonId]
        public required string Id { get; set; }

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
}
