using MediatR;

public class AuthenticationCommandRequest : IRequest<AuthenticationCommandResponse>{
    public string Email { get; set; }
    public string Password { get; set; }
}