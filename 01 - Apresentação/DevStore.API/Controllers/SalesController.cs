using DesafioBiblico.Core.Mvc;
using DevStore.Application.Commands.CancelItem;
using DevStore.Application.Commands.CancelSale;
using DevStore.Application.Commands.UpdateSale;
using DevStore.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController :  BaseController
    {
        private readonly ISaleRepository _repo;
        private readonly IMediator _mediator;

        public SalesController(ISaleRepository repo, IMediator mediator)
        {
            _repo = repo;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List(CancellationToken ct) =>
            Ok(await _repo.ListAsync(ct));

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            var sale = await _repo.GetByIdAsync(id, ct);
            return sale is null ? NotFound() : (IActionResult)Ok(sale);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSaleCommand input)
        {
            return HandleResult(await _mediator.Send(input));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateSaleCommand input)
        {
            return HandleResult(await _mediator.Send(input));
        }

        [HttpPost("{id:guid}/cancel")]
        public async Task<IActionResult> Cancel(CancelSaleCommand input)
        {
            return HandleResult(await _mediator.Send(input));
        }

        [HttpPost("{saleId:guid}/items/{itemId:guid}/cancel")]
        public async Task<IActionResult> CancelItem(CancelItemCommand input)
        {
            return HandleResult(await _mediator.Send(input));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            await _repo.DeleteAsync(id, ct);
            return NoContent();
        }
    }
}
