using MediatR;
using OnionArchitecture.Application.DTOs;


namespace OnionArchitecture.Application.Queries.BlogQueries
{
    public record GetAllBlogsQuery() : IRequest<IEnumerable<BlogDto>>;
}
