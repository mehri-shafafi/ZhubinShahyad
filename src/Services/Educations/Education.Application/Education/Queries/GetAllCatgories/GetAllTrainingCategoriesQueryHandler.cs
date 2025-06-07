using AutoMapper;
using Education.Application.EducationComments.Queries.GetAllCatgories;
using Education.Domain.Education.Dtos;
using Education.Domain.UnitOfWork.Education;
using MediatR;

namespace Education.Application.EducationComments.Queries.GetAllEducationComments
{
    public class GetAllTrainingCategoriesQueryHandler : IRequestHandler<GetAllTrainingCategoriesQuery, List<TrainingCategoryDto>>
    {


        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetAllTrainingCategoriesQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }
        public async Task<List<TrainingCategoryDto>> Handle(GetAllTrainingCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _readUnitOfWork.EducationReadRepository.GeTrainingCategoriesAllAsync();
            var resultModel = _mapper.Map<List<TrainingCategoryDto>>(result);
            return resultModel;
        }
    }
}
