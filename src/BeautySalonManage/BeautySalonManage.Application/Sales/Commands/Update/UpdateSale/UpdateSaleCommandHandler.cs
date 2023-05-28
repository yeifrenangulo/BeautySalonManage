using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Sales.Commands.Update.UpdateSale;

public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, Response<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryAsync<Sale> _repositorySale;
    private readonly IRepositoryAsync<SaleDetail> _repositorySaleDetail;
    private readonly IRepositoryAsync<SaleAdditionalDetail> _repositorySaleAdditionalDetail;

    public UpdateSaleCommandHandler(
        IUnitOfWork unitOfWork, 
        IRepositoryAsync<Sale> repositorySale, 
        IRepositoryAsync<SaleDetail> repositorySaleDetail, 
        IRepositoryAsync<SaleAdditionalDetail> repositorySaleAdditionalDetail)
    {
        _unitOfWork = unitOfWork;
        _repositorySale = repositorySale;
        _repositorySaleDetail = repositorySaleDetail;
        _repositorySaleAdditionalDetail = repositorySaleAdditionalDetail;
    }

    public async Task<Response<bool>> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        Sale sale = await _repositorySale.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"La venta con ID {request.Id} no se encuentra registrada");

        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            sale.NameCustomer = request.NameCustomer;
            sale.PhoneCustomer = request.PhoneCustomer;
            sale.DateSale = request.DateSale;
            sale.Observation = request.Observation;
            sale.Amount = request.Amount;

            await _repositorySale.UpdateAsync(sale, cancellationToken);

            await _repositorySaleDetail.DeleteRangeAsync(x => x.SaleId == request.Id, cancellationToken);
            await _repositorySaleAdditionalDetail.DeleteRangeAsync(x => x.SaleId == request.Id, cancellationToken);

            if (request.Details != null && request.Details.Any()) 
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

            if (request.AdditionalDetails != null && request.AdditionalDetails.Any())
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
