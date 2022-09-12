using GymEvo.Application.Customers;
using GymEvo.Application.DTOs;
using GymEvo.Application.Instructors;
using Microsoft.AspNetCore.Mvc;

namespace GymEvo.WebApi.Controllers
{
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly InstructorHandler _handler;

        public InstructorController(InstructorHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("Instructor/Create")]
        public async Task<IActionResult> Insert(InstructorDto dto)
        {
            var token = await _handler.Insert(dto);

            if (!token)
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        [Route("Instructor/Get")]
        public async Task<IActionResult> Get(int Id)
        {
            var token = await _handler.Get(Id);

            if (!token.InstructorId.HasValue)
                return BadRequest();

            return Ok(token);
        }

        [HttpGet]
        [Route("Instructor/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _handler.GetAll();

            return Ok(new List<InstructorDto>(list));
        }

        [HttpPatch]
        [Route("Instructor/Edit")]
        public async Task<IActionResult> Update(InstructorDto dto)
        {
            var token = await _handler.Update(dto);

            if (!token)
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        [Route("Instructor/Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var token = await _handler.Delete(Id);

            if (!token)
                return BadRequest();

            return Ok();
        }
    }
}
