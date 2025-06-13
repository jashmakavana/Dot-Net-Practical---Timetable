using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timetable.Application.CQRS.Commands;
using Timetable.Domain.Request;

namespace Timetable.API.Controllers
{
    [Route("api/timetable")]
    [ApiController]
    public class TimetableController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TimetableController(IMediator mediator) => _mediator = mediator;

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateTimetable([FromBody] GenerateTimetableRequest generateTimetableRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _mediator.Send(new GenerateTimetableCommand(generateTimetableRequest));

            return Ok(result);
        }
    }
}
