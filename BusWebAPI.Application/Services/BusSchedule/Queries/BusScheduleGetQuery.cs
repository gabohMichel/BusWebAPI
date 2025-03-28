using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Application.Exceptions;
using BusWebAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BusWebAPI.Application.Services.BusSchedule.Queries
{
    public class BusScheduleGetQuery : IRequestHandler<BusScheduleGetRequestQuery, Response<BusScheduleGetResponseQuery>>
    {
        private readonly IBusScheduleRepository _busScheduleRepository;

        public BusScheduleGetQuery(IBusScheduleRepository busScheduleRepository)
        {
            _busScheduleRepository = busScheduleRepository;
        }

        public async Task<Response<BusScheduleGetResponseQuery>> Handle(BusScheduleGetRequestQuery request, CancellationToken cancellationToken)
        {
            var bs = await _busScheduleRepository.Get(request.Id);
            if (bs == null || bs.Id == 0)
                throw new NotFoundException("Bus Schedule", "id");
            return new Response<BusScheduleGetResponseQuery>
            {
                Data = new BusScheduleGetResponseQuery 
                { 
                    Id = bs.Id,
                    ArrivingPoint = bs.ArrivingPoint,
                    ArrivingTime = bs.ArrivingTime,
                    BusCategory = bs.BusCategory,
                    BusPlates = bs.BusPlates,
                    DeparturePoint = bs.DeparturePoint,
                    DepartureTime = bs.DepartureTime,
                    IdBus = bs.IdBus,
                    IdRoute = bs.IdRoute,
                    IsAvailable = bs.IsAvailable
                }
            };
        }
    }
}
