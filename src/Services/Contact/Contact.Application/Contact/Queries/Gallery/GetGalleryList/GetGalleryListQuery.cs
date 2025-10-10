using Gallery.Domain.Dtos.Gallery;
using MediatR;

namespace Gallery.Application.Gallery.Queries.GetGalleryList
{
    public class GetGalleryListQuery : IRequest<List<GalleryResDto>>
    {

    }
}
