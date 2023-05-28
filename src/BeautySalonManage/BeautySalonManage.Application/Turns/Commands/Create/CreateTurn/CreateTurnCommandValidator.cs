using FluentValidation;

namespace BeautySalonManage.Application.Turns.Commands.Create.CreateTurn;

public class CreateTurnCommandValidator : AbstractValidator<CreateTurnCommand>
{
    public CreateTurnCommandValidator()
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

        RuleFor(p => p.StartDate)
            .NotEmpty().WithMessage(p => $"El campo Fecha es obligatorio")
            .NotEqual(DateTime.MinValue).WithMessage(p => $"El campo Fecha es obligatorio");

        RuleFor(p => p.StartTime)
            .NotEmpty().WithMessage(p => $"El campo Hora Inicio es obligatorio");

        RuleFor(p => p.EndTime)
            .NotEmpty().WithMessage(p => $"El campo Hora Fin es obligatorio");
    }
}
