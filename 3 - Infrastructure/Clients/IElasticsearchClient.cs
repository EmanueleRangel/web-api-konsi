public interface IElasticsearchClient
{
    // Indexa um documento no Elasticsearch
    void Index<T>(T document) where T : class;

    // Faz uma consulta no Elasticsearch
    List<T> Search<T>(string query) where T : class;
}
