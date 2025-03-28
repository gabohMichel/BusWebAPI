using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.Bus.Queries
{
    public class BusGetListQuery : IRequestHandler<BusGetListRequestQuery, Response<List<BusGetListResponseQuery>>>
    {
        private readonly IBusRepository _busRepository;

        public BusGetListQuery(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public async Task<Response<List<BusGetListResponseQuery>>> Handle(BusGetListRequestQuery request, CancellationToken cancellationToken)
        {
            var ltmp = await _busRepository.GetList();
            var l = ltmp.Select(o => new BusGetListResponseQuery()
            {
                Id = o.Id,
                Capacity = o.Capacity,
                Plate = o.Plate,
                IdCategory = o.IdCategory,
                Category = o.Category,
                IdStatus = o.IdStatus,
                Status = o.Status
            }).ToList();
            return new Response<List<BusGetListResponseQuery>>()
            {
                StatusCode = 200,
                Data = l
            };
        }
    }
}
