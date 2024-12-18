namespace hackaton_microsoft_agro.Interface
{
    public interface IOrchestrator
    {
        public Dictionary<string, string> ProcessImageRequest(byte[] image);
        public Dictionary<string, string> ProcessQuestionRequest(string text);
        public Dictionary<string, string> ProcessPestControlSuggestionRequest(string pest);
        public Dictionary<string, string> ProcessPlanCropFieldRequest(string city);
    }
}
