using MediatR;

namespace Gallery.Application.Gallery.Commands.Base.DeleteGallery;

public class DeleteGalleryCommand : IRequest<bool>
{
    public int Id { get; set; }
}