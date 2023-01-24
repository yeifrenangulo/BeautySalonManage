using AutoMapper;
using BeautySalonManage.Application.DTOs;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Specifications;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Features.Services.Queries
{
    public class GetAllServicesQuery : IRequest<PagedResponse<List<ServiceDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, PagedResponse<List<ServiceDTO>>>
    {
        private readonly IRepositoryAsync<Service> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllServicesQueryHandler(IRepositoryAsync<Service> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<ServiceDTO>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            int count = await _repositoryAsync.CountAsync(cancellationToken);

            List<Service> services = await _repositoryAsync.ListAsync(new ServiceSpecification(request.PageNumber, request.PageSize), cancellationToken);

            List<ServiceDTO> servicesDTO = _mapper.Map<List<ServiceDTO>>(services);
            return new PagedResponse<List<ServiceDTO>>(servicesDTO, request.PageNumber, request.PageSize, count);
        }
    }
}
