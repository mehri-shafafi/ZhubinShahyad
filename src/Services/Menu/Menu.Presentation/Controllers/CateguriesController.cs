using AutoMapper;
using MediatR;
using Menus.Application.Dtos.Menu;
using Menus.Application.Menu.Commands.Categories.Create;
using Menus.Application.Menus.Commands.Categories.Delete;
using Menus.Application.Menus.Commands.Categories.Update;
using Menus.Application.Menus.Queries.Menu.GetCateguriesList;
using Microsoft.AspNetCore.Mvc;

namespace Products.Presentation.Controllers
{
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
        [Route("api/GetListProduct")]
        [HttpGet]
        [ProducesResponseType(typeof(List<MenuCategoryDto>), 200)]
        public async Task<ActionResult<List<MenuCategoryDto>>> GetList()
        {
            var result = await _mediator.Send(new GetCateguriesListQuery()); // این کوئری بهتره تغییر نام بده برای محصولات
            return Ok(result);
        }

        /// <summary>
        /// ایجاد محصول جدید
        /// </summary>
        [Route("api/AddedProduct")]
        [HttpPost]
        [ProducesResponseType(typeof(MenuCategoryDto), 200)]
        public async Task<ActionResult<MenuCategoryDto>> Create([FromBody] CreateCategoryCommand request)
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
