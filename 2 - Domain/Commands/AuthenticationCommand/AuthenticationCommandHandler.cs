// Handlers/AuthHandler.cs
using Microsoft.AspNetCore.Mvc;

public class AuthHandler
{
    private readonly IAuthService _externalAuthService;

    public AuthHandler(IAuthService externalAuthService)
    {
        _externalAuthService = externalAuthService;
    }

    public async Task<IActionResult> HandleAsync(HttpContext context)
    {
        var request = await context.Request.ReadFromJsonAsync<AuthenticationCommandRequest>();

        // Use o serviço de integração para validar credenciais
        var isValidCredentials = await _externalAuthService.ValidateCredentialsAsync(request?.Email, request?.Password);

        if (isValidCredentials)
        {
            var token = "seu_token_aqui";
            return new ObjectResult(new { Token = token }) { StatusCode = StatusCodes.Status200OK };
        }

        return new ObjectResult("Credenciais inválidas") { StatusCode = StatusCodes.Status401Unauthorized };
    }
}
