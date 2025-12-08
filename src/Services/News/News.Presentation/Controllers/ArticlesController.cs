using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Application.Articles.Commands.Create;
using News.Application.Articles.Commands.Delete;
using News.Application.Articles.Commands.Update;
using News.Application.Articles.Queries.Get;
using News.Application.Articles.Queries.GetNewsCommentById;
using News.Application.Dtos.News;


namespace News.Presentation.Controllers
{
    [Route("api/NewsArticle/")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET api/<NewsController>/5
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<NewsArticleResDto>> Get(GetArticlesByIdQuery query)
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

        [Route("GetListArticle")]
        [HttpGet()]
        [ProducesResponseType(typeof(List<NewsArticleResDto>), 200)]
        public async Task<List<NewsArticleResDto>> GetList()
        {
            return await _mediator.Send(new GetAllArticlesQuery());
        }

        [Route("AddedArticle")]
        [HttpPost]
        [ProducesResponseType(typeof(NewsArticleResDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateArticlesCommand request)
        {
            if (request == null)
            {
                return BadRequest("درخواست نامعتبر است.");
            }
            try
            {
                await _mediator.Send(request);
                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest("ایجاد خبر انجام نشد. ابتدا استعلام گرفته و سپس دوباره تلاش کنید.");

            }
        }


        [HttpPut("UpdateArticle/{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> Update(UpdateArticleCommand request)
        {
            if (request.Id == 0)
            {
                return BadRequest("Id in body and query must be equal");
            }
            var res = await _mediator.Send(request);
            return res;

        }

        [HttpPut("ChangeStatus/{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> Update2(ChangeNewsArticleStatusCommand request)
        {
            if (request.Id == 0)
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
