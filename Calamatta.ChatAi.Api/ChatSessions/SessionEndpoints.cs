namespace Calamatta.ChatAi.Api.ChatSessions;

public static class SessionEndpoints
{
    public static void Map(WebApplication app)
    {
        var group = app.MapGroup("/chat");
        group.MapGet("/", GetAllChatSessions);
        group.MapGet("/{id:guid}", GetChatSession);
        group.MapPost("/", CreateChatSession);
        group.MapPut("/{id:guid}", UpdateChatSession);
        group.MapDelete("/{id:guid}", DeleteChatSession);
        group.WithOpenApi();
    }

    private static Task GetAllChatSessions(HttpContext context)
    {
        return context.Response.WriteAsJsonAsync(nameof(GetAllChatSessions));
    }

    private static Task GetChatSession(HttpContext context, Guid id)
    {
        return context.Response.WriteAsJsonAsync(nameof(GetChatSession));
    }

    private static IResult CreateChatSession(IMediator mediator)
    {
        return Results.Ok(mediator.Send(new CreateChatCommand()));
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