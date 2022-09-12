using GymEvo.Application.Classes;
using GymEvo.Application.Customers;
using GymEvo.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace GymEvo.WebApi.Controllers
{
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ClassHandler _handler;

        public ClassController(ClassHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("Class/Create")]
        public async Task<IActionResult> Insert(ClassDto dto)
        {
            var token = await _handler.Insert(dto);

            if (!token)
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        [Route("Class/Get")]
        public async Task<IActionResult> Get(int Id)
        {
            var token = await _handler.Get(Id);

            if (!token.ClassId.HasValue)
                return BadRequest();

            return Ok(token);
        }

        [HttpGet]
        [Route("Class/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _handler.GetAll();

            return Ok(new List<ClassDto>(list));
        }

        [HttpPatch]
        [Route("Class/Edit")]
        public async Task<IActionResult> Update(ClassDto dto)
        {
            var token = await _handler.Update(dto);

            if (!token)
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        [Route("Class/Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var token = await _handler.Delete(Id);

            if (!token)
                return BadRequest();

            return Ok();
        }
    }
}
