using FluentValidation;

namespace BusWebAPI.Application.Services.Route.Queries
{
    public class RouteGetRequestValidation : AbstractValidator<RouteGetRequestQuery>
    {
        public RouteGetRequestValidation() 
        {
            RuleFor(o => o.Id).NotEmpty().NotEmpty().NotEqual(0);
        }
    }
}
