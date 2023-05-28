using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Customers.Commands.Delete.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Response<int>>
{
    private readonly IRepositoryAsync<Customer> _repository;

    public DeleteCustomerCommandHandler(IRepositoryAsync<Customer> repository)
    {
        _repository = repository;
    }

    public async Task<Response<int>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"El cliente con ID {request.Id} no se encuentra registrado.");

        await _repository.DeleteAsync(customer, cancellationToken);

        return new Response<int>(customer.Id, "El cliente se eliminó exitosamente");
    }
}