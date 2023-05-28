using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Genders.Queries.GetGenders;

public class GetGendersQuery : IRequest<Response<List<GenderDto>>> { }
