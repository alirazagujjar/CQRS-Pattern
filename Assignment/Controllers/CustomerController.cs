using Assignment.Application.Command;
using Assignment.Application.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new CustomerGetRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Customer customer)
        {
            var response = await _mediator.Send(new CustomerAddRequest { Data = customer });
            if (response)
            {
                return Ok("Customer added successfully."); // Return a success message
            }
            else
            {
                return BadRequest("Failed to add customer."); // Return an error message
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var response = await _mediator.Send(new CustomerDeleteRequest { Id = id });
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(Customer request)
        {
            var response = await _mediator.Send(new CustomerUpdateRequest { Data = request });
            if(response)
               return Ok(response);
            return NotFound();
        }

    }
}
