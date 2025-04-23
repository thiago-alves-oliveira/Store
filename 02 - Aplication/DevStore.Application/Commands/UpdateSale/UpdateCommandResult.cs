using DevStore.API.Mediator.Commands;

namespace DevStore.Application.Commands.UpdateSale
{
    public class CancelSalesCommandResult : CommandResult
    {
        public bool Success { get; init; }
    }
}
