using FluentValidation;

namespace BeautySalonManage.Application.Collaborators.Commands.Create.CreateCollaborator;

public class CreateCollaboratorCommandValidator : AbstractValidator<CreateCollaboratorCommand>
{
    public CreateCollaboratorCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage(p => $"El campo Nombre es obligatorio")
            .MaximumLength(30).WithMessage(p => $"El campo Nombre debe tener máximo 30 caracteres");

        RuleFor(p => p.Surname)
            .NotEmpty().WithMessage(p => $"El campo Apellido es obligatorio")
            .MaximumLength(30).WithMessage(p => $"El campo Apellido debe tener máximo 30 caracteres");

        RuleFor(p => p.Phone)
            .NotEmpty().WithMessage(p => $"El campo Teléfono es obligatorio")
            .Matches(@"^\d+$").WithMessage(p => $"El número de Teléfono no es válido")
            .MaximumLength(15).WithMessage(p => $"El campo Teléfono debe tener máximo 15 caracteres");

        RuleFor(p => p.Address)
            .NotEmpty().WithMessage(p => $"El campo Dirección es obligatorio")
            .MaximumLength(30).WithMessage(p => $"El campo Dirección debe tener máximo 30 caracteres");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage(p => $"El campo Correo Electrónico es obligatorio")
            .EmailAddress().WithMessage(p => $"El campo Correo Electrónico no es válido")
            .MaximumLength(30).WithMessage(p => $"El campo Correo Electrónico debe tener máximo 30 caracteres");

        RuleFor(p => p.NameContact)
            .MaximumLength(30).WithMessage(p => $"El campo Nombre de Contacto debe tener máximo 30 caracteres");

        RuleFor(p => p.PhoneContact)
            .MaximumLength(15).WithMessage(p => $"El campo Teléfono de Contacto debe tener máximo 15 caracteres");

        RuleFor(p => p.GenderId)
            .NotEqual(0).WithMessage(p => $"El campo Género es obligatorio");
    }
}
