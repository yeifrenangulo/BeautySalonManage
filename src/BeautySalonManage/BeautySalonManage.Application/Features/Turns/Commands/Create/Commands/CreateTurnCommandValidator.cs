using BeautySalonManage.Application.Extensions;
using BeautySalonManage.Application.Features.Collaborators.Commands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonManage.Application.Features.Turns.Commands.Create.Commands
{
    public class CreateTurnCommandValidator : AbstractValidator<CreateTurnCommand>
    {
        const string ElCampo = "El campo";
        const string EsRequerido = "es obligatorio";
        const string DebeTenerMaximo = "debe tener máximo";
        const string Caracteres = "caracteres";
        const string ElNumero = "El número de";
        const string NoValido = "no es válido";

        public CreateTurnCommandValidator()
        {
            RuleFor(p => p.NameCustomer)
                .NotEmpty().WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.NameCustomer))} {EsRequerido}")
                .MaximumLength(40).WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.NameCustomer))} {DebeTenerMaximo} 40 {Caracteres}");

            RuleFor(p => p.PhoneCustomer)
                .NotEmpty().WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.PhoneCustomer))} {EsRequerido}")
                .Matches(@"^\d+$").WithMessage(p => $"{ElNumero} {p.GetDisplayName(nameof(p.PhoneCustomer))} {NoValido}")
                .MaximumLength(15).WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.PhoneCustomer))} {DebeTenerMaximo} 15 {Caracteres}");

            RuleFor(p => p.StartDate)
                .NotEmpty().WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.StartDate))} {EsRequerido}")
                .NotEqual(DateTime.MinValue).WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.StartDate))} {EsRequerido}");

            RuleFor(p => p.StartTime)
                .NotEmpty().WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.StartTime))} {EsRequerido}");

            RuleFor(p => p.EndTime)
                .NotEmpty().WithMessage(p => $"{ElCampo} {p.GetDisplayName(nameof(p.EndTime))} {EsRequerido}");
        }
    }
}
