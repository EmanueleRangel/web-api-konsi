using MediatR;

public class AuthenticationCommandHandler : IRequestHandler<AuthenticationCommandRequest, AuthenticationCommandResponse>
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthenticationCommandHandler> _logger;

    public AuthenticationCommandHandler(IAuthService authService, ILogger<AuthenticationCommandHandler> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    public async Task<AuthenticationCommandResponse> Handle(AuthenticationCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Handling AuthenticationCommand");

            var isValidCredentials = await _authService.ValidateCredentialsAsync(request?.Email, request?.Password);

            if (isValidCredentials)
            {
                var response = new AuthenticationCommandResponse();
                var token = response.Token;
                _logger.LogInformation("Authentication successful for email: {Email}", request?.Email);
                return new AuthenticationCommandResponse{Token = token};
            }
            _logger.LogWarning("Authentication failed for email: {Email}", request?.Email);
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error handling AuthenticationCommand");
            throw ex;
        }
    }
}
