using FluentValidation;

namespace BeautySalonManage.Application.Turns.Commands.Update.UpdateTurn;

public class UpdateTurnCommandValidator : AbstractValidator<UpdateTurnCommand>
{
    public UpdateTurnCommandValidator()
    {
        RuleFor(p => p.Id)
            .GreaterThan(0).WithMessage(p => "El Id no debe estar vacio");

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
