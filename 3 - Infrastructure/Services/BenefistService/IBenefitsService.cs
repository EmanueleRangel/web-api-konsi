public interface IBenefitsService{
    
    public Task<GetBenefitsQueryResponse> GetBenefits (string CPF);
    public void AddCpfToCache(string cpf);
    public bool CpfExistsInCache(string cpf);
}