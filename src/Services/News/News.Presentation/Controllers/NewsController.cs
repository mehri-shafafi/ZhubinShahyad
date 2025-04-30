using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Application.News.Commands.News.Update;
using News.Application.NewsCommands.Commands.Create;
using News.Application.NewsCommands.Commands.Delete;
using News.Application.NewsComments.Queries.GetAllNewsComments;


namespace News.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpGet()]
        public async Task<List<News>> GetList()
        {
            return await _mediator.Send(new GetAllNewsCommentsQuery());
        }
        [HttpPost]
        public async Task<News_CommentDto> Post(CreateNewsCommand request)
        {
            return await _mediator.Send(request);
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(int id, UpdateNewsCommand request)
        {
            if (id != request.Id)
            {

                return BadRequest("Id in body and query must be equal");
            }
            var res = await _mediator.Send(request);
            return res;

        }
        // DELETE api/<NewsController>/5
        [HttpDelete]
        public async Task<bool> Delete(DeleteNewsCommand request)
        {
            var res = await _mediator.Send(request);
            return res;
        }

    }
}
