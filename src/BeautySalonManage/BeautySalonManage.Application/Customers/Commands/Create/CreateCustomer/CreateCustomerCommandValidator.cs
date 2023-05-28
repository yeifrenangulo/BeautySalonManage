using FluentValidation;

namespace BeautySalonManage.Application.Customers.Commands.Create.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage(p => "El campo Nombre es obligatorio")
            .MaximumLength(30).WithMessage(p => "El campo Nombre debe tener máximo {MaxLength} caracteres");

        RuleFor(p => p.Surname)
            .NotEmpty().WithMessage(p => "El campo Apellido es obligatorio")
            .MaximumLength(30).WithMessage(p => "El campo Apellido debe tener máximo {MaxLength} caracteres");

        RuleFor(p => p.Phone)
            .NotEmpty().WithMessage(p => "El campo Celular es obligatorio")
            .Matches(@"^\d+$").WithMessage(p => "El número de celular no es válido")
            .MaximumLength(15).WithMessage(p => "El campo Celular debe tener máximo {MaxLength} caracteres");

        RuleFor(p => p.GenderId)
            .NotEqual(0).WithMessage(p => "El campo Género es obligatorio");
    }
}
