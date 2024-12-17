
using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;


namespace hackaton_microsoft_agro.Services
{

    public class OpenAIService(string endpoint, string apiKey, string deploymentName)
    {
        AzureOpenAIClient client = new AzureOpenAIClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

        public string ProcessResponse(string query, string sources)
        {
            string GROUNDED_PROMPT = $"""
                                    You are a friendly assistant who assists agricultural professionals with planting and pest control in soybeans.
                                    Answer the query using only the sources provided below in a friendly and concise bulleted manner.
                                    Answer ONLY with the facts listed in the list of sources below.
                                    If there isn't enough information below, say you don't know.
                                    Do not generate answers that don't use the sources below.
                                    Query: {query}
                                    Sources:\n{sources}
                                    """;
            try
            {
                var response = client.GetChatClient(deploymentName).CompleteChat(ChatMessage.CreateUserMessage(GROUNDED_PROMPT));
                return response.Value.Content[0].Text;
            }
            catch (Exception ex)
            {
                throw new Exception("Error ProcessResponse -> " + ex.Message);
            }
        }

    }
}