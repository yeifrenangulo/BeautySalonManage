using AutoMapper;
using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Sales.Commands.Create.CreateSale;

public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, Response<bool>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryAsync<Sale> _repositorySale;
    private readonly IRepositoryAsync<SaleDetail> _repositorySaleDetail;
    private readonly IRepositoryAsync<SaleAdditionalDetail> _repositorySaleAdditionalDetail;

    public CreateSaleCommandHandler(
        IMapper mapper, 
        IUnitOfWork unitOfWork, 
        IRepositoryAsync<Sale> repositorySale, 
        IRepositoryAsync<SaleDetail> repositorySaleDetail, 
        IRepositoryAsync<SaleAdditionalDetail> repositorySaleAdditionalDetail)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repositorySale = repositorySale;
        _repositorySaleDetail = repositorySaleDetail;
        _repositorySaleAdditionalDetail = repositorySaleAdditionalDetail;
    }

    public async Task<Response<bool>> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        Sale sale = _mapper.Map<Sale>(request);

        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            await _repositorySale.AddAsync(sale, cancellationToken);

            if (request.Details.Any())
            {
                List<SaleDetail> saleDetails = new();

                foreach (var detail in request.Details)
                {
                    saleDetails.Add(new SaleDetail
                    {
                        SaleId = sale.Id,
                        CollaboratorId = detail.CollaboratorId,
                        ServiceId = detail.ServiceId,
                        Price = detail.Price
                    });
                }

                await _repositorySaleDetail.AddRangeAsync(saleDetails, cancellationToken);
            }

            if (request.AdditionalDetails.Any())
            {
                List<SaleAdditionalDetail> saleAdditionalDetails = new();

                foreach (var additionalDetail in request.AdditionalDetails)
                {
                    saleAdditionalDetails.Add(new SaleAdditionalDetail
                    {
                        SaleId = sale.Id,
                        CollaboratorId = additionalDetail.CollaboratorId,
                        Detail = additionalDetail.Detail,
                        Price = additionalDetail.Price
                    });
                }

                await _repositorySaleAdditionalDetail.AddRangeAsync(saleAdditionalDetails, cancellationToken);
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            return new Response<bool>(true);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync(cancellationToken);
            throw;
        }
    }
}