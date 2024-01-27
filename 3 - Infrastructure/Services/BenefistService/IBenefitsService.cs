public interface IBenefitsService{
    
    public Task<GetBenefitsQueryResponse> GetBenefits (string CPF);
}