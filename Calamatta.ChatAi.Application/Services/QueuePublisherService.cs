namespace Calamatta.ChatAi.Application.Services;

public class QueuePublisherService : IDisposable
{
    private readonly IModel? _channel;
    private readonly string _queueName;
    private bool _disposed;

    public QueuePublisherService(IConnection connection, string queueName)
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

    public void PublishMessage(string message)
    {
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish(
            exchange: "", 
            routingKey: _queueName, 
            basicProperties: null, 
            body: body);
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

    ~QueuePublisherService()
    {
        Dispose(false);
    }

}