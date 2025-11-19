using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using News.Domain.News.Models;
using News.Domain.UnitOfWork.News;

namespace News.Application.Articles.Commands.Update
{
    public class ChangeNewsArticleStatusHandler : IRequestHandler<ChangeNewsArticleStatusCommand, bool>
    {
        private readonly IWriteUnitOfWork _writeUnitOfWork;
        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateArticleCommandHandler> _logger;

        public ChangeNewsArticleStatusHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, IMapper mapper, ILogger<UpdateArticleCommandHandler> logger)
        {
            _writeUnitOfWork = writeUnitOfWork;
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(ChangeNewsArticleStatusCommand request, CancellationToken cancellationToken)
        {
            var mappedComment = _mapper.Map<ChangeNewsArticleStatusModel>(request);
            await _writeUnitOfWork.NewsWriteRepository.ChangeStatusAsync(mappedComment);

            return true;
        }
    }

}
