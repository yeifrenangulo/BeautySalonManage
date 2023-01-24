using BeautySalonManage.Application.Extensions;
using FluentValidation;

namespace BeautySalonManage.Application.Features.Services.Commands.Create
{
    public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
    {
        const string ElCampo = "El campo";
        const string EsRequerido = "es obligatorio";
        const string DebeTenerMaximo = "debe tener máximo";
        const string Caracteres = "caracteres";

        public CreateServiceCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.Title))} {EsRequerido}")
                .MaximumLength(30).WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.Title))} {DebeTenerMaximo} 30 {Caracteres}");

            RuleFor(p => p.Detail)
                .NotEmpty().WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.Detail))} {EsRequerido}")
                .MaximumLength(100).WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.Detail))} {DebeTenerMaximo} 100 {Caracteres}");

            RuleFor(p => p.Duration)
                .NotEmpty().WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.Duration))} {EsRequerido}");

            RuleFor(p => p.Price)
                .NotEqual(0).WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.Price))} {EsRequerido}");
        }
    }
}
