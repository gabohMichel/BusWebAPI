using FluentValidation;

namespace BusWebAPI.Application.Services.Route.Commands
{
    public class RouteUpdateValidation : AbstractValidator<RouteUpdateRequestCommand>
    {
        public RouteUpdateValidation() 
        {
            RuleFor(o => o.Id).NotNull().NotEmpty().NotEqual(0);
            RuleFor(o => o.Distance).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
