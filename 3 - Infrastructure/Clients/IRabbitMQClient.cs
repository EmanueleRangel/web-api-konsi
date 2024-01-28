public interface IRabbitMQClient
{
    void Connect();
    void CreateQueue(string queueName);
    void Publish(string message, string routingKey);
    void Consume(string queueName, Action<Message> callback);
    void Acknowledge(Message message);
    void Disconnect();
    void DeleteQueue(string queueName);
    void DeclareExchange(string exchangeName, string exchangeType);
    void BindQueue(string queueName, string exchangeName, string routingKey);
}
