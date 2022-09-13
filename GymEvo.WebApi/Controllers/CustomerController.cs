using GymEvo.Application.Customers;
using GymEvo.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GymEvo.WebApi.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerHandler _handler;

        public CustomerController(CustomerHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("Customer/Create")]
        public async Task<IActionResult> Insert(CustomerDto dto)
        {
            var token = await _handler.Insert(dto);

            if (!token)
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        [Route("Customer/Get")]
        public async Task<IActionResult> Get(int Id)
        {
            var token = await _handler.Get(Id);

            if (!token.CustomerId.HasValue)
                return BadRequest();

            return Ok(token);
        }

        [HttpGet]
        [Route("Customer/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _handler.GetAll();

            return Ok(new List<CustomerDto>(list));
        }

        [HttpPatch]
        [Route("Customer/Edit")]
        public async Task<IActionResult> Update([FromBody] CustomerDto dto)
        {
            var token = await _handler.Update(dto);

            if (!token)
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        [Route("Device/Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var token = await _handler.Delete(Id);

            if (!token)
                return BadRequest();

            return Ok();
        }
    }
}
