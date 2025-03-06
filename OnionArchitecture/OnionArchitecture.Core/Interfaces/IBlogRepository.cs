using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> getAllBlogsAsync();
        Task addBlogAsync(Blog blog);
    }
}
