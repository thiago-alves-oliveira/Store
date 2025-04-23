using DevStore.API.Mediator;

namespace DevStore.API.Mediator.Commands;

public class CommandInput<TCommandResult> : MediatorInput<TCommandResult> where TCommandResult : CommandResult
{
}