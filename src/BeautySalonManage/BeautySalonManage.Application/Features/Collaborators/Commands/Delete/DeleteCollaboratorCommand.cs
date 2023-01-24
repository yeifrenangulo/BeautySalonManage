using BeautySalonManage.Application.Features.Collaborators.Commands.Update;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Specifications;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonManage.Application.Features.Collaborators.Commands.Delete
{
    public class DeleteCollaboratorCommand : IRequest<Response<int>>
    {
        public int CollaboratorId { get; set; }
    }

    public class DeleteCollaboratorCommandHandler : IRequestHandler<DeleteCollaboratorCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Collaborator> _repositoryAsync;

        public DeleteCollaboratorCommandHandler(IRepositoryAsync<Collaborator> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteCollaboratorCommand request, CancellationToken cancellationToken)
        {
            Collaborator collaborator = await _repositoryAsync.FirstOrDefaultAsync(new CollaboratorSpecification(request.CollaboratorId), cancellationToken);

            if (collaborator == null)
                throw new KeyNotFoundException($"El colaborador con ID {request.CollaboratorId} no se encuentra registrado");

            collaborator.IsActive = false;

            await _repositoryAsync.UpdateAsync(collaborator, cancellationToken);

            return new Response<int>(request.CollaboratorId);
        }
    }
}
