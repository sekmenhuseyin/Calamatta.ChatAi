namespace Calamatta.ChatAi.Domain.Sessions;

public class SessionStatus(int value, string name)
    : Enumeration<SessionStatus>(value, name)
{
    public static readonly SessionStatus Initiated = new(1, nameof(Initiated));
    public static readonly SessionStatus Assigned = new(2, nameof(Assigned));
    public static readonly SessionStatus Inactive = new(3, nameof(Inactive));
    public static readonly SessionStatus Queued = new(4, nameof(Queued));
    public static readonly SessionStatus Refused = new(5, nameof(Refused));

}