
using System.Threading.Tasks;
using System;
using System.Net.Http;

public class AuthService{
    private readonly string _externalApiUrl;
    private readonly string _httpClient;

    public AuthService(HttpClient httpClient, string externalApiUrl)
    {
        _httpClient = httpClient;
        _externalApiUrl = externalApiUrl;
    }
    public async Task<bool> ValidateCredentialsAsync(string email, string password)
    {
        var requestData = new { Email = email, Password = password };

        var response = await _httpClient.PostAsJsonAsync(_externalApiUrl, requestData);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsAsync<bool>();
            return result;
        }

        return false;
    }
}