using AutoMapper;
using Education.Domain.Education.Dtos;
using Education.Domain.Education.Models;
namespace Education.Infrastructure.Education
{
    public class EducationMappingProfile : Profile
    {
        public EducationMappingProfile()
        {
            CreateMap<Training, TrainingDto>().ReverseMap();
            CreateMap<TrainingCategory, TrainingCategoryDto>().ReverseMap();
            CreateMap<TrainingTranslation, TrainingTranslationDto>().ReverseMap();
        }
    }
}
