using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Application.News.Commands.News.Update;
using News.Application.NewsCommands.Commands.Create;
using News.Application.NewsCommands.Commands.Delete;
using News.Application.NewsComments.Queries.GetAllNewsComments;
using News.Domain.Dtos.News;
using System.Runtime.CompilerServices;


namespace News.Presentation.Controllers.News
{
    [Route("api/")]
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

        [Route("GetListNewsCommand")]
        [HttpGet()]
        [ProducesResponseType(typeof(List<NewsCommentDto>), 200)]
        public async Task<List<NewsCommentDto>> GetList()
        {
            return await _mediator.Send(new GetAllNewsCommentsQuery());
        }

        [Route("AddedNewsCommand")]
        [HttpPost]
        [ProducesResponseType(typeof(NewsCommentDto), 200)]
        public async Task<NewsCommentDto> Create(CreateNewsCommand request)
        {
            return await _mediator.Send(request);
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> Update(int id, UpdateNewsCommand request)
        {
            if (id != request.NewsCommentId)
            {

                return BadRequest("Id in body and query must be equal");
            }
            var res = await _mediator.Send(request);
            return res;

        }
        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        //[Route("api/DeleteProduct")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<bool> Delete(DeleteNewsCommand request)
        {
            var res = await _mediator.Send(request);
            return res;
        }

    }
}
