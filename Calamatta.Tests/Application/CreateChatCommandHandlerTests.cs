namespace Calamatta.Tests.Application;

public class CreateChatCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldPublishChatSessionMessage()
    {
        // Arrange
        var logger = new Mock<ILogger<CreateChatCommandHandler>>();
        var chatSessionPublisher = new Mock<IChatSessionPublisher>();
        var rabbitMqSettings = new RabbitMqSettings(
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            false
        );

        var handler = new CreateChatCommandHandler(logger.Object, chatSessionPublisher.Object, rabbitMqSettings);
        var command = new CreateChatCommand();

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        chatSessionPublisher.Verify(x => x.Publish(It.IsAny<ChatSessionMessage>(), rabbitMqSettings.QueueName), Times.Once);
    }
}