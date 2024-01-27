public class BenefitsService : IBenefitsService{
    private readonly HttpClient _httpClient;

    public BenefitsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetBenefitsQueryResponse> GetBenefits(string cpf)
    {
        var apiUrl = "http://teste-dev-api-dev-140616584.us-east-1.elb.amazonaws.com/";

        try
        {
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<GetBenefitsQueryResponse>();
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}