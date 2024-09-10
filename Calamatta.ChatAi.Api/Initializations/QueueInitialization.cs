namespace Calamatta.ChatAi.Api.Initializations;

public static class QueueInitialization
{
    public static void AddQueuePublisher(this WebApplicationBuilder builder)
    {
        var rabbitMqSettings = builder.Configuration.GetSection(RabbitMqSettings.SettingPath).Get<RabbitMqSettings>();

        if (rabbitMqSettings?.Disabled ?? true)
        {
            builder.Services.AddSingleton<IChatSessionPublisher, NullChatSessionPublisher>();
        }
        else
        {
            builder.Services.AddSingleton(rabbitMqSettings);
            builder.Services.AddSingleton<IChatSessionPublisher, ChatSessionPublisher>();
            builder.Services.AddSingleton<IConnection>(_ =>
            {
                var factory = new ConnectionFactory
                {
                    Uri = new Uri(rabbitMqSettings.Connection),
                    UserName = rabbitMqSettings.Username,
                    Password = rabbitMqSettings.Password
                };

                return factory.CreateConnection();
            });
        }
    }
}

public class NullChatSessionPublisher : IChatSessionPublisher
{
    public void Publish(ChatSessionMessage chatSessionMessage, string queueName)
    {
    }
}