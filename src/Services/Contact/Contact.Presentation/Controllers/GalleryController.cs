using AutoMapper;
using Gallery.Application.Gallery.Commands.Base.CreateGallery;
using Gallery.Application.Gallery.Commands.Base.DeleteGallery;
using Gallery.Application.Gallery.Commands.Base.UpdateGallery;
using Gallery.Application.Gallery.Queries.GetGalleryList;
using Gallery.Domain.Dtos.Gallery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Products.Presentation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public GalleryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// دریافت لیست محصولات
        /// </summary>
        [Route("GetListGallery")]
        [HttpGet]
        public async Task<ActionResult<List<GalleryResDto>>> GetList()
        {
            var result = await _mediator.Send(new GetGalleryListQuery()); // این کوئری بهتره تغییر نام بده برای محصولات
            return Ok(result);
        }

        /// <summary>
        /// ایجاد محصول جدید
        /// </summary>
        [Route("AddedGallery")]
        [HttpPost]
        [ProducesResponseType(typeof(GalleryResDto), 200)]
        public async Task<ActionResult<GalleryResDto>> Create([FromBody] CreateGalleryCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        /// <summary>
        /// ویرایش محصول
        /// </summary>
        //[Route("api/UpdateProduct")]
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdateGalleryCommand request)
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
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var request = new DeleteGalleryCommand { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
