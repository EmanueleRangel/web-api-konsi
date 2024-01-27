using Moq;
using Xunit;

public class AuthenticationCommandHandlerTest
{
    [Fact]
    public async Task Handle_ValidCredentials_ReturnsToken()
    {
        // Arrange
        var authServiceMock = new Mock<IAuthService>();
        authServiceMock.Setup(x => x.ValidateCredentialsAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(true);

        var loggerMock = new Mock<ILogger<AuthenticationCommandHandler>>();

        var handler = new AuthenticationCommandHandler(authServiceMock.Object, loggerMock.Object);
        var request = new AuthenticationCommandRequest { Email = "test@example.com", Password = "password" };

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Token);

        authServiceMock.Verify(x => x.ValidateCredentialsAsync(request.Email, request.Password), Times.Once);
        loggerMock.Verify(x => x.LogInformation("Handling AuthenticationCommand"), Times.Once);
        loggerMock.Verify(x => x.LogInformation("Authentication successful for email: {Email}", request.Email), Times.Once);
        loggerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task Handle_InvalidCredentials_ReturnsNull()
    {
        // Arrange
        var authServiceMock = new Mock<IAuthService>();
        authServiceMock.Setup(x => x.ValidateCredentialsAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(false);

        var loggerMock = new Mock<ILogger<AuthenticationCommandHandler>>();

        var handler = new AuthenticationCommandHandler(authServiceMock.Object, loggerMock.Object);
        var request = new AuthenticationCommandRequest { Email = "test@example.com", Password = "password" };

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.Null(result);

        authServiceMock.Verify(x => x.ValidateCredentialsAsync(request.Email, request.Password), Times.Once);
        loggerMock.Verify(x => x.LogInformation("Handling AuthenticationCommand"), Times.Once);
        loggerMock.Verify(x => x.LogWarning("Authentication failed for email: {Email}", request.Email), Times.Once);
        loggerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task Handle_ExceptionThrown_LogsErrorAndThrowsException()
    {
        // Arrange
        var authServiceMock = new Mock<IAuthService>();
        authServiceMock.Setup(x => x.ValidateCredentialsAsync(It.IsAny<string>(), It.IsAny<string>())).ThrowsAsync(new Exception("Test Exception"));

        var loggerMock = new Mock<ILogger<AuthenticationCommandHandler>>();

        var handler = new AuthenticationCommandHandler(authServiceMock.Object, loggerMock.Object);
        var request = new AuthenticationCommandRequest { Email = "test@example.com", Password = "password" };

        // Act/Assert
        await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(request, CancellationToken.None));

        authServiceMock.Verify(x => x.ValidateCredentialsAsync(request.Email, request.Password), Times.Once);
        loggerMock.Verify(x => x.LogInformation("Handling AuthenticationCommand"), Times.Once);
        loggerMock.Verify(x => x.LogError(It.IsAny<Exception>(), "Error handling AuthenticationCommand"), Times.Once);
        loggerMock.VerifyNoOtherCalls();
    }
}
