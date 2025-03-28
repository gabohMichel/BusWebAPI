using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.BusSchedule.Queries
{
    public class BusScheduleGetRequestQuery : IRequest<Response<BusScheduleGetResponseQuery>>
    {
        public int Id { get; set; }
    }
}
