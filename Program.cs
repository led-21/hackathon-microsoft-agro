using hackaton_microsoft_agro.Interface;
using hackaton_microsoft_agro.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add HTTP Client Service
builder.Services.AddHttpClient();

// Add Orchestrator Service
builder.Services.AddSingleton<IOrchestrator, Orchestrator>(o => new Orchestrator(
    new ContentSafety(builder.Configuration["content_moderator:endpoint"]!,
        builder.Configuration["content_moderator"]!),

    new CustomVision(
        builder.Configuration["custom_vision:endpoint"]!,
        builder.Configuration["custom_vision:iteration_name"]!,
        new Guid(builder.Configuration["custom_vision:project_id"]!),
        builder.Configuration["custom_vision:iteration_name"]!))
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/health", () => new Dictionary<string, string> { ["status"] = "up" })
    .WithName("HealthCheck");

app.MapPost("/classify_image", async (string url, string description, HttpClient client) =>
{

if (string.IsNullOrEmpty(url))
    return Results.BadRequest("The 'url' parameter is required.");

    try
    {
        byte[] imageContent = await client.GetByteArrayAsync(url);
     //   var result = orchestrator.ProcessRequest(imageContent, description);

        return Results.Ok(url+" | "+description);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
    catch (Exception e)
    {
        return Results.InternalServerError(e.Message);
    }
})
.WithName("ClassifyImage");

app.Run();

