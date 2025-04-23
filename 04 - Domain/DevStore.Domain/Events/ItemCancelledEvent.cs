using MediatR;

namespace DevStore.Domain.Events
{
    public record ItemCancelledEvent(Guid SaleId, Guid ItemId) : INotification;
}
