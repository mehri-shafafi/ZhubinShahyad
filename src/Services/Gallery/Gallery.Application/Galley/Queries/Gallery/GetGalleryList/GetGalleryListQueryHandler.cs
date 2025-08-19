using AutoMapper;
using Gallery.Application.Gallery.Queries.GetGalleryList;
using MediatR;
namespace Gallery.Application.Gallery.Queries.GetGalleryList
{
    internal class GetBaseProjectListQueryHandler : IRequestHandler<GetGalleryListQuery, List<GalleryResDto>>
    {

        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetBaseProjectListQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }
        public async Task<List<GalleryResDto>> Handle(GetGalleryListQuery request, CancellationToken cancellationToken)
        {
            var result = await _readUnitOfWork.BaseReadRepository.FetchAllBaseEntityAsync();


            var resultDto = _mapper.Map<List<GalleryResDto>>(result);
            return resultDto;
        }
    }
}
