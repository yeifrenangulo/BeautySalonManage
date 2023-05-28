using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Collaborators.Commands.Delete.DeleteCollaborator;

public class DeleteCollaboratorCommandHandler : IRequestHandler<DeleteCollaboratorCommand, Response<int>>
{
    private readonly IRepositoryAsync<Collaborator> _repository;

    public DeleteCollaboratorCommandHandler(IRepositoryAsync<Collaborator> repository)
    {
        _repository = repository;
    }

    public async Task<Response<int>> Handle(DeleteCollaboratorCommand request, CancellationToken cancellationToken)
    {
        Collaborator collaborator = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"El colaborador con ID {request.Id} no se encuentra registrado");

        collaborator.IsActive = false;

        await _repository.UpdateAsync(collaborator, cancellationToken);

        return new Response<int>(request.Id);
    }
}