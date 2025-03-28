using MediatR;

namespace BusWebAPI.Application.Services.BusSchedule.Commands
{
    public class BusScheduleDeleteRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}
