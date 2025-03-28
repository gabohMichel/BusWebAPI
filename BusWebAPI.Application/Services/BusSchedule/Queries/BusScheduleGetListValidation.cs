using FluentValidation;

namespace BusWebAPI.Application.Services.BusSchedule.Queries
{
    public class BusScheduleGetListValidation : AbstractValidator<BusScheduleGetListRequestQuery>
    {
        public BusScheduleGetListValidation()
        {
            RuleFor(o => o.DepartureTime)
                .LessThan(o => o.ArrivingTime);
            RuleFor(o => o.ArrivingTime)
                .GreaterThan(o => o.DepartureTime);
        }
    }
}
