using DevStore.Application.DTOs;
using FluentValidation;

namespace DevStore.Application.Validators
{
    public class SaleItemDtoValidator : AbstractValidator<SaleItemDto>
    {
        public SaleItemDtoValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty();

            RuleFor(x => x.ProductName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Quantity)
                .InclusiveBetween(1, 20);

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0);
        }
    }
}
