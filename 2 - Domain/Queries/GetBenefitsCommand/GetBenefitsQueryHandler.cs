public class GetBenefistQueryHandler{
    private readonly IBenefitsService _benefitsService;

    public GetBenefistQueryHandler(
    IBenefitsService benefitsService)
    {
        _benefitsService = benefitsService;
    }

}