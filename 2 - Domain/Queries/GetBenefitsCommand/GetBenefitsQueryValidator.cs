using FluentValidation;

public class GetBenefitsQueryValidator : AbstractValidator<GetBenefitsQueryRequest>
{
    public GetBenefitsQueryValidator()
    {
        RuleFor(x => x.CPF).NotEmpty().Length(11).Matches("^[0-9]*$");
    }
}
