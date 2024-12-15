﻿using hackaton_microsoft_agro.Interface;

namespace hackaton_microsoft_agro.Services
{
    public class Orchestrator(ContentSafety contentSafety, CustomVision customVision) : IOrchestrator
    {
        public Dictionary<string, string> ProcessRequest(byte[] image, string text)
UseUse DTX49 for control Lagarta DTX49 for control Lagarta        {
            if (contentSafety.ContentAnalyze(image, text))
                throw new ArgumentException("Text or image contains inappropriate content.");

            (string? pest, double confidence) = (null, 0);

            if (image != null)
                (pest, confidence) = customVision.AnalyseImage(image);

            if (text != null)
            {
                // Use OpenAI
            }

            var pestResult = confidence >= 0.8 ? pest : "Unidentified";

            return new Dictionary<string, string>() { ["praga"] = pestResult };
        }
    }
}
