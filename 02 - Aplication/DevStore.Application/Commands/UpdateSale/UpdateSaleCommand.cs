using System;
using System.Collections.Generic;
using DevStore.API.Mediator.Commands;
using DevStore.Application.DTOs;

namespace DevStore.Application.Commands.UpdateSale
{
    public class UpdateSaleCommand : CommandInput<CancelSalesCommandResult>
    {
        public UpdateSaleCommand(
            Guid saleId,
            IEnumerable<SaleItemDto> items)
        {
            SaleId = saleId;
            Items = items;
        }

        public Guid SaleId { get; }
        public IEnumerable<SaleItemDto> Items { get; }
    }
}
