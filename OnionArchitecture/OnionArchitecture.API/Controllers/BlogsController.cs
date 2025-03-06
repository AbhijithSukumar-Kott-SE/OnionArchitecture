using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.DTOs;
using OnionArchitecture.Application.Interfaces;

namespace OnionArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/blogs")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogDto>>> Get() =>
            Ok(await _blogService.getAllBlogsAsync());

        [HttpPost]
        public async Task<IActionResult> Post(BlogDto blogDto)
        {
            await _blogService.addBlogAsync(blogDto);
            return Ok(new
            {
                message = "Blog created successfully"
            });
        }
    }
}
