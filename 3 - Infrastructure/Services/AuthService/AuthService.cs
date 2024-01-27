public class AuthService{
    private readonly string _externalApiUrl = "http://teste-dev-api-dev-140616584.us-east-1.elb.amazonaws.com/";
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient, string externalApiUrl)
    {
        _httpClient = httpClient;
        _externalApiUrl = externalApiUrl;
    }
    public async Task<string> ValidateCredentialsAsync(string email, string password)
{
    try
    {
        var requestData = new AuthenticationCommandRequest{ Email = email, Password = password };

        var response = await _httpClient.PostAsJsonAsync(_externalApiUrl, requestData);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<AuthenticationCommandResponse>();

        if (result != null && !string.IsNullOrEmpty(result.Token))
        {
            return result.Token;
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