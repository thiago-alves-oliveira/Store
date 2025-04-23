using MediatR;

namespace DevStore.Domain.Events
{
    public record ItemAddedEvent(Guid SaleId, Guid ItemId) : INotification;
}
