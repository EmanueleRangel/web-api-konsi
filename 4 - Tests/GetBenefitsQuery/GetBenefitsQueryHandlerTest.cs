using Moq;
using Xunit;

public class GetBenefitsQueryHandlerTest
{
    [Fact]
    public async Task Handle_SuccessfulExecution_ReturnsResult()
    {
        // Arrange
        var benefitsServiceMock = new Mock<IBenefitsService>();
        benefitsServiceMock.Setup(x => x.GetBenefits(It.IsAny<string>())).ReturnsAsync(new GetBenefitsQueryResponse());

        var loggerMock = new Mock<ILogger<GetBenefitsQueryHandler>>();

        var handler = new GetBenefitsQueryHandler(benefitsServiceMock.Object, loggerMock.Object);
        var request = new GetBenefitsQueryRequest { CPF = "12345678900" };

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        benefitsServiceMock.Verify(x => x.GetBenefits(request.CPF), Times.Once);
        loggerMock.Verify(x => x.LogInformation($"Handling GetBenefitsQuery for CPF: {request.CPF}"), Times.Once);
        loggerMock.Verify(x => x.LogInformation($"GetBenefitsQuery handled successfully for CPF: {request.CPF}"), Times.Once);
        loggerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task Handle_ExceptionThrown_LogsErrorAndThrowsException()
    {
        // Arrange
        var benefitsServiceMock = new Mock<IBenefitsService>();
        benefitsServiceMock.Setup(x => x.GetBenefits(It.IsAny<string>())).ThrowsAsync(new Exception("Test Exception"));

        var loggerMock = new Mock<ILogger<GetBenefitsQueryHandler>>();

        var handler = new GetBenefitsQueryHandler(benefitsServiceMock.Object, loggerMock.Object);
        var request = new GetBenefitsQueryRequest { CPF = "12345678900" };

        // Act/Assert
        await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(request, CancellationToken.None));

        benefitsServiceMock.Verify(x => x.GetBenefits(request.CPF), Times.Once);
        loggerMock.Verify(x => x.LogInformation($"Handling GetBenefitsQuery for CPF: {request.CPF}"), Times.Once);
        loggerMock.Verify(x => x.LogError(It.IsAny<Exception>(), $"Error handling GetBenefitsQuery for CPF: {request.CPF}"), Times.Once);
        loggerMock.VerifyNoOtherCalls();
    }
}
