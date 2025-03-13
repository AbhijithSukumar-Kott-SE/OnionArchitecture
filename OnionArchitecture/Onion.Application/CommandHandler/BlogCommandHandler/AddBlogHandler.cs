using MediatR;
using OnionArchitecture.Application.Commands.BlogCommands;
using OnionArchitecture.Application.Interfaces;
using OnionArchitecture.Application.Events.Blog;


namespace OnionArchitecture.Application.CommandHandler.BlogCommandHandler
{
    class AddBlogHandler(IBlogService _blogService, IMediator _mediator) : IRequestHandler<AddBlogCommand>
    {
        public async Task Handle(AddBlogCommand request, CancellationToken cancellationToken)
        {
            
            await _blogService.addBlogAsync(request.Blog);

            // Publish an event when the blog is added
            await _mediator.Publish(new BlogCreatedEvent(request.Blog.Id!, request.Blog.Title));
        }
    }
}
