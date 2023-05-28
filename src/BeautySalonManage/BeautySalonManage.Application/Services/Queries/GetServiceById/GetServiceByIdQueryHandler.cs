using AutoMapper;
using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Application.Common.Specifications;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Services.Queries.GetServiceById;

public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, Response<ServiceDto>>
{
    private readonly IRepositoryAsync<Service> _repository;
    private readonly IMapper _mapper;

    public GetServiceByIdQueryHandler(IRepositoryAsync<Service> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<ServiceDto>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        Service service = await _repository.FirstOrDefaultAsync(new ServiceSpecification(request.ServiceId), cancellationToken)
            ?? throw new KeyNotFoundException($"El servicio con ID {request.ServiceId} no se encuentra registrado.");

        ServiceDto serviceDto = _mapper.Map<ServiceDto>(service);

        return new Response<ServiceDto>(serviceDto);
    }
}