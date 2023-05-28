using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Sales.Commands.Delete.DeleteSale;

public class DeleteSaleCommandHandler : IRequestHandler<DeleteSaleCommand, Response<bool>>
{
    private readonly IRepositoryAsync<Sale> _repositorySale;

    public DeleteSaleCommandHandler(IRepositoryAsync<Sale> repositorySale)
    {
        _repositorySale = repositorySale;
    }

    public async Task<Response<bool>> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        Sale sale = await _repositorySale.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"La venta con ID {request.Id} no se encuentra registrada");

        sale.IsActive = false;

        await _repositorySale.UpdateAsync(sale, cancellationToken);

        return new Response<bool>(true);
    }
}
