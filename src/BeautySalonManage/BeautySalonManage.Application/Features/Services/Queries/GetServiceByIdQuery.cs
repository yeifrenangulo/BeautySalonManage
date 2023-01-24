using AutoMapper;
using BeautySalonManage.Application.DTOs;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Specifications;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Features.Services.Queries
{
    public class GetServiceByIdQuery : IRequest<Response<ServiceDTO>>
    {
        public int ServiceId { get; set; }
    }

    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, Response<ServiceDTO>>
    {
        private readonly IRepositoryAsync<Service> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetServiceByIdQueryHandler(IRepositoryAsync<Service> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<ServiceDTO>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            Service service = await _repositoryAsync.FirstOrDefaultAsync(new ServiceSpecification(request.ServiceId), cancellationToken);

            if (service is null)
                throw new KeyNotFoundException($"El servicio con ID {request.ServiceId} no se encuentra registrado.");

            ServiceDTO dto = _mapper.Map<ServiceDTO>(service);

            return new Response<ServiceDTO>(dto);
        }
    }
}
