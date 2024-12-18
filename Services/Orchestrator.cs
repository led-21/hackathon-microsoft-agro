﻿using Azure;
using Azure.Search.Documents.Models;
using hackaton_microsoft_agro.Interface;
using static System.Net.Mime.MediaTypeNames;

namespace hackaton_microsoft_agro.Services
{
    public class Orchestrator(ContentSafety contentSafety,
                              CustomVision customVision,
                              AISearch aISearch,
                              OpenAIService openAI) : IOrchestrator
    {

        const string OBSERVATION = """"
            The recommendation can only be made by a qualified professional. An agronomic prescription must be issued. The information is researched and the response generated by generative AI and it is necessary to verify at the source whether the information is accurate.
            """";
        public Dictionary<string, string> ProcessImageRequest(byte[] image)
        {
            if (contentSafety.ContentAnalyze(image, null))
                throw new ArgumentException("Text or image contains inappropriate content.");

            (string? pest, double confidence) = (null, 0);

            if (image != null)
                (pest, confidence) = customVision.AnalyseImage(image);


            var pestResult = confidence >= 0.75 ? pest : "Unidentified";

            string query = "Suggest control for " + pestResult;

            List<string> searchResults = aISearch.Search(query, 5);

            var response = openAI.ProcessResponse(query, string.Join(" ", searchResults));

            return new Dictionary<string, string>()
            {
                ["pestClassification:"] = pestResult,
                ["result"] = response,
                ["observation"] = OBSERVATION
            };
        }

        public Dictionary<string, string> ProcessPestControlSuggestionRequest(string pest)
        {
            if (contentSafety.ContentAnalyze(null, pest))
                throw new ArgumentException("Text or image contains inappropriate content.");

            string query = "Suggest control for " + pest;

            List<string> searchResults = aISearch.Search(query, 5);

            var response = openAI.ProcessResponse(pest, string.Join(" ", searchResults));

            return new Dictionary<string, string>()
            {
                ["result"] = response,
                ["observation"] = OBSERVATION
            };
        }

        public Dictionary<string, string> ProcessQuestionRequest(string text)
        {
            if (contentSafety.ContentAnalyze(null, text))
                throw new ArgumentException("Text or image contains inappropriate content.");

            (string? pest, double confidence) = (null, 0);

            List<string> searchResults = aISearch.Search(text, 5);

            var response = openAI.ProcessResponse(text, string.Join(" ", searchResults));

            return new Dictionary<string, string>() { 
                ["result"] = response,
                ["observation"] = OBSERVATION
            };
        }

        public Dictionary<string, string> ProcessPlanCropFieldRequest(string city)
        {
            if (contentSafety.ContentAnalyze(null, city))
                throw new ArgumentException("Text or image contains inappropriate content.");

            string query = $"Plantio da soja para cidade {city}";

            List<string> searchResults = aISearch.Search(query, 5);

            var response = openAI.ProcessResponseForPlanCropField("Planeje "+query, city, string.Join(" ", searchResults));

            return new Dictionary<string, string>() { 
                ["result"] = response,
                ["observation"] = OBSERVATION
            };
        }
    }
}
