using MediatR;

namespace Gallery.Application.Gallery.Queries.GetGalleryList
{
    public class GetGalleryListQuery : GalleryFilterPageReqDto, IRequest<List<GalleryResDto>>
    {

    }
}
