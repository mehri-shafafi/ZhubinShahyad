using MediatR;

namespace Gallery.Application.Gallery.Commands.Base.UpdateGallery;

public class UpdateGalleryCommand : GalleryReqDto, IRequest<bool>
{

}