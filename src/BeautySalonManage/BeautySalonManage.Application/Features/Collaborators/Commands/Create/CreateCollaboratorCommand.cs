using AutoMapper;
using BeautySalonManage.Application.DTOs;
using BeautySalonManage.Application.Exceptions;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Specifications;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BeautySalonManage.Application.Features.Collaborators.Commands.Create
{
    public class CreateCollaboratorCommand : IRequest<Response<int>>
    {
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        public string Surname { get; set; }

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

    public class CreateCollaboratorCommandHandler : IRequestHandler<CreateCollaboratorCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Collaborator> _repositoryAsync;
        private readonly IRepositoryAsync<CollaboratorService> _repositoryAsyncCollaboratorService;
        private readonly IMapper _mapper;

        public CreateCollaboratorCommandHandler(IRepositoryAsync<Collaborator> repositoryAsync, IMapper mapper, IRepositoryAsync<CollaboratorService> repositoryAsyncCollaboratorService)
        {
            _repositoryAsyncCollaboratorService = repositoryAsyncCollaboratorService;
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCollaboratorCommand request, CancellationToken cancellationToken)
        {
            Collaborator collaborator = await _repositoryAsync.FirstOrDefaultAsync(new CollaboratorSpecification(request.Name, request.Surname), cancellationToken);

            if (collaborator != null)
            {
                throw new ApiException($"El colaborador {request.Name} {request.Surname} ya se encuentra registrado.");
            }

            var entity = _mapper.Map<Collaborator>(request);
            var data = await _repositoryAsync.AddAsync(entity, cancellationToken);

            if (data != null && request.Services.Any()) 
            {
                List<CollaboratorService> collaboratorServices = new();

                foreach (var service in request.Services)
                {
                    collaboratorServices.Add(new CollaboratorService { 
                        CollaboratorId = data.CollaboratorId, 
                        ServiceId = service.ServiceId, 
                        Percentage = service.Percentage
                    });
                }

                await _repositoryAsyncCollaboratorService.AddRangeAsync(collaboratorServices, cancellationToken);
            }

            return new Response<int>(data.CollaboratorId, "El colaborador se registro exitosamente");
        }
    }
}
