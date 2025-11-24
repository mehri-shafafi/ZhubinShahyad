using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Application.Articles.Commands.Create;
using News.Application.Category.Commands.Create;
using News.Application.Category.Commands.Delete;
using News.Application.Category.Commands.Update;
using News.Application.Category.Queries.Get;
using News.Application.Dtos.News;


namespace News.Presentation.Controllers
{

    [Route("api/NewsCategory/")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("GetListCategory")]
        [HttpGet()]
        [ProducesResponseType(typeof(List<NewsCategoryResDto>), 200)]
        public async Task<List<NewsCategoryResDto>> GetList()
        {
            return await _mediator.Send(new GetAllCategoryQuery());
        }

     

        [HttpPost]
        [ProducesResponseType(typeof(NewsCategoryResDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand request)
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

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> Update(int id, UpdateCategoryCommand request)
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
        public async Task<bool> Delete(DeleteCategoryCommand request)
        {
            var res = await _mediator.Send(request);
            return res;
        }

    }
}
