using AutoMapper;
using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Services.Commands.Create.CreateService;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Response<int>>
{
    private readonly IRepositoryAsync<Service> _repository;
    private readonly IMapper _mapper;

    public CreateServiceCommandHandler(IRepositoryAsync<Service> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        Service entity = _mapper.Map<Service>(request);
        await _repository.AddAsync(entity, cancellationToken);

        return new Response<int>(entity.Id, "El servicio se registro exitosamente");
    }
}