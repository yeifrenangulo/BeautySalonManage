using AutoMapper;
using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Application.Common.Specifications;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Sales.Queries.GetAllSales;

public class GetAllSalesQueryHandler : IRequestHandler<GetAllSalesQuery, PagedResponse<List<SaleDto>>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryAsync<Sale> _repository;

    public GetAllSalesQueryHandler(IMapper mapper, IRepositoryAsync<Sale> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<PagedResponse<List<SaleDto>>> Handle(GetAllSalesQuery request, CancellationToken cancellationToken)
    {
        int count = await _repository.CountAsync(cancellationToken);

        List<SaleDto> sales = (await _repository.ListAsync(new SaleSpecification(request), cancellationToken))
            .ProjectToList<Sale, SaleDto>(_mapper.ConfigurationProvider);

        return new PagedResponse<List<SaleDto>>(sales, request.PageNumber, request.PageSize, count);
    }
}