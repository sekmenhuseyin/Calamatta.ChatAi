namespace Calamatta.ChatAi.Domain.Agents;

public class Agent
{
    public Guid Id { get; }
    public string Name { get; } = null!;
    public Seniority Seniority { get; } = null!;

    protected Agent()
    {
    }

    public Agent(Guid id, string name, Seniority seniority) : this()
    {
        Id = id;
        Name = name;
        Seniority = seniority;
    }
}