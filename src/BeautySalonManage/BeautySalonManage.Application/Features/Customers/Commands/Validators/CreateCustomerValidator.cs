using BeautySalonManage.Application.Features.Clients.Commands;
using BeautySalonManage.Application.Utilities;
using FluentValidation;

namespace BeautySalonManage.Application.Features.Customers.Commands.Validators
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        const string ElCampo = "El campo";
        const string EsRequerido = "es obligatorio";
        const string DebeTenerMaximo = "debe tener máximo";
        const string Caracteres = "caracteres";
        const string ElNumero = "El número de";
        const string NoValido = "no es válido";

        public CreateCustomerValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.Name))} {EsRequerido}")
                .MaximumLength(30).WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.Name))} {DebeTenerMaximo} 30 {Caracteres}");

            RuleFor(p => p.Surname)
                .NotEmpty().WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.Surname))} {EsRequerido}")
                .MaximumLength(30).WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.Surname))} {DebeTenerMaximo} 30 {Caracteres}");

            RuleFor(p => p.Phone)
                .NotEmpty().WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.Phone))} {EsRequerido}")
                .Matches(@"^\d+$").WithMessage(p => $"{ElNumero} {p.GetDisplayName(nameof(p.Phone))} {NoValido}")
                .MaximumLength(15).WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.Phone))} {DebeTenerMaximo} 15 {Caracteres}");

            RuleFor(p => p.GenderId)
                .NotEqual(0).WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.GenderId))} {EsRequerido}");
        }
    }
}
