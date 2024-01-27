using Microsoft.AspNetCore.Mvc;

namespace webapi_konsi.Controllers;

[ApiController]
[Route("[controller]")]
public class CPFController : ControllerBase
{
    private readonly ILogger<CPFController> _logger;
    private readonly IBenefitsService _benefitsService;
    private readonly IAuthService _authService;

    public CPFController(ILogger<CPFController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Authenticate([FromBody] AuthenticationCommandRequest request)
    {
        _authService.ValidateCredentialsAsync(request.Email, request.Password);

        var response = new AuthenticationCommandResponse();

        return Ok(response);
    }


 [HttpGet]        
    public IActionResult Get(GetBenefitsQueryRequest request)
    {
        var benefits = _benefitsService.GetBenefits(request.CPF);
        return Ok(benefits);
    } 
}



