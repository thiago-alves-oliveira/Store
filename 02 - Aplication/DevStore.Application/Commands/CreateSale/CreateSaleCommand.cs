using DevStore.API.Mediator.Commands;
using DevStore.Application.Commands.CreateSale;
using DevStore.Application.DTOs;

public class CreateSaleCommand : CommandInput<CreateCommandResult>
{
    public CreateSaleCommand(
    string saleNumber, Guid customerId, string customerName,
    Guid branchId, string branchName, IEnumerable<SaleItemDto> items)
    {
        SaleNumber = saleNumber;
        CustomerId = customerId;
        CustomerName = customerName;
        BranchId = branchId;
        BranchName = branchName;
        Items = items;
    }

    public string SaleNumber { get; }
    public Guid CustomerId { get; }
    public string CustomerName { get; }
    public Guid BranchId { get; }
    public string BranchName { get; }
    public IEnumerable<SaleItemDto> Items { get; }

}
