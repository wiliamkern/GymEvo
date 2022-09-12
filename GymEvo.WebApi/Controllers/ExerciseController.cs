using GymEvo.Application.DTOs;
using GymEvo.Application.Exercises;
using Microsoft.AspNetCore.Mvc;

namespace GymEvo.WebApi.Controllers
{
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly ExerciseHandler _handler;

        public ExerciseController(ExerciseHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("Exercise/Create")]
        public async Task<IActionResult> Insert(ExerciseDto dto)
        {
            var token = await _handler.Insert(dto);

            if (!token)
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        [Route("Exercise/Get")]
        public async Task<IActionResult> Get(int Id)
        {
            var token = await _handler.Get(Id);

            if (!token.ExerciseId.HasValue)
                return BadRequest();

            return Ok(token);
        }

        [HttpGet]
        [Route("Exercise/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _handler.GetAll();

            return Ok(new List<ExerciseDto>(list));
        }

        [HttpPatch]
        [Route("Exercise/Edit")]
        public async Task<IActionResult> Update(ExerciseDto dto)
        {
            var token = await _handler.Update(dto);

            if (!token)
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        [Route("Exercise/Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var token = await _handler.Delete(Id);

            if (!token)
                return BadRequest();

            return Ok();
        }
    }
}
