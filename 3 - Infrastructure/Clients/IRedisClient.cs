public interface IRedisClient
{
    void Connect();
    string Get(string key);
    void Set(string key, string value);
    void Delete(string key);
    List<string> Keys(string pattern);
    bool Exists(string key);
    void Expire(string key, int seconds);
}
