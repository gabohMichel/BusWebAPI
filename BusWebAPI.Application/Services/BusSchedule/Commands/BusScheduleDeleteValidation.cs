using FluentValidation;

namespace BusWebAPI.Application.Services.BusSchedule.Commands
{
    public class BusScheduleDeleteValidation : AbstractValidator<BusScheduleDeleteRequestCommand>
    {
        public BusScheduleDeleteValidation()
        {
            RuleFor(o => o.Id)
                .NotEmpty()
                .NotNull()
                .NotEqual(0);
        }
    }
}
