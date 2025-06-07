using AutoMapper;
using Education.Domain.Education.Dtos;
using Education.Domain.Education.Models;

namespace Education.Infrastructure.Education
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<Training, TrainingDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src =>
                    src.Translations.FirstOrDefault(t => t.Language == "fa").Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src =>
                    src.Translations.FirstOrDefault(t => t.Language == "fa").Description))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src =>
                    src.Translations.FirstOrDefault(t => t.Language == "fa").Language))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src =>
                    src.trainingCategory.Name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()));
        }
    }

}
