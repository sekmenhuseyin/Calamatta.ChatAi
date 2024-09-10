namespace Calamatta.ChatAi.Application.Models;

public record RabbitMqSettings(
    string Connection,
    string Username,
    string Password,
    string QueueName,
    string TopicPrefix,
    bool Disabled
)
{
    public const string SettingPath = "RabbitMQ";
}