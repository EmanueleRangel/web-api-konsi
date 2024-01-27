using FluentValidation.TestHelper;
using Moq;
using Xunit;

public class AuthenticationCommandValidatorTest
{
    [Fact]
    public void Validate_InvalidEmail_ShouldHaveValidationError()
    {
        // Arrange
        var validator = new AuthenticationCommandValidator();
        var request = new AuthenticationCommandRequest { Email = "invalidemail", Password = "password" };

        // Act
        var result = validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void Validate_ValidEmailAndPassword_ShouldNotHaveValidationErrors()
    {
        // Arrange
        var validator = new AuthenticationCommandValidator();
        var request = new AuthenticationCommandRequest { Email = "valid@email.com", Password = "password" };

        // Act
        var result = validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void Validate_PasswordTooShort_ShouldHaveValidationError()
    {
        // Arrange
        var validator = new AuthenticationCommandValidator();
        var request = new AuthenticationCommandRequest { Email = "valid@email.com", Password = "short" };

        // Act
        var result = validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Password)
            .WithErrorMessage("Password must be at least 6 characters long.");
    }
}
