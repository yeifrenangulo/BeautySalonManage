using FluentValidation;

namespace BeautySalonManage.Application.Sales.Commands.Create.CreateSale;

public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidator()
    {
        RuleFor(p => p.NameCustomer)
            .NotEmpty().WithMessage(p => $"El campo Nombre de Cliente es obligatorio")
            .MaximumLength(40).WithMessage(p => $"El campo Nombre de Cliente debe tener máximo 40 caracteres");

        RuleFor(p => p.PhoneCustomer)
            .NotEmpty().WithMessage(p => $"El campo Teléfono de Cliente es obligatorio")
            .Matches(@"^\d+$").WithMessage(p => $"El número de Teléfono de Cliente no es válido")
            .MaximumLength(15).WithMessage(p => $"El campo Teléfono de Cliente debe tener máximo 15 caracteres");

        RuleFor(p => p.Observation)
            .MaximumLength(50).WithMessage(p => "El campo Observación debe tener máximo 50 caracteres");

        RuleFor(p => p.DateSale)
            .NotEmpty().WithMessage(p => $"El campo Fecha es obligatorio")
            .NotEqual(DateTime.MinValue).WithMessage(p => $"El campo Fecha es obligatorio");
    }
}