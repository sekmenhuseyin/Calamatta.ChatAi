namespace Calamatta.Tests.Domain;

public class AgentTests
{
    [Fact]
    public void CreateAgentShouldBeSuccessful()
    {
        // Arrange
        var name = "John Doe";
        var seniority = Seniority.Junior;

        // Act
        var agent = new Agent(name, seniority);

        // Assert
        agent.ShouldNotBeNull();
        agent.Id.ShouldNotBe(Guid.Empty);
        agent.Name.ShouldBe(name);
        agent.Seniority.ShouldBe(seniority);
    }

    [Fact]
    public void CreateAgentShouldThrowArgumentNullException()
    {
        _ = Should.Throw<ArgumentNullException>(() => new Agent(null, null));
        _ = Should.Throw<ArgumentNullException>(() => new Agent("name", null));
    }
}