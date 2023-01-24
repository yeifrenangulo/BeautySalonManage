using AutoMapper;
using BeautySalonManage.Application.DTOs.Turns;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Specifications;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Features.Turns.Queries
{
    public class GetAllTurnsQuery : IRequest<Response<List<TurnDTO>>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class GetAllTurnsQueryHandler : IRequestHandler<GetAllTurnsQuery, Response<List<TurnDTO>>>
    {
        private readonly IRepositoryAsync<Turn> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllTurnsQueryHandler(IRepositoryAsync<Turn> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<List<TurnDTO>>> Handle(GetAllTurnsQuery request, CancellationToken cancellationToken)
        {
            List<Turn> turns = await _repositoryAsync.ListAsync(new TurnSpecification(request.StartDate, request.EndDate), cancellationToken);

            List<TurnDTO> turnDTO = _mapper.Map<List<TurnDTO>>(turns);
            return new Response<List<TurnDTO>>(turnDTO);
        }
    }
}
