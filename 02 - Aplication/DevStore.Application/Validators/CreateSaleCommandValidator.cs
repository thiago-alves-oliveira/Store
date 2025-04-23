using DevStore.Application.Commands.CreateSale;
using FluentValidation;
namespace DevStore.Application.Validators;
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidator(){
        RuleForEach(x=>x.Items).SetValidator(new SaleItemDtoValidator());
    }
}
