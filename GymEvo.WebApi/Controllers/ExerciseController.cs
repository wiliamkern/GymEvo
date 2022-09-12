using Microsoft.AspNetCore.Mvc;

namespace GymEvo.WebApi.Controllers
{
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        [HttpGet]
        [Route("Exercise/get")]
        public IActionResult Get(Guid id)
        {
            /* var token = await _handler.GetById(id);

             if (_notification.HasNotification())
                 return BadRequest(new BadRequestDto(_notification));

             return Ok(new OkDto<CompanyDto>(token));*/

            return Ok();
        }
    }
}
