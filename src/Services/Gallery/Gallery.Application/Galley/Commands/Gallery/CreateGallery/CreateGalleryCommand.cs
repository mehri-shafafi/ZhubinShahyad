using Gallery.Domain.Dtos.Gallery;
using MediatR;

namespace Gallery.Application.Gallery.Commands.Base.CreateGallery;


public class CreateGalleryCommand : GalleryReqDto, IRequest<GalleryResDto>
{
}