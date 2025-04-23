using System;

namespace DevStore.Application.DTOs
{
    public record SaleItemDto(
        Guid ProductId,
        string ProductName,
        int Quantity,
        decimal UnitPrice);
}
