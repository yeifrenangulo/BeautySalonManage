using AutoMapper;
using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Extensions;
using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Application.Common.Specifications;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Turns.Queries.GetAllTurns;

public class GetAllTurnsQueryHandler : IRequestHandler<GetAllTurnsQuery, Response<List<TurnDto>>>
{
    private readonly IRepositoryAsync<Turn> _repository;
    private readonly IMapper _mapper;

    public GetAllTurnsQueryHandler(IRepositoryAsync<Turn> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<List<TurnDto>>> Handle(GetAllTurnsQuery request, CancellationToken cancellationToken)
    {
        List<TurnDto> turns = (await _repository.ListAsync(new TurnSpecification(request.StartDate.GetInitialDate(), request.EndDate.GetFinalDate()), cancellationToken))
            .ProjectToList<Turn, TurnDto>(_mapper.ConfigurationProvider);

        return new Response<List<TurnDto>>(turns);
    }
}