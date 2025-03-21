using BankCreditSystem.Application.Features.IndividualCustomers.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace BankCreditSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IndividualCustomersController : BaseController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdIndividualCustomerQueryResponse>> GetByIdAsync([FromRoute] Guid id)
    {
        return await Mediator.Send(new GetByIdIndividualCustomerQuery{Id = id});
    }
}