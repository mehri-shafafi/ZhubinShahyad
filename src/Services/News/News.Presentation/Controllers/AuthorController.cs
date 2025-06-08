using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Application.Articles.Commands.Delete;
using News.Application.Author.Commands.Create;
using News.Application.Author.Commands.Update;
using News.Application.Author.Queries.Get;
using News.Domain.Dtos.News;


namespace News.Presentation.Controllers
{

    [Route("api/NewsAuthor/")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
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
        [ProducesResponseType(typeof(List<NewsAuthorDto>), 200)]
        public async Task<List<NewsAuthorDto>> GetList()
        {
            return await _mediator.Send(new GetAllAuthorQuery());
        }

        [Route("AddedNewsCommand")]
        [HttpPost]
        [ProducesResponseType(typeof(NewsAuthorDto), 200)]
        public async Task<NewsAuthorDto> Create(CreateAuthorCommand request)
        {
            return await _mediator.Send(request);
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> Update(int id, UpdateAuthorCommand request)
        {
            if (id != request.Id)
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
        public async Task<bool> Delete(DeleteArticlesCommand request)
        {
            var res = await _mediator.Send(request);
            return res;
        }

    }
}
