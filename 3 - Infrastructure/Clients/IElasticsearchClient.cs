public interface IElasticsearchClient
{
    void Index<T>(T document) where T : class;

    List<T> Search<T>(string query) where T : class;
}
