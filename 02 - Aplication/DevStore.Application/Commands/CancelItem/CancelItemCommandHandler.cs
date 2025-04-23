using System.Threading;
using System.Threading.Tasks;
using DevStore.API.Mediator.Commands;
using DevStore.Domain.Entities;
using MediatR;

namespace DevStore.Application.Commands.CancelItem
{
    public class CancelItemCommandHandler
        : ICommandHandler<CancelItemCommand, CancelItemCommandResult>
    {
        private readonly ISaleRepository _repository;
        private readonly IMediator _mediator;

        public CancelItemCommandHandler(
            ISaleRepository repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<CancelItemCommandResult> Handle(
            CancelItemCommand request,
            CancellationToken cancellationToken)
        {
            var sale = await _repository.GetByIdAsync(request.SaleId, cancellationToken)
                       ?? throw new ArgumentException("Sale not found");

            sale.CancelItem(request.ItemId);
            await _repository.UpdateAsync(sale, cancellationToken);

            foreach (var @event in sale.DomainEvents)
                await _mediator.Publish(@event, cancellationToken);

            sale.ClearEvents();

            return new CancelItemCommandResult { Success = true };
        }
    }
}
