using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.StatusBus.Queries
{
    public class StatusBusGetListRequestQuery : IRequest<Response<List<StatusBusGetListResponseQuery>>>
    {
    }
}
