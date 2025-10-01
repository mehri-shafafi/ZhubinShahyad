using AutoMapper;
using MediatR;
using Menus.Application.Dtos.Menu;
using Menus.Application.Menu.Commands.Menu.Create;
using Menus.Application.Menus.Commands.Menu.DeleteMedical;
using Menus.Application.Menus.Commands.Menu.UpdateMenu;
using Menus.Application.Menus.Queries.Menu.GetMenusList;
using Microsoft.AspNetCore.Mvc;
using Products.Domain.Base;

namespace Products.Presentation.Controllers
{
    [Route("api/[controller]")]
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
        [Route("api/GetListProduct")]
        [HttpGet]
        [ProducesResponseType(typeof(PaginitionResDto<List<MenuResDto>>), 200)]
        public async Task<ActionResult<PaginitionResDto<List<MenuResDto>>>> GetList()
        {
            var result = await _mediator.Send(new GetMenusListQuery()); // این کوئری بهتره تغییر نام بده برای محصولات
            return Ok(result);
        }

        /// <summary>
        /// ایجاد محصول جدید
        /// </summary>
        [Route("api/AddedProduct")]
        [HttpPost]
        [ProducesResponseType(typeof(MenuResDto), 200)]
        public async Task<ActionResult<MenuResDto>> Create([FromBody] CreateMenuCommand request)
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
        public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdateMenuCommand request)
        {
            if (id != request.Id)
                return BadRequest("Id in route and body must match");

            var result = await _mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// حذف محصول
        /// </summary>
        [HttpDelete]
        //[Route("api/DeleteProduct")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var request = new DeleteMenuCommand { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
