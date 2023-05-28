using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Services.Commands.Delete.DeleteService;

public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, Response<int>>
{
    private readonly IRepositoryAsync<Service> _repository;

    public DeleteServiceCommandHandler(IRepositoryAsync<Service> repository)
    {
        _repository = repository;
    }

    public async Task<Response<int>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        Service service = await _repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"El servicio con ID {request.Id} no se encuentra registrado.");

        service.IsActive = false;

        await _repository.UpdateAsync(service, cancellationToken);

        return new Response<int>(service.Id, "El servicio se eliminó exitosamente");
    }
}