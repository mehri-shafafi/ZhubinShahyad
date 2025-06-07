//using AutoMapper;
//using EventBus.Messages.Events.News;
//using News.Application.Author.Commands.Create;

//namespace News.Application.EventBusConsumers
//{
//    public class AddAuthorConsumer : IConsumer<AddAuthorEvent>
//    {
//        private readonly IMapper _mapper;

//        public AddAuthorConsumer(IMapper mapper)
//        {
//            _mapper = mapper;
//        }
//        //public async Task Consume(ConsumeContext<AddAuthorEvent> context)
//        //{
//        //    CreateAuthorCommand createAuthorCommand = new CreateAuthorCommand
//        //    {
//        //        Bio = context.Message.Bio,
//        //        Name = context.Message.Name,
//        //        ProfilePictureURL = context.Message.ProfilePictureURL
//        //    };
//        //    var result = _mediator.Send(createAuthorCommand);
//        //}
//    }
//}
