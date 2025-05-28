using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Application.Articles.Commands.Delete;
using News.Application.Articles.Commands.Create;
using News.Domain.Dtos.News;
using News.Application.Articles.Queries.Get;
using News.Application.Articles.Commands.Update;


namespace News.Presentation.Controllers.Article
{
    [Route("api/")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
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
        [ProducesResponseType(typeof(List<NewsArticleDto>), 200)]
        public async Task<List<NewsArticleDto>> GetList()
        {
            return await _mediator.Send(new GetAllArticlesQuery());
        }

        [Route("AddedNewsCommand")]
        [HttpPost]
        [ProducesResponseType(typeof(NewsArticleDto), 200)]
        public async Task<NewsArticleDto> Create(CreateArticlesCommand request)
        {
            return await _mediator.Send(request);
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> Update(int id, UpdateArticleCommand request)
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
