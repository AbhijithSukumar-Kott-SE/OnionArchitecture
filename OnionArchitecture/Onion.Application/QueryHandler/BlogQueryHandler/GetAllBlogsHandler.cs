using AutoMapper;
using MediatR;
using OnionArchitecture.Application.DTOs;
using OnionArchitecture.Application.Interfaces;
using OnionArchitecture.Application.Queries.BlogQueries;
using OnionArchitecture.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.QueryHandler.BlogQueryHandler
{
    public class GetAllBlogsHandler(IBlogService _blogService) : IRequestHandler<GetAllBlogsQuery, IEnumerable<BlogDto>>
    {

        async Task<IEnumerable<BlogDto>> IRequestHandler<GetAllBlogsQuery, IEnumerable<BlogDto>>.Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogService.getAllBlogsAsync();
            return blogs;
        }
    }
}
