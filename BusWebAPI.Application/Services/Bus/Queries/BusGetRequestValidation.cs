using FluentValidation;

namespace BusWebAPI.Application.Services.Bus.Queries
{
    public class BusGetRequestValidation : AbstractValidator<BusGetRequestQuery>
    {
        public BusGetRequestValidation() 
        {
            RuleFor(o => o.Id).NotNull().NotEmpty().NotEqual(0);
        }
    }
}
