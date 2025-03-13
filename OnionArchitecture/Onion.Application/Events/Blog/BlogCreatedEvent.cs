using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Events.Blog
{
    public record BlogCreatedEvent(string BlogId,string Title) : INotification;
}
