using OnionArchitecture.Application.Interfaces;
using OnionArchitecture.Core.Interfaces;
using OnionArchitecture.Core.Models;
using OnionArchitecture.Application.DTOs;
using AutoMapper;

namespace OnionArchitecture.Application.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BlogDto>> getAllBlogsAsync()
        {
            var blogs = await _blogRepository.getAllBlogsAsync();
            return _mapper.Map<IEnumerable<BlogDto>>(blogs);
        }

        public async Task addBlogAsync(BlogDto blogDto)
        {
            var blog = _mapper.Map<Blog>(blogDto);
            await _blogRepository.addBlogAsync(blog);
        }
    }
}
