using FluentValidation;

namespace BusWebAPI.Application.Services.BusSchedule.Queries
{
    public class BusScheduleGetRequestValidation : AbstractValidator<BusScheduleGetRequestQuery>
    {
        public BusScheduleGetRequestValidation()
        {
            RuleFor(o => o.Id).NotEmpty().NotNull().NotEqual(0);
        }
    }
}
