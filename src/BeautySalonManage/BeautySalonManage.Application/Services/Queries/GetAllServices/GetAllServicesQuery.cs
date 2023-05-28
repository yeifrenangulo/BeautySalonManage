using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Services.Queries.GetAllServices;

public class GetAllServicesQuery : IRequest<Response<List<ServiceCollaboratorDto>>> { }