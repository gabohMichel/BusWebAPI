using BusWebAPI.Application.Services.Ticket.Commands;
using FluentValidation;

namespace BusWebAPI.Application.Validations.Ticket.Commands
{
    public class TicketCreateValidation : AbstractValidator<TicketCreateCommand>
    {
        public TicketCreateValidation() 
        { 
            RuleFor(o => o.Price).GreaterThan(0);
            RuleFor(o => o.IdUser).NotNull();
            RuleFor(o => o.IdBusSchedule).NotNull();
        }
    }
}
