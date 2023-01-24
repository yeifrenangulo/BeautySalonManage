using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Features.Services.Commands.Delete
{
    public class DeleteServiceCommand : IRequest<Response<int>>
    {
        public int ServiceId { get; set; }
    }

    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Service> _repositoryAsync;

        public DeleteServiceCommandHandler(IRepositoryAsync<Service> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            Service service = await _repositoryAsync.GetByIdAsync(request.ServiceId, cancellationToken);

            if (service is null)
                throw new KeyNotFoundException($"El servicio con ID {request.ServiceId} no se encuentra registrado.");

            service.IsActive = false;

            await _repositoryAsync.UpdateAsync(service, cancellationToken);

            return new Response<int>(service.ServiceId, "El servicio se eliminó exitosamente");
        }
    }
}
