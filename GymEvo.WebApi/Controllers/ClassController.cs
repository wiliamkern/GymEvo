using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace GymEvo.WebApi.Controllers
{
    [ApiController]
    public class ClassController : ControllerBase
    {
        [HttpGet]
        [Route("Class/get")]
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
