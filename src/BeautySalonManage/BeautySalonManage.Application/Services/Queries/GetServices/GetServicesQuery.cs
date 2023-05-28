using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Services.Queries.GetServices;

public class GetServicesQuery : RequestParameter, IRequest<PagedResponse<List<ServiceDto>>>
{
}