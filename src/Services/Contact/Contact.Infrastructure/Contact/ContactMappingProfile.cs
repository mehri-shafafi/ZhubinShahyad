using AutoMapper;
using Contact.Domain.Contact.Models;
namespace Contact.Infrastructure.Contact
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<ContactEntity, ContactModel>().ReverseMap()
                .ForMember(dist => dist.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForMember(dist => dist.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dist => dist.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dist => dist.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dist => dist.IsRead, opt => opt.MapFrom(src => src.IsRead))
                .ForMember(dist => dist.CategoryId, opt => opt.MapFrom(src => src.CategoryId));

            CreateMap<CategoriesContact, CategoriesContactModel>().ReverseMap()
                .ForMember(dist => dist.Name_FA, opt => opt.MapFrom(src => src.Name_FA))
                .ForMember(dist => dist.Name_EN, opt => opt.MapFrom(src => src.Name_EN))
                .ForMember(dist => dist.Name_AR, opt => opt.MapFrom(src => src.Name_AR));
        }
    }
}
