using DevStore.API.Mediator.Commands;

namespace DevStore.Application.Commands.CancelSale
{
    public class CancelItemCommandResult : CommandResult
    {
        public bool Success { get; init; }
    }
}
