using MediatR;
using OnionArchitecture.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Commands.BlogCommands
{
    public record AddBlogCommand(BlogDto Blog) : IRequest;
}
