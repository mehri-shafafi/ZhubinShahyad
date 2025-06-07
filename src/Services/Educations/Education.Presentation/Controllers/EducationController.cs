using Education.Application.Education.Commands.Education.Update;
using Education.Application.EducationCommands.Commands.Create;
using Education.Application.EducationCommands.Commands.Delete;
using Education.Application.EducationComments.Queries.GetAllEducationComments;
using Education.Domain.Education.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Education.Presentation.Controllers
{
    [Route("api/Education/")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EducationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [Route("GetListTraining")]
        [HttpGet()]
        [ProducesResponseType(typeof(List<TrainingDto>), 200)]
        public async Task<List<TrainingDto>> GetList([FromQuery] string lang = "fa")
        {
            var query = new GetAllEducationCommentsQuery(); // اگه زبان رو بخوای بدی، باید به query اضافه‌ش کنی
            var result = await _mediator.Send(query);
            return result;

        }

        [Route("AddedTraining")]
        [HttpPost]
        [ProducesResponseType(typeof(TrainingDto), 200)]
        public async Task<TrainingDto> Create(CreateEducationCommand request)
        {
            return await _mediator.Send(request);
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> Update(int id, UpdateEducationCommand request)
        {
            if (id != request.Id)
            {

                return BadRequest("Id in body and query must be equal");
            }
            var res = await _mediator.Send(request);
            return res;

        }
        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        //[Route("api/DeleteProduct")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<bool> Delete(DeleteEducationCommand request)
        {
            var res = await _mediator.Send(request);
            return res;
        }

    }
}
