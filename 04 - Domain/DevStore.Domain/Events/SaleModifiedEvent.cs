using MediatR;

namespace DevStore.Domain.Events
{
    public record SaleModifiedEvent(Guid SaleId) : INotification;
}
