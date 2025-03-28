using FluentValidation;

namespace BusWebAPI.Application.Services.BusSchedule.Commands
{
    public class BusScheduleCreateValidation : AbstractValidator<BusScheduleCreateRequestCommand>
    {
        public BusScheduleCreateValidation()
        {
            RuleFor(o => o.DepartureTime)
                .NotNull()
                .NotEmpty()
                .GreaterThan(DateTime.Now)
                .LessThan(o => o.ArrivingTime);
            RuleFor(o => o.ArrivingTime)
                .NotNull()
                .NotEmpty()
                .GreaterThan(o => o.DepartureTime);
            RuleFor(o => o.IsAvailable)
                .NotEmpty()
                .NotNull();
            RuleFor(o => o.IdBus)
                .NotEmpty()
                .NotEmpty()
                .NotEqual(0);
            RuleFor(o => o.IdRoute)
                .NotEmpty()
                .NotEmpty()
                .NotEqual(0);
        }
    }
}
