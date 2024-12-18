using hackaton_microsoft_agro.Data;
using hackaton_microsoft_agro.Interface;
using hackaton_microsoft_agro.Services;
using Microsoft.AspNetCore.Builder;
using System;
using System.Runtime.CompilerServices;

namespace hackaton_microsoft_agro.Endpoints
{
    public static class Endpoints
    {
        public static void AddMyEndpoints(this WebApplication app)
        {
            app.MapGet("/health", () => new Dictionary<string, string> { ["status"] = "up" }).WithName("HealthCheck");

            app.MapPost("/classify_pest", async (string url, HttpClient client, IOrchestrator orchestrator) =>
            {

                if (string.IsNullOrEmpty(url))
                    return Results.BadRequest("The 'url' parameter is required.");

                try
                {
                    byte[] imageContent = await client.GetByteArrayAsync(url);
                    var result = orchestrator.ProcessImageRequest(imageContent);

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


            app.MapPost("/control_insect_suggestion", async (string pest, IOrchestrator orchestrator) =>
            {

                if (string.IsNullOrEmpty(pest))
                    return Results.BadRequest("The 'pest' parameter is required.");

                try
                {
                    var result = orchestrator.ProcessPestControlSuggestionRequest(pest);

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
            .WithName("ControlInsectSuggestion");


            app.MapPost("/question", async (string question, HttpClient client, IOrchestrator orchestrator) =>
            {

                if (string.IsNullOrEmpty(question))
                    return Results.BadRequest("The 'question' parameter is required.");

                try
                {
                    var result = orchestrator.ProcessQuestionRequest(question);
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
            .WithName("QuestionAboutCrops");


            app.MapPost("/plan_crop_field", async (string city, HttpClient client, IOrchestrator orchestrator) =>
            {

                if (string.IsNullOrEmpty(city))
                    return Results.BadRequest("The 'crop' parameter is required.");

                try
                {
                    var result = orchestrator.ProcessPlanCropFieldRequest(city);
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
            .WithName("PlanCropField");


            app.MapGet("/get_registered_products", (CropProtectionContext database, string pest) =>
            {
                return database.Products
                         .Where(x => x.PestCommonName.Contains(pest))
                         .Select(c => new CropProtectionDto
                         (
                             c.Id,
                             c.RegistrationNumber,
                             c.CommercialBrand,
                             c.Class,
                             c.Crop,
                             c.PestScientificName,
                             c.PestCommonName.Replace('?', 'a')
                         ))
                         .Take(20);
            })
            .WithName("GetRegisteredProducts");
        }

    }

    record CropProtectionDto(int Id, string RegistrationNumber, string CommercialBrand, string Class, string Crop, string PestScientificName, string PestCommonName);
}