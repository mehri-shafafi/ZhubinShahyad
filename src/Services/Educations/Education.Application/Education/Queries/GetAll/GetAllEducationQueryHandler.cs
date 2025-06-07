using AutoMapper;
using Education.Domain.Education.Dtos;
using Education.Domain.UnitOfWork.Education;
using MediatR;

namespace Education.Application.EducationComments.Queries.GetAllEducationComments
{
    public class GetAllEducationCommentsQueryHandler : IRequestHandler<GetAllEducationCommentsQuery, List<TrainingDto>>
    {


        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetAllEducationCommentsQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }
        public async Task<List<TrainingDto>> Handle(GetAllEducationCommentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _readUnitOfWork.EducationReadRepository.GetEducationAllAsync(request.Language);
            var resultModel = _mapper.Map<List<TrainingDto>>(result);
            return resultModel;
        }
    }
}
