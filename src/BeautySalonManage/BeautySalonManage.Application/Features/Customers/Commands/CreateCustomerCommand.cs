using AutoMapper;
using BeautySalonManage.Application.Exceptions;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Specifications.Customer;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BeautySalonManage.Application.Features.Clients.Commands
{
    public class CreateCustomerCommand : IRequest<Response<int>>
    {
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        public string Surname { get; set; }

        [Display(Name = "Celular")]
        public string Phone { get; set; }

        [Display(Name = "Fecha de Cumpleaños")]
        public DateTime? DateBirth { get; set; }

        [Display(Name = "Género")]
        public int GenderId { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Customer> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await _repositoryAsync.FirstOrDefaultAsync(new CustomerSpecification(request.Name, request.Surname), cancellationToken);

            if (customer != null)
                throw new ApiException($"El cliente {request.Name} {request.Surname} ya se encuentra registrado.");

            var newRecord = _mapper.Map<Customer>(request);
            var data = await _repositoryAsync.AddAsync(newRecord, cancellationToken);

            return new Response<int>(data.CustomerId);
        }
    }
}
