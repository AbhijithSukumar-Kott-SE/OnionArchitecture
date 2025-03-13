using MediatR;

namespace OnionArchitecture.Core.Events
{
   public record BlogCreatedEvent(string BlogId,string Name):INotification;
}
