using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Customers.Commands.Update.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<int>>
{
    private readonly IRepositoryAsync<Customer> _repository;

    public UpdateCustomerCommandHandler(IRepositoryAsync<Customer> repository)
    {
        _repository = repository;
    }

    public async Task<Response<int>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"El cliente con ID {request.Id} no se encuentra registrado.");

        customer.Phone = request.Phone;
        customer.DateBirth = request.DateBirth;
        customer.GenderId = request.GenderId;

        await _repository.UpdateAsync(customer, cancellationToken);

        return new Response<int>(customer.Id, "El cliente se actualizó exitosamente");
    }
}

