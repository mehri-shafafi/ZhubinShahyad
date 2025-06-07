//using AutoMapper;
//using Education.Application.EducationCommands.Commands.Create;
//using EventBus.Messages.Events.News;
//using MassTransit;
//using MassTransit.Mediator;

//namespace Education.Application.EventBusConsumers
//{
//    public class AddEducationCommentConsumer : IConsumer<AddEducationEvent>
//    {
//        private readonly IMapper _mapper;
//        private readonly IMediator _mediator;

//        public AddEducationCommentConsumer(IMapper mapper, IMediator mediator)
//        {
//            _mapper = mapper;
//            _mediator = mediator;
//        }
//        public async Task Consume(ConsumeContext<AddEducationEvent> context)
//        {
//            CreateEducationCommand createEducationCommand = new CreateEducationCommand
//            {
//                CreationDateTime = context.Message.CreationDate
//            };
//            var result = _mediator.Send(createEducationCommand);
//        }
//    }
//}
