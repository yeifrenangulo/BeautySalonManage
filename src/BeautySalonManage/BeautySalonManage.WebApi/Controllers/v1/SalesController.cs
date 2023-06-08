using BeautySalonManage.Application.Sales.Commands.Create.CreateSale;
using BeautySalonManage.Application.Sales.Commands.Delete.DeleteSale;
using BeautySalonManage.Application.Sales.Commands.Update.UpdateSale;
using BeautySalonManage.Application.Sales.Queries.GetAllSales;
using BeautySalonManage.Application.Sales.Queries.GetSaleById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalonManage.WebApi.Controllers.v1;

[ApiVersion("1.0")]
[Authorize]
public class SalesController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllSalesQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await Mediator.Send(new GetSaleByIdQuery() { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateSaleCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateSaleCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await Mediator.Send(new DeleteSaleCommand() { Id = id }));
    }
}
