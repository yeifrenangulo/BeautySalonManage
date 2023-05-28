using BeautySalonManage.Application.Customers.Commands.Create.CreateCustomer;
using BeautySalonManage.Application.Customers.Commands.Delete.DeleteCustomer;
using BeautySalonManage.Application.Customers.Commands.Update.UpdateCustomer;
using BeautySalonManage.Application.Customers.Queries.GetAllCustomers;
using BeautySalonManage.Application.Customers.Queries.GetCustomerById;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalonManage.WebApi.Controllers.v1;

[ApiVersion("1.0")]
//[Authorize]
public class CustomersController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllCustomersQuery query)
    {
        return Ok(await Mediator.Send(query));
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
        if (id != command.Id)
            return BadRequest();

        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteCustomerCommand() { Id = id }));
    }
}
