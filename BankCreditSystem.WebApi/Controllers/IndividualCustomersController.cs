using BankCreditSystem.Application.Features.IndividualCustomers.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace BankCreditSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IndividualCustomersController : BaseController
{

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdIndividualCustomerQuery getByIdIndividualCustomerQuery)
    {
        var result = await Mediator.Send(getByIdIndividualCustomerQuery);
        return Ok(result);
    }
} 