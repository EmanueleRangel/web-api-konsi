using FluentValidation.TestHelper;
using Xunit;

public class GetBenefitsQueryValidatorTests
{
    [Fact]
    public void Validate_InvalidCPF_ShouldHaveValidationError()
    {
        // Arrange
        var validator = new GetBenefitsQueryValidator();
        var request = new GetBenefitsQueryRequest { CPF = "invalidcpf" };

        // Act
        var result = validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.CPF)
            .WithErrorMessage("CPF must have 11 numeric characters.");
    }

    [Fact]
    public void Validate_ValidCPF_ShouldNotHaveValidationErrors()
    {
        // Arrange
        var validator = new GetBenefitsQueryValidator();
        var request = new GetBenefitsQueryRequest { CPF = "12345678900" };

        // Act
        var result = validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
