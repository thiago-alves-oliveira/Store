using DevStore.API.Mediator.Commands;
using DevStore.Domain.Entities;
using MediatR;

namespace DevStore.Application.Commands.CreateSale
{
    public class CreateSaleCommandHandler
        : ICommandHandler<CreateSaleCommand, CreateCommandResult>
    {
        private readonly ISaleRepository _repository;
        private readonly IMediator _mediator;

        public CreateSaleCommandHandler(ISaleRepository repository,
                                        IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<CreateCommandResult> Handle(CreateSaleCommand request,CancellationToken cancellationToken)
        {
            var sale = new Sale(
                request.SaleNumber,
                DateTime.UtcNow,
                request.CustomerId,
                request.CustomerName,
                request.BranchId,
                request.BranchName);

            foreach (var item in request.Items)
            {
                sale.AddItem(
                    item.ProductId,
                    item.ProductName,
                    item.Quantity,
                    item.UnitPrice);
            }

            await _repository.AddAsync(sale, cancellationToken);

            foreach (var @event in sale.DomainEvents)
                await _mediator.Publish(@event, cancellationToken);

            sale.ClearEvents();

            return new CreateCommandResult();
        }
    }
}
