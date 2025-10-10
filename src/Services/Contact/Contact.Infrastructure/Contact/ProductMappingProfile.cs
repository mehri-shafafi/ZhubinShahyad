using AutoMapper;
using Gallery.Domain.Dtos.Gallery;
using Gallery.Domain.Gallery.Models;
namespace Gallery.Infrastructure.Gallery
{
    public class GalleryMappingProfile : Profile
    {
        public GalleryMappingProfile()
        {
            CreateMap<GalleryEntity, GalleryReqDto>().ReverseMap();
            CreateMap<GalleryEntity, GalleryResDto>().ReverseMap();
        }
    }
}
