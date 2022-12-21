using BeautySalonManage.Application.Exceptions;
using BeautySalonManage.Application.Features.Clients.Commands;
using BeautySalonManage.Application.Features.Customers.Commands;
using BeautySalonManage.Application.Features.Customers.Queries;
using BeautySalonManage.Application.Features.Customers.Queries.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalonManage.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CustomersController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCustomersParameter parameter)
        {
            return Ok(await Mediator.Send(new GetAllCustomersQuery() 
            { 
                Name = parameter.Name,
                Surname = parameter.Surname,
                PageNumber = parameter.PageNumber,
                PageSize = parameter.PageSize
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetCustomerByIdQuery() { CustomerId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateCustomerCommand command)
        {
            if (id != command.CustomerId)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCustomerCommand() { CustomerId = id }));
        }
    }
}
