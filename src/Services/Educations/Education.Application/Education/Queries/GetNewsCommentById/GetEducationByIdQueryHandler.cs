using AutoMapper;
using Education.Domain.Education.Dtos;
using Education.Domain.UnitOfWork.Education;
using MediatR;

namespace Education.Application.EducationComments.Queries.GetEducationCommentById
{
    public class GetArticlesByIdQueryHandler : IRequestHandler<GetArticlesByIdQuery, TrainingDto>
    {
        private readonly IMapper _mapper;
        private readonly IReadUnitOfWork _readunitOfWork;
        public GetArticlesByIdQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readunitOfWork = readUnitOfWork;
            _mapper = mapper;

        }
        public async Task<TrainingDto> Handle(GetArticlesByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _readunitOfWork.EducationReadRepository.GetEducationAsync(request.TrainingId);
            var resultModel = _mapper.Map<TrainingDto>(result);
            return resultModel;
        }
    }
}
