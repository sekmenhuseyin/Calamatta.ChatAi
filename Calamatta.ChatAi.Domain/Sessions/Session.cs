namespace Calamatta.ChatAi.Domain.Sessions;

public class Session
{
    public Guid Id { get; }
    public DateTime InitiatedAt { get; }
    public SessionStatus Status { get; set; }
    public Agent? AssignedAgent { get; set; }
    public Guid? AssignedAgentId { get; set; }

    public Session() 
    {
        Id = Guid.NewGuid();
        InitiatedAt = DateTime.UtcNow;
        Status = SessionStatus.Initiated;
    }

    public void AssignAgent(Agent agent)
    {
        AssignedAgent = agent ?? throw new ArgumentNullException(nameof(agent));
        AssignedAgentId = agent.Id;
        Status = SessionStatus.Assigned;
    }
}