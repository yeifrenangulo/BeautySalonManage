using AutoMapper;
using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Enumerations;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Turns.Commands.Create.CreateTurn;

public class CreateTurnCommandHandler : IRequestHandler<CreateTurnCommand, Response<Guid>>
{
    private readonly IRepositoryAsync<Turn> _repository;
    private readonly IRepositoryAsync<TurnDetail> _repositoryDetailAsync;
    private readonly IRepositoryAsync<TurnAdditionalDetail> _repositoryAdditionalDetailAsync;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTurnCommandHandler(
        IRepositoryAsync<Turn> repository,
        IRepositoryAsync<TurnDetail> repositoryDetailAsync,
        IRepositoryAsync<TurnAdditionalDetail> repositoryAdditionalDetailAsync,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _repositoryDetailAsync = repositoryDetailAsync;
        _repositoryAdditionalDetailAsync = repositoryAdditionalDetailAsync;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<Guid>> Handle(CreateTurnCommand request, CancellationToken cancellationToken)
    {
        Turn entity = _mapper.Map<Turn>(request);
        entity.StateId = (int)StatusEnum.Pendiente;

        entity.Id = Guid.NewGuid();
        await _repository.InsertAsync(entity, cancellationToken);

        if (request.Details.Any())
        {
            List<TurnDetail> turnDetails = new();

            foreach (var turnDetail in request.Details)
            {
                turnDetails.Add(new TurnDetail
                {
                    TurnId = entity.Id,
                    CollaboratorId = turnDetail.CollaboratorId,
                    ServiceId = turnDetail.ServiceId,
                    Price = turnDetail.Price
                });
            }

            await _repositoryDetailAsync.InsertAsync(turnDetails, cancellationToken);
        }

        if (request.AdditionalDetails.Any())
        {
            List<TurnAdditionalDetail> turnAdditionalDetails = new();

            foreach (var turnAdditionalDetail in request.AdditionalDetails)
            {
                turnAdditionalDetails.Add(new TurnAdditionalDetail
                {
                    TurnId = entity.Id,
                    CollaboratorId = turnAdditionalDetail.CollaboratorId,
                    Detail = turnAdditionalDetail.Detail,
                    Price = turnAdditionalDetail.Price
                });
            }

            await _repositoryAdditionalDetailAsync.InsertAsync(turnAdditionalDetails, cancellationToken);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new Response<Guid>(entity.Id);
    }
}