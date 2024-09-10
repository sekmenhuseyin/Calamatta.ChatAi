namespace Calamatta.ChatAi.Application.Services;

public class QueueConsumerService : IDisposable
{
    private readonly IModel? _channel;
    private readonly string _queueName;
    private bool _disposed;

    public QueueConsumerService(IConnection connection, string queueName)
    {
        _channel = connection.CreateModel();
        _queueName = queueName;

        _channel.QueueDeclare(
            queue: _queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    public void StartConsuming(EventHandler<BasicDeliverEventArgs> messageHandler)
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += messageHandler;

        _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing || _channel == null || _disposed)
        {
            return;
        }

        _channel.Dispose();
        _disposed = true;
    }

    ~QueueConsumerService()
    {
        Dispose(false);
    }
}