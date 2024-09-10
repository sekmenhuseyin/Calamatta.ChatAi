namespace Calamatta.Tests.Application;

public class QueuePublisherServiceTests
{
    [Fact]
    public void PublishMessage_WhenCalled_ShouldPublishMessage()
    {
        // Arrange
        var connection = new Mock<IConnection>();
        var model = new Mock<IModel>();
        connection.Setup(c => c.CreateModel()).Returns(model.Object);
        var queueName = "test-queue";
        var message = "test-message";
        var service = new QueuePublisherService(connection.Object, queueName);

        // Act
        service.PublishMessage(message);

        // Assert
        model.Verify(m => m.BasicPublish(
            "",
            queueName,
            false,
            null,
            It.IsAny<ReadOnlyMemory<byte>>()
        ), Times.Once);
    }
}