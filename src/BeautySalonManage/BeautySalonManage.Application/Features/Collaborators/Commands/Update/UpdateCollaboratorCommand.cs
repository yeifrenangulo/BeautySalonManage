using BeautySalonManage.Application.DTOs;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Specifications;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BeautySalonManage.Application.Features.Collaborators.Commands.Update
{
    public class UpdateCollaboratorCommand : IRequest<Response<int>>
    {
        public int CollaboratorId { get; set; }

        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Display(Name = "Nombre de Contacto")]
        public string NameContact { get; set; }

        [Display(Name = "Teléfono de Contacto")]
        public string PhoneContact { get; set; }

        [Display(Name = "Género")]
        public int GenderId { get; set; }

        public string Color { get; set; }
        public List<ServicePercentageDTO> Services { get; set; }
    }

    public class UpdateCollaboratorCommandHandler : IRequestHandler<UpdateCollaboratorCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Collaborator> _repositoryAsync;
        private readonly IRepositoryAsync<CollaboratorService> _repositoryAsyncCollaboratorService;

        public UpdateCollaboratorCommandHandler(IRepositoryAsync<Collaborator> repositoryAsync, IRepositoryAsync<CollaboratorService> repositoryAsyncCollaboratorService)
        {
            _repositoryAsync = repositoryAsync;
            _repositoryAsyncCollaboratorService = repositoryAsyncCollaboratorService;
        }

        public async Task<Response<int>> Handle(UpdateCollaboratorCommand request, CancellationToken cancellationToken)
        {
            Collaborator collaborator = await _repositoryAsync.FirstOrDefaultAsync(new CollaboratorSpecification(request.CollaboratorId), cancellationToken);

            if (collaborator == null)
                throw new KeyNotFoundException($"El colaborador con ID {request.CollaboratorId} no se encuentra registrado");

            collaborator.Phone = request.Phone;
            collaborator.Address = request.Address;
            collaborator.Email = request.Email;
            collaborator.NameContact = request.NameContact;
            collaborator.PhoneContact = request.PhoneContact;
            collaborator.GenderId = request.GenderId;
            collaborator.Color = request.Color;

            await _repositoryAsync.UpdateAsync(collaborator, cancellationToken);

            List<CollaboratorService> _collaboratorServices = 
                await _repositoryAsyncCollaboratorService.ListAsync(new CollaboratorServiceSpecification(request.CollaboratorId), cancellationToken);

            await _repositoryAsyncCollaboratorService.DeleteRangeAsync(_collaboratorServices, cancellationToken);

            if (request.Services.Any())
            {
                List<CollaboratorService> collaboratorServices = new();

                foreach (var service in request.Services)
                {
                    collaboratorServices.Add(new CollaboratorService
                    {
                        CollaboratorId = request.CollaboratorId,
                        ServiceId = service.ServiceId,
                        Percentage = service.Percentage
                    });
                }

                await _repositoryAsyncCollaboratorService.AddRangeAsync(collaboratorServices, cancellationToken);
            }

            return new Response<int>(request.CollaboratorId);
        }
    }
}
