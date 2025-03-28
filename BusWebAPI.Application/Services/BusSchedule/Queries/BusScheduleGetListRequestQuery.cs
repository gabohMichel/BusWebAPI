using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.BusSchedule.Queries
{
    public class BusScheduleGetListRequestQuery : IRequest<Response<List<BusScheduleGetListResposeQuery>>>
    {
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivingTime { get; set; }
        public string? DeparturePoint { get; set; }
        public string? ArrivingPoint { get; set; }
    }
}
