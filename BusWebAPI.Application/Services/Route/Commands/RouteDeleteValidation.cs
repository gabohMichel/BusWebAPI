using FluentValidation;

namespace BusWebAPI.Application.Services.Route.Commands
{
    public class RouteDeleteValidation : AbstractValidator<RouteDeleteRequestCommand>
    {
        public RouteDeleteValidation()
        {
            RuleFor(o => o.Id).NotNull().NotEmpty().NotEqual(0);
        }
    }
}
