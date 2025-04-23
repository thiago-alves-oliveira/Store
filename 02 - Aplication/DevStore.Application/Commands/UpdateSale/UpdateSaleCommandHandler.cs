using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevStore.API.Mediator.Commands;
using DevStore.Domain.Entities;
using MediatR;

namespace DevStore.Application.Commands.UpdateSale
{
    public class UpdateSaleCommandHandler
        : ICommandHandler<UpdateSaleCommand, CancelSalesCommandResult>
    {
        private readonly ISaleRepository _repository;
        private readonly IMediator _mediator;

        public UpdateSaleCommandHandler(
            ISaleRepository repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<CancelSalesCommandResult> Handle(
            UpdateSaleCommand request,
            CancellationToken cancellationToken)
        {
            var sale = await _repository.GetByIdAsync(request.SaleId, cancellationToken)
                       ?? throw new ArgumentException("Sale not found");

            // substitui todos os itens da venda pelo novo conjunto
            var newItems = request.Items
                .Select(i => new SaleItem(
                    i.ProductId,
                    i.ProductName,
                    i.Quantity,
                    i.UnitPrice))
                .ToList();     
             

            sale.ReplaceItems(newItems);

            await _repository.UpdateAsync(sale, cancellationToken);

            foreach (var @event in sale.DomainEvents)
                await _mediator.Publish(@event, cancellationToken);

            sale.ClearEvents();

            return new CancelSalesCommandResult { Success = true };
        }
    }
}
