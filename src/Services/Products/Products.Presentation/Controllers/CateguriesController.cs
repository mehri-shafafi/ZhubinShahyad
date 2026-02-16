using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Dtos.Products;
using Products.Application.Products.Commands.Categories.Create;
using Products.Application.Products.Commands.Categories.Delete;
using Products.Application.Products.Commands.Categories.Update;
using Products.Application.Products.Queries.Product.GetCateguriesList;

namespace Products.Presentation.Controllers;


[ApiController]
[Route("api/categories")]
public class CateguriesController : ControllerBase
{
    private readonly IMediator _mediator;
    public readonly IMapper _mapper;

    public CateguriesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("list")]
    [ProducesResponseType(typeof(List<ProductCategoryDto>), 200)]
    public async Task<ActionResult<List<ProductCategoryDto>>> GetListAsync()
    {
        var result = await _mediator.Send(new GetCateguriesListQuery());
        return Ok(result);
    }


    [HttpPost("create")]
    [ProducesResponseType(typeof(ProductCategoryDto), 200)]
    public async Task<ActionResult<ProductCategoryDto>> CreateAsync([FromBody] CreateCategoryCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("update/{id:int}")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<bool>> UpdateAsync(int id, [FromBody] UpdateCategoryCommand request)
    {

        request.Id = id;
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("delete/{id:int}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<ActionResult<bool>> DeleteAsync(int id)
    {
        var request = new DeleteCategoryCommand { Id = id };
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}
