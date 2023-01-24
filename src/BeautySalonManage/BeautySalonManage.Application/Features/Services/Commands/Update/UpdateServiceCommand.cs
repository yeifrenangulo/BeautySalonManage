using BeautySalonManage.Application.Features.Customers.Commands;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BeautySalonManage.Application.Features.Services.Commands.Update
{
    public class UpdateServiceCommand : IRequest<Response<int>>
    {
        public int ServiceId { get; set; }

        [Display(Name = "Nombre")]
        public string Title { get; set; }

        [Display(Name = "Detalle")]
        public string Detail { get; set; }

        [Display(Name = "Duración")]
        public string Duration { get; set; }

        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        public string UserName { get; set; }
    }

    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Service> _repositoryAsync;

        public UpdateServiceCommandHandler(IRepositoryAsync<Service> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            Service service = await _repositoryAsync.GetByIdAsync(request.ServiceId, cancellationToken);

            if (service is null)
                throw new KeyNotFoundException($"El servicio con ID {request.ServiceId} no se encuentra registrado.");

            service.Title = request.Title;
            service.Detail = request.Detail;
            service.Duration = request.Duration;
            service.Price = request.Price;
            service.LastModifiedBy = request.UserName;

            await _repositoryAsync.UpdateAsync(service, cancellationToken);

            return new Response<int>(service.ServiceId, "El servicio se modificó exitosamente");
        }
    }
}
