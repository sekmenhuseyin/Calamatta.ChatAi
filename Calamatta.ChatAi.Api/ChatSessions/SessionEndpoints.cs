namespace Calamatta.ChatAi.Api.ChatSessions;

public static class SessionEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapGroup("/chat")
            .MapChatSessions()
            .WithOpenApi();
    }

    private static RouteGroupBuilder MapChatSessions(this RouteGroupBuilder group)
    {
        group.MapGet("", GetAllChatSessions);
        group.MapGet("/{id:guid}", GetChatSession);
        group.MapPost("", CreateChatSession);
        group.MapPut("/{id:guid}", UpdateChatSession);
        group.MapDelete("/{id:guid}", DeleteChatSession);

        return group;
    }

    private static Task GetAllChatSessions(HttpContext context)
    {
        return context.Response.WriteAsJsonAsync(nameof(GetAllChatSessions));
    }

    private static Task GetChatSession(HttpContext context, Guid id)
    {
        return context.Response.WriteAsJsonAsync(nameof(GetChatSession));
    }

    private static Task CreateChatSession(HttpContext context)
    {
        return context.Response.WriteAsJsonAsync(nameof(CreateChatSession));
    }

    private static Task UpdateChatSession(HttpContext context, Guid id)
    {
        return context.Response.WriteAsJsonAsync(nameof(UpdateChatSession));
    }

    private static Task DeleteChatSession(HttpContext context, Guid id)
    {
        return context.Response.WriteAsJsonAsync(nameof(DeleteChatSession));
    }
}