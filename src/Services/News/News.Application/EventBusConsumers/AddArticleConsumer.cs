using AutoMapper;
using EventBus.Messages.Events.News;
using MassTransit;
using MassTransit.Mediator;
using News.Application.Articles.Commands.Create;

namespace News.Application.EventBusConsumers
{
    public class AddArticleConsumer : IConsumer<AddNewsCommentEvent>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AddArticleConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<AddNewsCommentEvent> context)
        {
            CreateArticlesCommand createArticlesCommand = new CreateArticlesCommand
            {
                AuthorID = context.Message.NewsArticleID,
                Content = context.Message.Content
            };
            var result = _mediator.Send(createArticlesCommand);
        }
    }
}
