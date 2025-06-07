//using AutoMapper;
//using EventBus.Messages.Events;
//using EventBus.Messages.Events.News;
//using MassTransit;
//using MassTransit.Mediator;
//using News.Application.Articles.Commands.Create;
//using News.Application.NewsCommands.Commands.Create;

//namespace News.Application.EventBusConsumers
//{
//    public class AddNewsCommentConsumer : IConsumer<AddNewsCommentEvent>
//    {
//        private readonly IMapper _mapper;
//        private readonly IMediator _mediator;

//        public AddNewsCommentConsumer(IMapper mapper, IMediator mediator)
//        {
//            _mapper = mapper;
//            _mediator = mediator;
//        }
//        public async Task Consume(ConsumeContext<AddNewsCommentEvent> context)
//        {
//            CreateNewsCommand createNewsCommand = new CreateNewsCommand
//            {
//                CreationDateTime = context.Message.CreationDate,
//                Content = context.Message.Content,
//                PostedDate = context.Message.PostedDate
//            };
//            var result = _mediator.Send(createNewsCommand);
//        }
//    }
//}
