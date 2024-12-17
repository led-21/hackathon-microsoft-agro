using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;

namespace hackaton_microsoft_agro.Services
{

    public class AISearch(string endpoint, string apiKey)
    {
        SearchClient searchClient = new SearchClient(new Uri(endpoint), "vector-agro", new AzureKeyCredential(apiKey));

        public void Search(string searchText)
        {
            var searchResults = searchClient.Search<SearchDocument>(searchText);
            Console.WriteLine(searchResults);
        }
    }
}