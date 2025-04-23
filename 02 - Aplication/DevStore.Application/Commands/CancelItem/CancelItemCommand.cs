using System;
using DevStore.API.Mediator.Commands;

namespace DevStore.Application.Commands.CancelItem
{
    public class CancelItemCommand : CommandInput<CancelItemCommandResult>
    {
        public CancelItemCommand(Guid saleId, Guid itemId)
        {
            SaleId = saleId;
            ItemId = itemId;
        }

        public Guid SaleId { get; }
        public Guid ItemId { get; }
    }
}
