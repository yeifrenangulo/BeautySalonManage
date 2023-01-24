using AutoMapper;
using BeautySalonManage.Application.DTOs.Turns;
using BeautySalonManage.Application.Helpers.Constants;
using BeautySalonManage.Application.Helpers.Enumerations;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BeautySalonManage.Application.Features.Turns.Commands.Create.Commands
{
    public class CreateTurnCommand : IRequest<Response<long>>
    {
        [Display(Name = "Nombre del Cliente")]
        public string NameCustomer { get; set; }

        [Display(Name = "Teléfono del Cliente")]
        public string PhoneCustomer { get; set; }

        [Display(Name = "Fecha")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Hora de Inicio")]
        public string StartTime { get; set; }

        [Display(Name = "Hora de Fin")]
        public string EndTime { get; set; }

        [Display(Name = "Observaciones")]
        public string Observation { get; set; }

        public List<TurnDetailDTO> Details { get; set; }
        public List<TurnAdditionalDetailDTO> AdditionalDetails { get; set; }
    }

    public class CreateTurnCommandHandler : IRequestHandler<CreateTurnCommand, Response<long>>
    {
        private readonly IRepositoryAsync<Turn> _repositoryAsync;
        private readonly IRepositoryAsync<TurnDetail> _repositoryDetailAsync;
        private readonly IRepositoryAsync<TurnAdditionalDetail> _repositoryAdditionalDetailAsync;
        private readonly IMapper _mapper;

        public CreateTurnCommandHandler(IRepositoryAsync<Turn> repositoryAsync, IRepositoryAsync<TurnDetail> repositoryDetailAsync, IRepositoryAsync<TurnAdditionalDetail> repositoryAdditionalDetailAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _repositoryDetailAsync = repositoryDetailAsync;
            _repositoryAdditionalDetailAsync = repositoryAdditionalDetailAsync;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateTurnCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Turn>(request);
            entity.StatusId = (int)StatusEnum.Pendiente;

            var data = await _repositoryAsync.AddAsync(entity, cancellationToken);

            if (data != null && request.Details.Any())
            {
                List<TurnDetail> turnDetails = new();

                foreach (var turnDetail in request.Details)
                {
                    turnDetails.Add(new TurnDetail
                    {
                        TurnId = data.TurnId,
                        CollaboratorId = turnDetail.CollaboratorId,
                        ServiceId = turnDetail.ServiceId,
                        Price = turnDetail.Price
                    });
                }

                await _repositoryDetailAsync.AddRangeAsync(turnDetails, cancellationToken);
            }

            if (data != null && request.AdditionalDetails.Any())
            {
                List<TurnAdditionalDetail> turnAdditionalDetails = new();

                foreach (var turnAdditionalDetail in request.AdditionalDetails)
                {
                    turnAdditionalDetails.Add(new TurnAdditionalDetail
                    {
                        TurnId = data.TurnId,
                        Detail = turnAdditionalDetail.Detail,
                        Price = turnAdditionalDetail.Price
                    });
                }

                await _repositoryAdditionalDetailAsync.AddRangeAsync(turnAdditionalDetails, cancellationToken);
            }

            return new Response<long>(data.TurnId);
        }
    }
}
