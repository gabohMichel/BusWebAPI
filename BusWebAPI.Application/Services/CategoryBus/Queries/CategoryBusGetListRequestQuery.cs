using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.CategoryBus.Queries
{
    public class CategoryBusGetListRequestQuery : IRequest<Response<List<CategoryBusGetListResponseQuery>>>
    {
    }
}
