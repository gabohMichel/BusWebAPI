using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Application.Exceptions;
using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.Bus.Queries
{
    public class BusGetQuery : IRequestHandler<BusGetRequestQuery, Response<BusGetResponseQuery>>
    {
        private readonly IBusRepository _busRepository;
        public BusGetQuery(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }
        public async Task<Response<BusGetResponseQuery>> Handle(BusGetRequestQuery request, CancellationToken cancellationToken)
        {
            var b = await _busRepository.Get(request.Id);

            if (b == null)
                throw new NotFoundException("Bus", "id");
            return new Response<BusGetResponseQuery>()
            {
                StatusCode = 200,
                Data = new BusGetResponseQuery()
                {
                    Id = b.Id,
                    Capacity = b.Capacity,
                    IdCategory = b.IdCategory,
                    Category = b.Category,
                    IdStatus = b.IdStatus,
                    Plate = b.Plate,
                    Status = b.Status
                }
            };
        }
    }
}
