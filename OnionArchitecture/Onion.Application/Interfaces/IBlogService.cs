using OnionArchitecture.Application.DTOs;

namespace OnionArchitecture.Application.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogDto>> getAllBlogsAsync();
        Task addBlogAsync(BlogDto blogDto);
    }
}
