namespace Calamatta.Tests.Domain;

public class SessionTests
{
    [Fact]
    public void CreateSessionShouldBeSuccessful()
    {
        // Arrange
        // Act
        var session = new Session();

        // Assert
        session.ShouldNotBeNull();
        session.Id.ShouldNotBe(Guid.Empty);
        session.InitiatedAt.ShouldBeLessThan(DateTime.UtcNow);
        session.Status.ShouldBe(SessionStatus.Initiated);
        session.AssignedAgent.ShouldBeNull();
        session.AssignedAgentId.ShouldBeNull();
    }

    [Fact]
    public void AssignAgentShouldBeSuccessful()
    {
        // Arrange
        var session = new Session();
        var agent = new Agent("John Doe", Seniority.Junior);

        // Act
        session.AssignAgent(agent);

        // Assert
        session.AssignedAgent.ShouldBe(agent);
        session.AssignedAgentId.ShouldBe(agent.Id);
        session.Status.ShouldBe(SessionStatus.Assigned);
    }

    [Fact]
    public void AssignAgentShouldThrowArgumentNullException()
    {
        // Arrange
        var session = new Session();

        // Act & Assert
        _ = Should.Throw<ArgumentNullException>(() => session.AssignAgent(null));
    }
}