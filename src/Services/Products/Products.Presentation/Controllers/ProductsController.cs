using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Dtos.Products;
using Products.Application.Products.Commands.Product.CreateMedical;
using Products.Application.Products.Commands.Product.DeleteMedical;
using Products.Application.Products.Commands.Product.DeleteProductImage;
using Products.Application.Products.Commands.Product.UpdateProduct;
using Products.Application.Products.Commands.Product.UpdateProductImage;
using Products.Application.Products.Queries.Product.GetProductsList;

namespace Products.Presentation.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    public readonly IMapper _mapper;

    public ProductsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    /// دریافت لیست محصولات
    [HttpGet("list")]
    [ProducesResponseType(typeof(List<ProductResponseDto<ProductListDto>>), 200)]
    public async Task<ActionResult<List<ProductResponseDto<ProductListDto>>>> GetListAsync()
    {
        var result = await _mediator.Send(new GetProductsListQuery()); 
        return Ok(result);
    }
    [HttpGet("productForClient")]
    //[ProducesResponseType(typeof(List<ProductResDto>), 200)]
    public async Task<ActionResult<List<ProductDetailsDto>>> GetProductForClientQuery()
    {

        var result = await _mediator.Send(new GetProductsForClientQuery()); 
        return Ok(result);
    }

    /// ایجاد محصول جدید
    [HttpPost("create")]
    [ProducesResponseType(typeof(ProductResponseDto<ProductDetailsDto>), 200)]
    public async Task<ActionResult<ProductResponseDto<ProductDetailsDto>>> CreateAsync([FromBody] CreateProductCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    /// ویرایش محصول
    [HttpPut("update/{id:int}")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<bool>> UpdateAsync(int id, [FromBody] UpdateProductCommand request)
    {
        if (id != request.ProductId)
            return BadRequest("Id in route and body must match");

        var result = await _mediator.Send(request);
        return Ok(result);
    }

    /// حذف محصول
    [HttpDelete("delete/{id:int}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<ActionResult<bool>> DeleteAsync(int id)
    {
        var request = new DeleteProductCommand { Id = id };
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    /// ویرایش عکس محصول
    [HttpPut("UpdateProductImageAsync/{id:int}")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<bool>> UpdateProductImageAsync(int id, [FromBody] UpdateProductImageCommand request)
    {
        if (id != request.Id)
            return BadRequest("Id in route and body must match");

        var result = await _mediator.Send(request);
        return Ok(result);
    }

    /// حذف عکس محصول
    [HttpDelete("deleteproductimage/{id:int}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<ActionResult<bool>> DeleteProductImageAsync(int id)
    {
        var request = new DeleteProductImageCommand { Id = id };
        var result = await _mediator.Send(request);
        return Ok(result);
    }

}
