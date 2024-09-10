namespace Calamatta.Tests.Application;

public class QueueConsumerServiceTests
{
    [Fact]
    public void StartConsuming_WithMessageHandler_ShouldStartConsumingMessages()
    {
        // Arrange
        var connection = new Mock<IConnection>();
        var channel = new Mock<IModel>();
        var consumer = new Mock<EventingBasicConsumer>(channel.Object);
        var messageHandler = new EventHandler<BasicDeliverEventArgs>((_, _) => { });
        var queueName = "test-queue";

        connection.Setup(c => c.CreateModel()).Returns(channel.Object);
        channel.Setup(c => c.QueueDeclare(
            queueName,
            false,
            false,
            false,
            null
        ));
        channel.Setup(c => c.BasicConsume(
            queueName,
            true,
            "", false, false, null,
            consumer.Object
        ));

        var queueConsumerService = new QueueConsumerService(connection.Object, queueName);

        // Act
        queueConsumerService.StartConsuming(messageHandler);

        // Assert
        channel.Verify(c => c.BasicConsume(
            queueName,
            true,
            "", false, false, null, 
            It.IsAny<EventingBasicConsumer>()
        ), Times.AtLeastOnce);
    }
}