using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Application.Sales.Queries;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Sales.Commands.Create.CreateSale;

public class CreateSaleCommand : IRequest<Response<bool>>, IMapFrom<Sale>
{
    public DateTime DateSale { get; set; }
    public string NameCustomer { get; set; }
    public string PhoneCustomer { get; set; }
    public string Observation { get; set; }
    public double Amount { get; set; }
    public long? TurnId { get; set; }

    public List<SaleDetailDto> Details { get; set; }
    public List<SaleAdditionalDetailDto> AdditionalDetails { get; set; }
}