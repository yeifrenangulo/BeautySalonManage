using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Application.Turns.Queries;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Turns.Commands.Update.UpdateTurn;

public class UpdateTurnCommandHandler : IRequestHandler<UpdateTurnCommand, Response<bool>>
{
    private readonly IRepositoryAsync<Turn> _repository;
    private readonly IRepositoryAsync<TurnDetail> _repositoryDetailAsync;
    private readonly IRepositoryAsync<TurnAdditionalDetail> _repositoryAdditionalDetailAsync;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTurnCommandHandler(
        IRepositoryAsync<Turn> repository,
        IRepositoryAsync<TurnDetail> repositoryDetailAsync,
        IRepositoryAsync<TurnAdditionalDetail> repositoryAdditionalDetailAsync,
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _repositoryDetailAsync = repositoryDetailAsync;
        _repositoryAdditionalDetailAsync = repositoryAdditionalDetailAsync;
    }

    public async Task<Response<bool>> Handle(UpdateTurnCommand request, CancellationToken cancellationToken)
    {
        Turn turn = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"El turno con ID {request.Id} no se encuentra registrado");

        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            turn.NameCustomer = request.NameCustomer;
            turn.PhoneCustomer = request.PhoneCustomer;
            turn.StartDate = request.StartDate;
            turn.StartTime = TimeSpan.Parse(request.StartTime);
            turn.EndTime = TimeSpan.Parse(request.EndTime);
            turn.Observation = request.Observation;

            await _repositoryDetailAsync.DeleteRangeAsync(x => x.TurnId == turn.Id, cancellationToken);
            await _repositoryAdditionalDetailAsync.DeleteRangeAsync(x => x.TurnId == turn.Id, cancellationToken);

            if (request.Details.Any())
            {
                List<TurnDetail> turnDetails = new();

                foreach (TurnDetailDto turnDetail in request.Details)
                {
                    turnDetails.Add(new TurnDetail
                    {
                        TurnId = turn.Id,
                        CollaboratorId = turnDetail.CollaboratorId,
                        ServiceId = turnDetail.ServiceId,
                        Price = turnDetail.Price
                    });
                }

                await _repositoryDetailAsync.AddRangeAsync(turnDetails, cancellationToken);
            }

            if (request.AdditionalDetails.Any())
            {
                List<TurnAdditionalDetail> turnAdditionalDetails = new();

                foreach (TurnAdditionalDetailDto turnAdditionalDetail in request.AdditionalDetails)
                {
                    turnAdditionalDetails.Add(new TurnAdditionalDetail
                    {
                        TurnId = turn.Id,
                        CollaboratorId = turnAdditionalDetail.CollaboratorId,
                        Detail = turnAdditionalDetail.Detail,
                        Price = turnAdditionalDetail.Price
                    });
                }

                await _repositoryAdditionalDetailAsync.AddRangeAsync(turnAdditionalDetails, cancellationToken);
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            return new Response<bool>(true);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync(cancellationToken);
            throw;
        }
    }
}