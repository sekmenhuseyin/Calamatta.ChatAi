namespace Calamatta.ChatAi.Domain.Agents;

public class Agent
{
    public Guid Id { get; }
    public string Name { get; }
    public Seniority Seniority { get; }

    public Agent(string name, Seniority seniority)
    {
        Id = Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Seniority = seniority ?? throw new ArgumentNullException(nameof(seniority));
    }
}