using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.Bus.Queries
{
    public class BusGetListRequestQuery : IRequest<Response<List<BusGetListResponseQuery>>>
    {
    }
}
