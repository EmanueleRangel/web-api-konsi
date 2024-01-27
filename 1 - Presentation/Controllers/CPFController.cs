using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace webapi_konsi.Controllers;

[ApiController]
[Route("[controller]")]
public class CPFController : ControllerBase
{
    private readonly IMediator _mediator;

    public CPFController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{cpf}")]
    public async Task<IActionResult> GetBenefitData(string cpf)
    {
        var request = new GetBenefitsQueryRequest { CPF = cpf };
        var result = await _mediator.Send(request);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticationCommandRequest request)
    {
        var requestBody = new AuthenticationCommandRequest(){Email = request.Email, Password = request.Password};

        var result = await _mediator.Send(requestBody);

        return Ok(result);
    }
}



