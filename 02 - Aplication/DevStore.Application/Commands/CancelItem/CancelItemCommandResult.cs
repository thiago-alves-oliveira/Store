using DevStore.API.Mediator.Commands;

namespace DevStore.Application.Commands.CancelItem
{
    public class CancelItemCommandResult : CommandResult
    {
        public bool Success { get; init; }
    }
}
