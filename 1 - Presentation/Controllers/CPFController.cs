using Microsoft.AspNetCore.Mvc;

namespace webapi_konsi.Controllers;

[ApiController]
[Route("[controller]")]
public class CPFController : ControllerBase
{
    private readonly ILogger<CPFController> _logger;

    public CPFController(ILogger<CPFController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Authenticate([FromBody] AuthenticationCommandRequest request)
    {
        if (IsValidCredentials(request.Email, request.Password))
        {
            var token = "seu_token_aqui";

            return Ok(new { Token = token });
        }

        return Unauthorized();
    }
        private bool IsValidCredentials(string email, string password)
    {
        // Adicione sua lógica de verificação de credenciais aqui
        // Este é um exemplo simples
        return email == "seu_email" && password == "sua_senha";
    }
}



