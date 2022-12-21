using BeautySalonManage.Application.Utilities;
using FluentValidation;

namespace BeautySalonManage.Application.Features.Customers.Commands.Validators
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
    {
        const string ElCampo = "El campo";
        const string EsRequerido = "es obligatorio";
        const string DebeTenerMaximo = "debe tener máximo";
        const string Caracteres = "caracteres";
        const string ElNumero = "El número de";
        const string NoValido = "no es válido";

        public UpdateCustomerValidator()
        {
            RuleFor(p => p.Phone)
                .NotEmpty().WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.Phone))} {EsRequerido}")
                .Matches(@"^\d+$").WithMessage(p => $"{ElNumero} {p.GetDisplayName(nameof(p.Phone))} {NoValido}")
                .MaximumLength(15).WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.Phone))} {DebeTenerMaximo} 15 {Caracteres}");

            RuleFor(p => p.GenderId)
                .NotEqual(0).WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.GenderId))} {EsRequerido}");
        }
    }
}
