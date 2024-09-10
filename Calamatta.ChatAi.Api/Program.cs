LogInitialization.Initialize();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddLogging();

var app = builder.Build();
app.UseSerilogRequestLogging(); 

//if (app.Environment.IsDevelopment()) //for testing purposes
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Map the endpoints
SessionEndpoints.Map(app);

//This method must be called last
app.Run();