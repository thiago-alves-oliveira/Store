using System.Threading;
using System.Threading.Tasks;
using DevStore.API.Mediator.Commands;
using DevStore.Domain.Entities;
using MediatR;

namespace DevStore.Application.Commands.CancelSale
{
    public class CancelSaleCommandHandler
        : ICommandHandler<CancelSaleCommand, CancelItemCommandResult>
    {
        private readonly ISaleRepository _repository;
        private readonly IMediator _mediator;

        public CancelSaleCommandHandler(
            ISaleRepository repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<CancelItemCommandResult> Handle(
            CancelSaleCommand request,
            CancellationToken cancellationToken)
        {
            var sale = await _repository.GetByIdAsync(request.SaleId, cancellationToken)
                       ?? throw new ArgumentException("Sale not found");

            sale.Cancel();
            await _repository.UpdateAsync(sale, cancellationToken);

            foreach (var @event in sale.DomainEvents)
                await _mediator.Publish(@event, cancellationToken);

            sale.ClearEvents();

            return new CancelItemCommandResult { Success = true };
        }
    }
}
