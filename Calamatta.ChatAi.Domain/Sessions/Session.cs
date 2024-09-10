namespace Calamatta.ChatAi.Domain.Sessions;

public class Session
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime InitiatedAt { get; } = DateTime.UtcNow;
    public SessionStatus Status { get; set; } = SessionStatus.Initiated;
    public Agent? AssignedAgent { get; set; }
    public Guid? AssignedAgentId { get; set; }

    public void AssignAgent(Agent agent)
    {
        AssignedAgent = agent ?? throw new ArgumentNullException(nameof(agent));
        AssignedAgentId = agent.Id;
        Status = SessionStatus.Assigned;
    }
}