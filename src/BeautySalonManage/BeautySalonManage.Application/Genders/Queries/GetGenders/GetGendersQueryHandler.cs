using AutoMapper;
using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Genders.Queries.GetGenders;

public class GetGendersQueryHandler : IRequestHandler<GetGendersQuery, Response<List<GenderDto>>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryAsync<Gender> _repository;

    public GetGendersQueryHandler(IRepositoryAsync<Gender> repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<List<GenderDto>>> Handle(GetGendersQuery request, CancellationToken cancellationToken)
    {
        List<GenderDto> genders = (await _repository.ListAsync(cancellationToken))
            .ProjectToList<Gender, GenderDto>(_mapper.ConfigurationProvider);

        return new Response<List<GenderDto>>(genders);
    }
}