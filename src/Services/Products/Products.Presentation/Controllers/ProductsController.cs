using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Dtos.Products;
using Products.Application.Products.Commands.Product.CreateMedical;
using Products.Application.Products.Commands.Product.DeleteMedical;
using Products.Application.Products.Commands.Product.UpdateProduct;
using Products.Application.Products.Queries.Product.GetProductsList;

namespace Products.Presentation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// دریافت لیست محصولات
        /// </summary>
        [Route("GetListProduct")]
        [HttpGet]
        [ProducesResponseType(typeof(List<ProductResDto>), 200)]
        public async Task<ActionResult<List<ProductResDto>>> GetList()
        {
            var result = await _mediator.Send(new GetProductsListQuery()); // این کوئری بهتره تغییر نام بده برای محصولات
            return Ok(result);
        }

        /// <summary>
        /// ایجاد محصول جدید
        /// </summary>
        [Route("AddedProduct")]
        [HttpPost]
        [ProducesResponseType(typeof(ProductResDto), 200)]
        public async Task<ActionResult<ProductResDto>> Create([FromBody] CreateProductCommand request)
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
        public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdateProductCommand request)
        {
            if (id != request.Id)
                return BadRequest("Id in route and body must match");

            var result = await _mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// حذف محصول
        /// </summary>
        [HttpDelete("{id}")]
        //[Route("api/DeleteProduct")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var request = new DeleteProductCommand { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
