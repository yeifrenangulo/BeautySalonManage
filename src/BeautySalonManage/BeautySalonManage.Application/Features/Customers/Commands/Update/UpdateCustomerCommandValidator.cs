using BeautySalonManage.Application.Extensions;
using FluentValidation;

namespace BeautySalonManage.Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        const string ElCampo = "El campo";
        const string EsRequerido = "es obligatorio";
        const string DebeTenerMaximo = "debe tener máximo";
        const string Caracteres = "caracteres";
        const string ElNumero = "El número de";
        const string NoValido = "no es válido";

        public UpdateCustomerCommandValidator()
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
