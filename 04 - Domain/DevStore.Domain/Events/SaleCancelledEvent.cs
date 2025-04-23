using MediatR;

namespace DevStore.Domain.Events
{
    public record SaleCancelledEvent(Guid SaleId) : INotification;
}
