using AutoMapper;
using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Exceptions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Customers.Commands.Create.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<int>>
{
    private readonly IRepositoryAsync<Customer> _repository;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(IRepositoryAsync<Customer> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer = await _repository.FirstOrDefaultAsync(x => x.Name == request.Name && x.Surname == request.Surname, cancellationToken);

        if (customer != null)
        {
            throw new ApiException($"El cliente {request.Name} {request.Surname} ya se encuentra registrado.");
        }

        customer = _mapper.Map<Customer>(request);
        await _repository.AddAsync(customer, cancellationToken);

        return new Response<int>(customer.Id, "El cliente se registro exitosamente");
    }
}