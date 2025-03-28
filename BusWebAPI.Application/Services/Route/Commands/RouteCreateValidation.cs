using FluentValidation;

namespace BusWebAPI.Application.Services.Route.Commands
{
    public class RouteCreateValidation : AbstractValidator<RouteCreateRequestCommand>
    {
        public RouteCreateValidation()
        {
            RuleFor(o => o.DeparturePoint).NotEmpty().NotNull();
            RuleFor(o => o.ArrivingPoint).NotEmpty().NotNull();
            RuleFor(o => o.Distance).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
