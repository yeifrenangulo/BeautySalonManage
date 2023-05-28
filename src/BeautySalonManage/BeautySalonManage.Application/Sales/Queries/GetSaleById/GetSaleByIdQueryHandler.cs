using AutoMapper;
using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Application.Common.Specifications;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Sales.Queries.GetSaleById;

public class GetSaleByIdQueryHandler : IRequestHandler<GetSaleByIdQuery, Response<SaleDto>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryAsync<Sale> _repository;

    public GetSaleByIdQueryHandler(IMapper mapper, IRepositoryAsync<Sale> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<SaleDto>> Handle(GetSaleByIdQuery request, CancellationToken cancellationToken)
    {
        Sale sale = await _repository.FirstOrDefaultAsync(new SaleSpecification(request.Id), cancellationToken)
            ?? throw new KeyNotFoundException($"La venta con ID {request.Id} no se encuentra registrada");

        SaleDto saleDto = _mapper.Map<SaleDto>(sale);

        return new Response<SaleDto>(saleDto);
    }
}
