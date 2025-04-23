using MediatR;
using Microsoft.Extensions.Logging;
namespace DevStore.Infra.Messaging;
public class EventPublisher<T> : INotificationHandler<T> where T : INotification
{
    private readonly ILogger<EventPublisher<T>> _log;
    public EventPublisher(ILogger<EventPublisher<T>> log) => _log = log;
    public Task Handle(T notification, CancellationToken ct) { _log.LogInformation("Domain event {E}", typeof(T).Name); return Task.CompletedTask; }
}
