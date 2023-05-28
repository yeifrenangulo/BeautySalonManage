using FluentValidation;

namespace BeautySalonManage.Application.Sales.Commands.Update.UpdateSale;

public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
{
    public UpdateSaleCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("El Id no debe estar vació");

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
