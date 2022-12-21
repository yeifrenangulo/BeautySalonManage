using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Features.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest<Response<int>>
    {
        public int CustomerId { get; set; }
    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Customer> _repositoryAsync;

        public DeleteCustomerCommandHandler(IRepositoryAsync<Customer> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await _repositoryAsync.GetByIdAsync(request.CustomerId, cancellationToken);

            if (customer is null)
                throw new KeyNotFoundException($"El cliente con ID {request.CustomerId} no se encuentra registrado.");

            await _repositoryAsync.DeleteAsync(customer, cancellationToken);

            return new Response<int>(customer.CustomerId);
        }
    }
}
