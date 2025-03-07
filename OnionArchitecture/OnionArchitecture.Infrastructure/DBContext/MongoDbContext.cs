using MongoDB.Driver;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Infrastructure.DBContext
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoClient client, string databaseName)
        {
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Blog> Blogs => _database.GetCollection<Blog>("blogs");
    }
}
