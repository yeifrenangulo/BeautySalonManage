using AutoMapper;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BeautySalonManage.Application.Features.Services.Commands.Create
{
    public class CreateServiceCommand : IRequest<Response<int>>
    {
        [Display(Name = "Nombre")]
        public string Title { get; set; }

        [Display(Name = "Detalle")]
        public string Detail { get; set; }

        [Display(Name = "Duración")]
        public string Duration { get; set; }

        [Display(Name = "Precio")]
        public decimal Price { get; set; }
    }

    public class CreateServiceHandler : IRequestHandler<CreateServiceCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Service> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateServiceHandler(IRepositoryAsync<Service> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Service>(request);
            var data = await _repositoryAsync.AddAsync(entity, cancellationToken);

            return new Response<int>(data.ServiceId, "El servicio se registro exitosamente");
        }
    }
}
