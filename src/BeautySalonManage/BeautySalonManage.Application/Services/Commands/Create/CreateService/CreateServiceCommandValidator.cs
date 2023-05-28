using FluentValidation;

namespace BeautySalonManage.Application.Services.Commands.Create.CreateService;

public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
{
    public CreateServiceCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage(p => $"El campo Titulo es obligatorio")
            .MaximumLength(30).WithMessage(p => $"El campo Titulo debe tener máximo 30 caracteres");

        RuleFor(p => p.Detail)
            .NotEmpty().WithMessage(p => $"El campo Detalle es obligatorio")
            .MaximumLength(100).WithMessage(p => $"El campo Detalle debe tener máximo 100 caracteres");

        RuleFor(p => p.Duration)
            .NotEmpty().WithMessage(p => $"El campo Duración es obligatorio");

        RuleFor(p => p.Price)
            .NotEqual(0).WithMessage(p => $"El campo Precio es obligatorio");
    }
}
