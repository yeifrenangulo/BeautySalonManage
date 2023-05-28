using FluentValidation;

namespace BeautySalonManage.Application.Customers.Commands.Update.UpdateCustomer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(p => p.Phone)
            .NotEmpty().WithMessage(p => "El campo Celular es obligatorio")
            .Matches(@"^\d+$").WithMessage(p => "El número de celular no es válido")
            .MaximumLength(15).WithMessage(p => "El campo Celular debe tener máximo {MaxLength} caracteres");

        RuleFor(p => p.GenderId)
            .NotEqual(0).WithMessage(p => $"El campo Género es obligatorio");
    }
}
