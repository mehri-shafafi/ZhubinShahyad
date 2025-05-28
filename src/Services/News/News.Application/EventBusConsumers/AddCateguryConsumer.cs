using AutoMapper;
using EventBus.Messages.Events;
using EventBus.Messages.Events.News;
using MassTransit;
using MassTransit.Mediator;
using News.Application.Articles.Commands.Create;
using News.Application.Category.Commands.Create;

namespace News.Application.EventBusConsumers
{
    public class AddCategoryConsumer : IConsumer<AddCategoryEvent>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AddCategoryConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<AddCategoryEvent> context)
        {
            CreateCategoryCommand createCategoryCommand = new CreateCategoryCommand
            {
                CreatedDate = context.Message.CreatedDate,
                Description = context.Message.Description,
                ParentCategoryID = context.Message.ParentCategoryID,
                Name = context.Message.Name,
                Slug = context.Message.Slug,
                UpdatedDate = context.Message.UpdatedDate,
            };
            var result = _mediator.Send(createCategoryCommand);
        }
    }
}
