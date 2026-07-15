using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Dtos.Brands;
using Products.Application.Dtos.Products;
using Products.Application.Products.Commands.Brand.Create;
using Products.Application.Products.Commands.Categories.Delete;
using Products.Application.Products.Commands.Categories.Update;
using Products.Application.Products.Queries.Product.ById.GetBrand;
using Products.Application.Products.Queries.Product.ById.GetProductsList;
using Products.Application.Products.Queries.Product.List.GetBrandProducts;

namespace Products.Presentation.Controllers;



[ApiController]
[Route("api/brands")]
public class BrandController : ControllerBase
{
    private readonly IMediator _mediator;


    public BrandController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("list")]
    [ProducesResponseType(typeof(BrandDto), 200)]
    public async Task<ActionResult<List<BrandDto>>> GetListAsync()
    {
        var result = await _mediator.Send(new GetBrandProductsListQuery()); // این کوئری بهتره تغییر نام بده برای محصولات
        return Ok(result);
    }

    /// دریافت لیست برند
    [HttpGet("getbrandbyid")]
    [ProducesResponseType(typeof(BrandDto), 200)]
    public async Task<ActionResult<BrandDto>> GetBrandByIdAsync([FromQuery] int id)
    {
        var result = await _mediator.Send(new GetBrandByIdQuery { BrandId = id });
        return Ok(result);
    }
    [HttpPost("create")]
    public async Task<ActionResult<BrandDto>> CreateAsync([FromBody] CreateBrandCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [ProducesResponseType(typeof(bool), 200)]
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult<bool>> UpdateAsync(int id, [FromBody] UpdateBrandCommand request)
    {

        if (id != request.Id)
            return BadRequest("Id in route and body must match");

        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("delete/{id:int}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<ActionResult<bool>> DeleteAsync(int id)
    {
        var request = new DeleteBrandCommand { Id = id };
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}
