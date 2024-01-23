public interface IAuthService {
    Task<bool> ValidateCredentialsAsync(string email, string password);
}