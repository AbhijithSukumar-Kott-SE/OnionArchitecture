using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Commands.BlogCommands;
using OnionArchitecture.Application.DTOs;
using OnionArchitecture.Application.Interfaces;
using OnionArchitecture.Application.Queries.BlogQueries;

namespace OnionArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/blogs")]
    public class BlogController(IMediator _mediator) : ControllerBase
    {
        //private readonly IBlogService _blogService;

        //public BlogController(IBlogService blogService)
        //{
        //    _blogService = blogService;
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogDto>>> Get() =>
            Ok(await _mediator.Send(new GetAllBlogsQuery()));

        [HttpPost]
        public async Task<IActionResult> Post(BlogDto blogDto)
        {
            await _mediator.Send(new AddBlogCommand(blogDto));
            return Ok(new
            {
                message = "Blog created successfully"
            });
        }
    }
}
