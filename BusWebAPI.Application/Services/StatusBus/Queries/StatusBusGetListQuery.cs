using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.StatusBus.Queries
{
    public class StatusBusGetListQuery : IRequestHandler<StatusBusGetListRequestQuery, Response<List<StatusBusGetListResponseQuery>>>
    {
        private readonly IStatusBusRepository _statusBusRepository;

        public StatusBusGetListQuery(IStatusBusRepository statusBusRepository)
        {
            _statusBusRepository = statusBusRepository;
        }

        public async Task<Response<List<StatusBusGetListResponseQuery>>> Handle(StatusBusGetListRequestQuery request, CancellationToken cancellationToken)
        {
            var l = await _statusBusRepository.GetList();
            return new Response<List<StatusBusGetListResponseQuery>>
            {
                StatusCode = 200,
                Data = l.Select(o =>
                    new StatusBusGetListResponseQuery()
                    {
                        Id = o.Id,
                        Label = o.Label
                    }).ToList(),
            };
        }
    }
}
