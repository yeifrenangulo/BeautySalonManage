using BeautySalonManage.Application.DTOs.Users;
using BeautySalonManage.Application.Exceptions;
using BeautySalonManage.Application.Helpers.Enumerations;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Specifications;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Features.Authenticate.Commands
{
    public class AuthenticateCommand : IRequest<Response<AuthenticationResponse>>
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
    }

    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, Response<AuthenticationResponse>>
    {
        private readonly IAccountService _accountService;
        private readonly IRepositoryAsync<User> _repositoryAsync;
        private readonly IRepositoryAsync<Customer> _repositoryCustomerAsync;
        private readonly IRepositoryAsync<Collaborator> _repositoryCollaboratorAsync;

        public AuthenticateCommandHandler(IAccountService accountService, IRepositoryAsync<User> repositoryAsync, IRepositoryAsync<Customer> repositoryCustomerAsync, IRepositoryAsync<Collaborator> repositoryCollaboratorAsync)
        {
            _accountService = accountService;
            _repositoryAsync = repositoryAsync;
            _repositoryCustomerAsync = repositoryCustomerAsync;
            _repositoryCollaboratorAsync = repositoryCollaboratorAsync;
        }

        public async Task<Response<AuthenticationResponse>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            User user = await _repositoryAsync.FirstOrDefaultAsync(new AuthtenticateSpecification(request.User, request.Password), cancellationToken);

            if (user == null)
                throw new ApiException("Usuario o contraseña inválida");

            if (!user.IsActive)
                throw new ApiException($"El usuario {request.User} está bloqueado");

            var auth = await _accountService.AuthenticateAsync(user, request.IpAddress);

            switch (user.TypeUserId)
            {
                case (int)TypeUserEnum.Colaborador:
                    Collaborator collaborator = await _repositoryCollaboratorAsync.FirstOrDefaultAsync(new CollaboratorSpecification(user.RelatedUser), cancellationToken);
                    auth.FullName = $"{collaborator?.Name} {collaborator?.Surname}";
                    break;
                case (int)TypeUserEnum.Cliente:
                    Customer customer = await _repositoryCustomerAsync.FirstOrDefaultAsync(new CustomerSpecification(user.RelatedUser), cancellationToken);
                    auth.FullName = $"{customer?.Name} {customer?.Surname}";
                    break;
                default:
                    auth.FullName = "";
                    break;
            }

            return new Response<AuthenticationResponse>(auth);
        }
    }
}
