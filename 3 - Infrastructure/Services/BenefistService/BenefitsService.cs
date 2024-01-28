public class BenefitsService : IBenefitsService
{
    private readonly HttpClient _httpClient;
    private readonly IRedisClient _redisClient;

    public BenefitsService(HttpClient httpClient, IRedisClient redisClient)
    {
        _httpClient = httpClient;
        _redisClient = redisClient;
    }
public void AddCpfToCache(string cpf)
{
    _redisClient.Set(cpf, "{}");
}

public bool CpfExistsInCache(string cpf)
{
    string value = _redisClient.Get(cpf);
    return value != null;
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
                // Handle non-success status codes appropriately
                throw new HttpRequestException("API request failed with status code: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
           
            throw ex;
        }
    }

}
