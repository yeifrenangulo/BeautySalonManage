using AutoMapper;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BeautySalonManage.Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommand : IRequest<Response<int>>
    {
        public int CustomerId { get; set; }

        [Display(Name = "Celular")]
        public string Phone { get; set; }

        [Display(Name = "Fecha de Cumpleaños")]
        public DateTime? DateBirth { get; set; }

        [Display(Name = "Género")]
        public int GenderId { get; set; }
    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Customer> _repositoryAsync;

        public UpdateCustomerCommandHandler(IRepositoryAsync<Customer> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await _repositoryAsync.GetByIdAsync(request.CustomerId, cancellationToken);

            if (customer is null)
                throw new KeyNotFoundException($"El cliente con ID {request.CustomerId} no se encuentra registrado.");

            customer.Phone = request.Phone;
            customer.DateBirth = request.DateBirth;
            customer.GenderId = request.GenderId;

            await _repositoryAsync.UpdateAsync(customer, cancellationToken);

            return new Response<int>(customer.CustomerId, "El cliente se actualizó exitosamente");
        }
    }
}
