namespace Calamatta.ChatAi.Application.Services;

public interface IChatSessionPublisher
{
    void Publish(ChatSessionMessage chatSessionMessage, string queueName);
}

public record ChatSessionMessage(Session ChatSession);

public class ChatSessionPublisher(
    ILogger<ChatSessionPublisher> logger,
    IConnection connection
) : IChatSessionPublisher
{
    public void Publish(ChatSessionMessage chatSessionMessage, string queueName)
    {
        using var publisher = new QueuePublisherService(connection, queueName);
        var jsonString = JsonSerializer.Serialize(chatSessionMessage);

        publisher.PublishMessage(jsonString);

        logger.LogInformation(1,"ChatSessionMessage {@ChatSessionMessage} sent to RabbitMQ queue '{QueueName}'", 
            chatSessionMessage,
            queueName);
    }
}