using DevStore.Application.Commands.UpdateSale;
using FluentValidation;
namespace DevStore.Application.Validators;
public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
{
    public UpdateSaleCommandValidator(){
        RuleForEach(x=>x.Items).SetValidator(new SaleItemDtoValidator());
    }
}
