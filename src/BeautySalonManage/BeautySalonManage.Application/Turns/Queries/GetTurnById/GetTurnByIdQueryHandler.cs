using AutoMapper;
using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Application.Common.Specifications;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Turns.Queries.GetTurnById;

public class GetTurnByIdQueryHandler : IRequestHandler<GetTurnByIdQuery, Response<TurnDto>>
{
    private readonly IRepositoryAsync<Turn> _repository;
    private readonly IMapper _mapper;

    public GetTurnByIdQueryHandler(IRepositoryAsync<Turn> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<TurnDto>> Handle(GetTurnByIdQuery request, CancellationToken cancellationToken)
    {
        Turn turn = await _repository.FirstOrDefaultAsync(new TurnSpecification(request.Id), cancellationToken);

        TurnDto turnDTO = _mapper.Map<TurnDto>(turn);
        return new Response<TurnDto>(turnDTO);
    }
}