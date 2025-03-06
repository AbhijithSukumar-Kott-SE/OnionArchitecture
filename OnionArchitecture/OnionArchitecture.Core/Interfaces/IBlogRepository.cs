using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Interfaces
{
    interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogs();
        Task CreateBlog(Blog blog);
    }
}
