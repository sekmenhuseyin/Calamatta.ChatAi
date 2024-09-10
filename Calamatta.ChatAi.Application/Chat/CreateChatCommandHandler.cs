namespace Calamatta.ChatAi.Application.Chat;

public class CreateChatCommandHandler(
    ILogger<CreateChatCommandHandler> logger,
    IChatSessionPublisher chatSessionPublisher,
    RabbitMqSettings rabbitMqSettings
) : IRequestHandler<CreateChatCommand>
{
    public Task Handle(CreateChatCommand request, CancellationToken cancellationToken)
    {
        var chatSession = new Session();

        logger.LogInformation("ChatSession {@ChatSession} initiated ", chatSession);

        chatSessionPublisher.Publish(new ChatSessionMessage(chatSession), rabbitMqSettings.QueueName);

        return Task.CompletedTask;
    }
}