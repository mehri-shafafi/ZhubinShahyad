using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Dtos.Products;
using Products.Application.Products.Commands.Brand.Create;
using Products.Application.Products.Commands.Categories.Delete;
using Products.Application.Products.Commands.Categories.Update;
using Products.Application.Products.Commands.Product.CreateMedical;
using Products.Application.Products.Commands.Product.DeleteMedical;
using Products.Application.Products.Commands.Product.UpdateProduct;
using Products.Application.Products.Queries.Product.GetBrandProducts;

namespace Products.Presentation.Controllers
{


    [ApiController]
    [Route("api/[controller]/")]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;
    

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("GetListBrandProducts")]
        [HttpGet]
        [ProducesResponseType(typeof(ProductBrandDto), 200)]
        public async Task<ActionResult<List<ProductBrandDto>>> GetListBrandProducts()
        {
            var result = await _mediator.Send(new GetBrandProductsListQuery()); // این کوئری بهتره تغییر نام بده برای محصولات
            return Ok(result);
        }
        /// <summary>
        /// ایجاد برند جدید
        /// </summary>
        [Route("AddedBrand")]
        [HttpPost]
        public async Task<ActionResult<ProductBrandDto>> Create([FromBody] CreateBrandCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        /// <summary>
        /// ویرایش برند
        /// </summary>
        // [Route("UpdateBrand")]
        [ProducesResponseType(typeof(bool), 200)]
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdateBrandCommand request)
        {

            if (id != request.Id)
                return BadRequest("Id in route and body must match");

            var result = await _mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// حذف برند
        /// </summary>
        [HttpDelete("{id}")]
        //[Route("DeleteBrand")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var request = new DeleteBrandCommand { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
