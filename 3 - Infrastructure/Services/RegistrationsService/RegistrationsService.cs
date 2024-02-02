public class MatriculasService
{
    private readonly IElasticsearchClient _elasticsearchClient;

    public MatriculasService(IElasticsearchClient elasticsearchClient)
    {
        _elasticsearchClient = elasticsearchClient;
    }

    public void IndexarMatriculas(string cpf, List<Registration> matriculas)
    {
        var document = new Document
        {
            Cpf = cpf,
            Registrations = matriculas
        };

        _elasticsearchClient.Index(document);
    }
}
