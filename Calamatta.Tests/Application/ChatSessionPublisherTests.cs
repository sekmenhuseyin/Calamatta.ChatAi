namespace Calamatta.Tests.Application;

public class ChatSessionPublisherTests
{
    [Fact]
    public void Publish_WhenCalled_PublishesMessage()
    {
        // Arrange
        var chatSession = new Session();
        var chatSessionMessage = new ChatSessionMessage(chatSession);
        var queueName = "queueName";
        var connection = new Mock<IConnection>();
        var logger = new Mock<ILogger<ChatSessionPublisher>>();
        var publisher = new ChatSessionPublisher(logger.Object, connection.Object);

        connection.Setup(m => m.CreateModel()).Returns(new Mock<IModel>().Object);

        // Act
        publisher.Publish(chatSessionMessage, queueName);

        // Assert
        connection.Verify(m => m.CreateModel(), Times.AtLeast(1));
    }
}