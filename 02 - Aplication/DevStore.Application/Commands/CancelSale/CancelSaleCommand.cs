using System;
using DevStore.API.Mediator.Commands;

namespace DevStore.Application.Commands.CancelSale
{
    public class CancelSaleCommand : CommandInput<CancelItemCommandResult>
    {
        public CancelSaleCommand(Guid saleId) => SaleId = saleId;
        public Guid SaleId { get; }
    }
}
