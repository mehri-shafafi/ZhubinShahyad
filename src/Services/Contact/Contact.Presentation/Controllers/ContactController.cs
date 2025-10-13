using Contact.Application.Contact.Commands.Base.CreateContact;
using Contact.Application.Contact.Commands.Base.DeleteContact;
using Contact.Application.Contact.Commands.Contact.UpdateContact;
using Contact.Application.Contact.Queries.GetContactList;
using Contact.Domain.Contact.Models;
using Contact.Domain.Dtos.Contact;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Presentation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// دریافت لیست محصولات
        /// </summary>
        [Route("GetListContact")]
        [HttpGet]
        public async Task<ActionResult<List<ContactResDto>>> GetList()
        {
            var result = await _mediator.Send(new GetContactListQuery()); // این کوئری بهتره تغییر نام بده برای محصولات
            return Ok(result);
        }

        /// <summary>
        /// ایجاد محصول جدید
        /// </summary>
        [Route("AddedContact")]
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateCommand request)
        {
            var result = await _mediator.Send(request);
            if (!result)
            {
                return BadRequest("Not Added");
            }
            return Ok(result);
        }
        /// <summary>
        /// ویرایش محصول
        /// </summary>
        //[Route("api/UpdateProduct")]
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdateCommand request)
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
            var request = new DeleteCommand { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
