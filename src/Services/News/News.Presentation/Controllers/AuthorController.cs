using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Application.Articles.Commands.Delete;
using News.Application.Author.Commands.Create;
using News.Application.Author.Commands.Update;
using News.Application.Author.Queries.Get;
using News.Application.Author.Queries.GetNewsCommentById;
using News.Application.Dtos.News;


namespace News.Presentation.Controllers
{

    [Route("api/Author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("getauthorbyid")]
        public async Task<ActionResult<NewsAuthorDto>> Get([FromBody] GetAuthorByIdQuery query)
        {
            if (query == null)
            {
                return BadRequest("درخواست نامعتبر است.");
            }
            try
            {
                return await _mediator.Send(query);


            }
            catch (Exception)
            {
                return BadRequest("خبری پیدا نشد.");

            }
        }

        [HttpGet("getauthors")]
        [ProducesResponseType(typeof(List<NewsAuthorDto>), 200)]
        public async Task<List<NewsAuthorDto>> GetList()
        {
            return await _mediator.Send(new GetAllAuthorQuery());
        }

        [HttpPost("createauthor")]
        [ProducesResponseType(typeof(NewsAuthorDto), 200)]
        public async Task<bool> Create(CreateAuthorCommand request)
        {
            return await _mediator.Send(request);
        }

        // PUT api/<NewsController>/5
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        [HttpPut("updateauthor")]
        public async Task<ActionResult<bool>> Update(int id, UpdateAuthorCommand request)
        {
            if (id != request.Id)
            {

                return BadRequest("Id in body and query must be equal");
            }
            var res = await _mediator.Send(request);
            return res;

        }
        [ProducesResponseType(typeof(bool), 200)]
        [HttpDelete("deleteauthor/{id}")]
        public async Task<bool> DeleteAuthor(int id)
        {
            var res = await _mediator.Send(new DeleteArticlesCommand { Id = id });
            return res;
        }

    }
}
