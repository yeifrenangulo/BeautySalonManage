using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Domain.Entities;
using FluentValidation;

namespace BeautySalonManage.Application.Turns.Commands.Update.UpdateTurnState;

public class UpdateTurnStateCommandValidator : AbstractValidator<UpdateTurnStateCommand>
{
    private readonly IRepositoryAsync<State> _repository;

    public UpdateTurnStateCommandValidator(IRepositoryAsync<State> repository)
    {
        _repository = repository;

        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("El Id no debe estar vacio");

        RuleFor(p => p.StateId)
            .GreaterThan(0).WithMessage("El Estado debe ser obligatorio")
            .MustAsync(ValidateState).WithMessage("El Estado no se encuentra registrado");

    }

    private async Task<bool> ValidateState(int value, CancellationToken cancellationToken)
    {
        State state = await _repository.FirstOrDefaultAsync(p => p.Id == value, cancellationToken);

        if (state == null)
        {
            return false;
        }

        return true;
    }
}
