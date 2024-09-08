namespace Calamatta.ChatAi.Domain.Sessions;

public class Session
{
    public Guid Id { get; }
    public DateTime InitiatedAt { get; }
    public SessionStatus Status { get; set; } = null!;
    public Agent? AssignedAgent { get; set; }
    public Guid? AssignedAgentId { get; set; }

    protected Session()
    {
    }

    public Session(Guid id, DateTime initiatedAt) : this()
    {
        Id = id;
        InitiatedAt = initiatedAt;
        Status = SessionStatus.Initiated;
    }

    public void AssignAgent(Agent agent)
    {
        AssignedAgent = agent;
        AssignedAgentId = agent.Id;
        Status = SessionStatus.Assigned;
    }
}