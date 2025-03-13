using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OnionArchitecture.Application.Events.Blog;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Application.Events
{
    public class BlogCreatedEventHandler(ILogger<BlogCreatedEventHandler> _logger)
        : INotificationHandler<BlogCreatedEvent>
    {
        public async Task Handle(BlogCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"📢 New Blog Created: {notification.Title}");
            Console.WriteLine($"🔹 Publishing BlogCreatedEvent: {notification.Title}");
            // Simulate sending an email (async)
            await Task.Delay(500);
            _logger.LogInformation($"📧 Email Notification Sent for Blog: {notification.Title}");
        }
    }
}
