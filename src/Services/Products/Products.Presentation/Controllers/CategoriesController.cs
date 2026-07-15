using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Dtos.Brands;
using Products.Application.Dtos.Categories;
using Products.Application.Products.Commands.Categories.Create;
using Products.Application.Products.Commands.Categories.Delete;
using Products.Application.Products.Commands.Categories.Update;
using Products.Application.Products.Queries.Product.ById.GetBrand;
using Products.Application.Products.Queries.Product.List.GetCateguriesList;

namespace Products.Presentation.Controllers;


[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("list")]
    [ProducesResponseType(typeof(List<CategoryDto>), 200)]
    public async Task<ActionResult<List<CategoryDto>>> GetListAsync()
    {
        var result = await _mediator.Send(new GetCategoriesQuery());
        return Ok(result);
    }

    [HttpGet("getcategorybyid")]
    [ProducesResponseType(typeof(CategoryDto), 200)]
    public async Task<ActionResult<CategoryDto>> GetBCategoryByIdAsync([FromQuery] int id)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery { CategoryId = id });
        return Ok(result);
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(CategoryDto), 200)]
    public async Task<ActionResult<CategoryDto>> CreateAsync([FromBody] CreateCategoryCommand request)
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
