using MongoDB.Driver;
using OnionArchitecture.Core.Interfaces;
using OnionArchitecture.Core.Models;
using OnionArchitecture.Infrastructure.DBContext;

namespace OnionArchitecture.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IMongoCollection<Blog> _blogCollection;

        public BlogRepository(MongoDbContext context)
        {
            _blogCollection = context.Blogs;
        }

        public async Task addBlogAsync(Blog blog)
        {
            await _blogCollection.InsertOneAsync(blog);
        }

        public async Task<IEnumerable<Blog>> getAllBlogsAsync()
        {
            var blogs = await _blogCollection.Find(_ => true).ToListAsync();

            
            blogs.ForEach(blog => blog.Id ??= blog.Id.ToString());

            return blogs;
        }
    }
}
