using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Services.Commands.Update.UpdateService;

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Response<int>>
{
    private readonly IRepositoryAsync<Service> _repository;

    public UpdateServiceCommandHandler(IRepositoryAsync<Service> repository)
    {
        _repository = repository;
    }

    public async Task<Response<int>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        Service service = await _repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"El servicio con ID {request.Id} no se encuentra registrado.");

        service.Title = request.Title;
        service.Detail = request.Detail;
        service.Duration = request.Duration;
        service.Price = request.Price;
        service.Color = request.Color;

        await _repository.UpdateAsync(service, cancellationToken);

        return new Response<int>(service.Id, "El servicio se modificó exitosamente");
    }
}