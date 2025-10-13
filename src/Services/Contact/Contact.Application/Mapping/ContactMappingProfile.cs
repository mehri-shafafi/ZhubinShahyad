using AutoMapper;
using Contact.Domain.Contact.Models;
using Contact.Domain.Dtos.Contact;

namespace Contact.Application.Mapping
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {

            CreateMap<ContactModel, ContactResDto>().ReverseMap();

            CreateMap<ContactModel, ContactResDto>()
                .ForMember(dist => dist.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForMember(dist => dist.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dist => dist.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dist => dist.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dist => dist.IsRead, opt => opt.MapFrom(src => src.IsRead))
                .ForMember(dist => dist.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dist => dist.CategoryId, opt => opt.MapFrom(src => src.CategoryId)).ReverseMap();
        }
    }
}
