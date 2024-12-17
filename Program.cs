using Azure.Identity;
using hackaton_microsoft_agro.Interface;
using hackaton_microsoft_agro.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionando a URL do Key Vault ao arquivo de configuração
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// URL do Key Vault armazenada no appsettings.json
var keyVaultUri = builder.Configuration["KeyVaultUri"];

// Obter as credenciais do Service Principal armazenadas no appsettings.json
var clientId = builder.Configuration["AzureAd:ClientId"];
var clientSecret = builder.Configuration["AzureAd:ClientSecret"];
var tenantId = builder.Configuration["AzureAd:TenantId"];

// Configurando o Azure Key Vault usando o ClientSecretCredential
var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
var uri = string.IsNullOrEmpty(keyVaultUri)
    ? throw new InvalidOperationException("KeyVault URI is not configured.")
    : new Uri(keyVaultUri);
builder.Configuration.AddAzureKeyVault(uri, credential);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add HTTP Client Service
builder.Services.AddHttpClient();

// Add Orchestrator Service
builder.Services.AddSingleton<IOrchestrator, Orchestrator>(o => new Orchestrator(
    new ContentSafety(
        builder.Configuration["content-safety-endpoint"]!,
        builder.Configuration["content-safety-key"]!),

    new CustomVision(
        builder.Configuration["custom-vision-endpoint"]!,
        builder.Configuration["custom-vison-prediction-key"]!,
        new Guid(builder.Configuration["custom-vision-project-id"]!),
        builder.Configuration["custom-vision-iteration-name"]!),

    new AISearch(
        builder.Configuration["ai-search-endpoint"]!,
        builder.Configuration["ai-search-key"]!)
    )
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

app.MapPost("/classify_image", async (string url, string description, HttpClient client, IOrchestrator orchestrator) =>
{

    if (string.IsNullOrEmpty(url))
        return Results.BadRequest("The 'url' parameter is required.");

    try
    {
        byte[] imageContent = await client.GetByteArrayAsync(url);
        var result = orchestrator.ProcessRequest(imageContent, description);

        return Results.Ok(result);
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

