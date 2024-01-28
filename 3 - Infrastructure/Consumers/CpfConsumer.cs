public class CpfsConsumer
{
    private readonly IRabbitMQClient _rabbitMQClient;
    private readonly IBenefitsService _benefitsService;
    private readonly IRegistrationsService _registrationsService;

    public CpfsConsumer(IRabbitMQClient rabbitMQClient, IBenefitsService cpfService, IRegistrationsService matriculasService)
    {
        _rabbitMQClient = rabbitMQClient;
        _benefitsService = cpfService;
        _registrationsService = matriculasService;
    }

    public void Consume()
    {
        _rabbitMQClient.Connect();

        _rabbitMQClient.CreateQueue("cpf-queue");

        _rabbitMQClient.Consume("cpf-queue", this.OnMessageReceived);

        while (true)
        {
        }
    }

    private void OnMessageReceived(Message message)
    {
        string cpf = message.Cpf;

        if (!_benefitsService.CpfExistsInCache(cpf))
        {
            List<Registration> matriculas = new List<Registration>();

            _registrationsService.IndexarMatriculas(cpf, matriculas);

            _benefitsService.AddCpfToCache(cpf);
        }
    }
}
