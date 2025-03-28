using FluentValidation;

namespace BusWebAPI.Application.Services.Bus.Commands
{
    public class BusDeleteRequestValidation : AbstractValidator<BusDeleteRequestCommand>
    {
        public BusDeleteRequestValidation() 
        { 
            RuleFor(o => o.Id).NotNull().NotEmpty().NotEqual(0);
        }
    }
}
