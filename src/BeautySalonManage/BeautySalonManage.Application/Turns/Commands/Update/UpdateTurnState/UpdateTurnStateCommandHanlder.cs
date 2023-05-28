using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Turns.Commands.Update.UpdateTurnState;

public class UpdateTurnStateCommandHanlder : IRequestHandler<UpdateTurnStateCommand, Response<bool>>
{
    private readonly IRepositoryAsync<Turn> _repository;

    public UpdateTurnStateCommandHanlder(IRepositoryAsync<Turn> repository)
    {
        _repository = repository;
    }

    public async Task<Response<bool>> Handle(UpdateTurnStateCommand request, CancellationToken cancellationToken)
    {
        Turn turn = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"El turno con ID {request.Id} no se encuentra registrado");

        turn.StateId = request.StateId;

        await _repository.UpdateAsync(turn, cancellationToken);

        return new Response<bool>(true);
    }
}