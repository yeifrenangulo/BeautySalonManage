using FluentValidation;

namespace BeautySalonManage.Application.Collaborators.Commands.Update.UpdateCollaborator;

public class UpdateCollaboratorCommandValidator : AbstractValidator<UpdateCollaboratorCommand>
{
    public UpdateCollaboratorCommandValidator()
    {
        RuleFor(p => p.Phone)
            .NotEmpty().WithMessage(p => "El campo Teléfono es obligatorio")
            .Matches(@"^\d+").WithMessage(p => "El número Teléfono no es válido")
            .MaximumLength(15).WithMessage(p => "El campo Teléfono debe tener máximo 15 caracteres");

        RuleFor(p => p.Address)
            .NotEmpty().WithMessage(p => "El campo Dirección es obligatorio")
            .MaximumLength(30).WithMessage(p => "El campo Dirección debe tener máximo 30 caracteres");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage(p => "El campo Correo Electrónico es obligatorio")
            .EmailAddress().WithMessage(p => "El campo Correo Electrónico no es válido")
            .MaximumLength(30).WithMessage(p => "El campo Correo Electrónico debe tener máximo 30 caracteres");

        RuleFor(p => p.NameContact)
            .MaximumLength(30).WithMessage(p => "El campo Nombre de Contacto debe tener máximo 30 caracteres");

        RuleFor(p => p.PhoneContact)
            .MaximumLength(15).WithMessage(p => "El campo Teléfono de Contacto debe tener máximo 15 caracteres");

        RuleFor(p => p.GenderId)
            .NotEqual(0).WithMessage(p => "El campo Género es obligatorio");
    }
}
