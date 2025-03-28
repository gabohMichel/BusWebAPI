using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.CategoryBus.Queries
{
    public class CategoryBusGetListQuery : IRequestHandler<CategoryBusGetListRequestQuery, Response<List<CategoryBusGetListResponseQuery>>>
    {
        private readonly ICategoryBusRepository _categoryBusRepository;

        public CategoryBusGetListQuery(ICategoryBusRepository categoryBusRepository)
        {
            _categoryBusRepository = categoryBusRepository;
        }

        public async Task<Response<List<CategoryBusGetListResponseQuery>>> Handle(CategoryBusGetListRequestQuery request, CancellationToken cancellationToken)
        {
            var l = await _categoryBusRepository.GetList();
            return new Response<List<CategoryBusGetListResponseQuery>>
            {
                StatusCode = 200,
                Data = l.Select(o => new CategoryBusGetListResponseQuery()
                {
                    Id = o.Id,
                    Label = o.Label
                }).ToList(),
            };
        }
    }
}
