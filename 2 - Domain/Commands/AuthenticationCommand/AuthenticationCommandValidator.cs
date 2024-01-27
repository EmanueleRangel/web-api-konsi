using FluentValidation;

public class AuthenticationCommandValidator : AbstractValidator<AuthenticationCommandRequest>
{
    public AuthenticationCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
    }
}
