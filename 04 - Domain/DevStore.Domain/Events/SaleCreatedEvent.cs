using MediatR;

namespace DevStore.Domain.Events
{
    public record SaleCreatedEvent(Guid SaleId) : INotification;
}
