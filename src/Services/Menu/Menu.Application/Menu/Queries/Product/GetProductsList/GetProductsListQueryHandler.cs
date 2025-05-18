using AutoMapper;
using MediatR;
using Menus.Domain.Base;
using Menus.Domain.Dtos.Menu;
using Menus.Domain.UnitOfWork.Menu;
namespace Menus.Application.Menus.Queries.Menu.GetMenusList
{
    internal class GetMenusListQueryHandler : IRequestHandler<GetMenusListQuery, List<MenuResDto>>
    {

        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetMenusListQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }
        public async Task<List<MenuResDto>> Handle(GetMenusListQuery request, CancellationToken cancellationToken)
        {
            var MenuList = await _readUnitOfWork.MenuReadRepository.FetchAllMenuEntityAsync();

            var result = _mapper.Map<List<MenuResDto>>(MenuList);
            return result;
        }
    }
}
