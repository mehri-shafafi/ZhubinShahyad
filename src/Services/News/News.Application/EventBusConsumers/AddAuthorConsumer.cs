using AutoMapper;
using EventBus.Messages.Events;
using EventBus.Messages.Events.News;
using MassTransit;
using MassTransit.Mediator;
using News.Application.Articles.Commands.Create;
using News.Application.Author.Commands.Create;

namespace News.Application.EventBusConsumers
{
    public class AddAuthorConsumer : IConsumer<AddAuthorEvent>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AddAuthorConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<AddAuthorEvent> context)
        {
            CreateAuthorCommand createAuthorCommand = new CreateAuthorCommand
            {
                Bio = context.Message.Bio,
                Name = context.Message.Name,
                ProfilePictureURL = context.Message.ProfilePictureURL
            };
            var result = _mediator.Send(createAuthorCommand);
        }
    }
}
