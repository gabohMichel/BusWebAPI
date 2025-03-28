using FluentValidation;

namespace BusWebAPI.Application.Services.Bus.Commands
{
    public class BusUpdateRequestValidation : AbstractValidator<BusUpdateRequestCommand>
    {
        public BusUpdateRequestValidation() 
        {
            RuleFor(o => o.Id).NotNull().NotEmpty().NotEqual(0);
            RuleFor(o => o.IdStatus).NotNull().NotEmpty().NotEqual(0);
        }
    }
}
