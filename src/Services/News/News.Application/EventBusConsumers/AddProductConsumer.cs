using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MassTransit.Mediator;
using News.Application.NewsCommands.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.EventBusConsumers
{
    public class AddNewsCommentonsumer : IConsumer<AddNewsCommandEvent>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AddNewsCommentonsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<AddNewsCommandEvent> context)
        {
            CreateArticlesCommand createNewsCommand = new CreateArticlesCommand
            {
                Id = context.Message.NewsArticleID,
                Content = context.Message.Content
            };
            var result =  _mediator.Send(createNewsCommand);
        }
    }
}
