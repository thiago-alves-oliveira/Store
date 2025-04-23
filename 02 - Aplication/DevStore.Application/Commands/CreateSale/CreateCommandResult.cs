
using DevStore.API.Mediator.Commands;

namespace DevStore.Application.Commands.CreateSale;

public class CreateCommandResult : CommandResult
{
    public Guid Id { get; set; }
}