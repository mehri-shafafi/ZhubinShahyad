using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Dtos.Products;
using Products.Application.Products.Commands.Categories.Create;
using Products.Application.Products.Commands.Categories.Delete;
using Products.Application.Products.Commands.Categories.Update;
using Products.Application.Products.Queries.Product.GetCateguriesList;

namespace Products.Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CateguriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public CateguriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// دریافت لیست دسته  بندی ها
        /// </summary>
        [Route("GetListCateguriesProduct")]
        [HttpGet]
        [ProducesResponseType(typeof(List<ProductCategoryDto>), 200)]
        public async Task<ActionResult<List<ProductCategoryDto>>> GetList()
        {
            var result = await _mediator.Send(new GetCateguriesListQuery()); // این کوئری بهتره تغییر نام بده برای محصولات
            return Ok(result);
        }

        /// <summary>
        /// ایجاد محصول جدید
        /// </summary>
        [Route("api/Added")]
        [HttpPost]
        [ProducesResponseType(typeof(ProductCategoryDto), 200)]
        public async Task<ActionResult<ProductCategoryDto>> Create([FromBody] CreateCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        /// <summary>
        /// ویرایش محصول
        /// </summary>
        //[Route("api/UpdateProduct")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdateCategoryCommand request)
        {
            //if (id != request.Id)
            //    return BadRequest("Id in route and body must match");
            request.Id = id;
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// حذف محصول
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var request = new DeleteCategoryCommand { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
