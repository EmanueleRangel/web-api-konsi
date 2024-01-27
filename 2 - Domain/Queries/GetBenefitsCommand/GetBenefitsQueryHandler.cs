using MediatR;

public class GetBenefitsQueryHandler : IRequestHandler<GetBenefitsQueryRequest, GetBenefitsQueryResponse>
{
    private readonly IBenefitsService _benefitsService;
    private readonly ILogger<GetBenefitsQueryHandler> _logger;

    public GetBenefitsQueryHandler(
        IBenefitsService benefitsService,
        ILogger<GetBenefitsQueryHandler> logger)
    {
        _benefitsService = benefitsService;
        _logger = logger;
    }

    public async Task<GetBenefitsQueryResponse> Handle(GetBenefitsQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Handling GetBenefitsQuery for CPF: {request.CPF}");

            var result = await _benefitsService.GetBenefits(request.CPF);

            _logger.LogInformation($"GetBenefitsQuery handled successfully for CPF: {request.CPF}");

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error handling GetBenefitsQuery for CPF: {request.CPF}");
            throw;
        }
    }
}
