using AutoMapper;
using MediatR;
using Menus.Application.Dtos.Menu;
using Menus.Domain.UnitOfWork.Menu;
namespace Menus.Application.Menus.Queries.Menu.GetCateguriesList
{
    internal class GetMenusListQueryHandler : IRequestHandler<GetCateguriesListQuery, List<MenuCategoryDto>>
    {

        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetMenusListQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }
        public async Task<List<MenuCategoryDto>> Handle(GetCateguriesListQuery request, CancellationToken cancellationToken)
        {
            var MenuList = await _readUnitOfWork.MenuReadRepository.FetchAllMenuCategoryAsync();
            var result = _mapper.Map<List<MenuCategoryDto>>(MenuList);


            return result;
        }
    }
}
