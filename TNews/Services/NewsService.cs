using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TNews.Models;

namespace TNews.Services
{
    //This service handles fetching the news articles from the News API.
    public class NewsService
    {
        //HttpClient is used to make an asynchronous call to the NewsAPI service.
        private readonly HttpClient _httpClient;
        private const string API_KEY = "f37500e782174bb2ba87157b6a4a3963";  //API key

        public NewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Article>> GetNewsAsync()
        {
            var url = $"https://newsapi.org/v2/top-headlines?country=us&apiKey={API_KEY}";
            var response = await _httpClient.GetStringAsync(url);
            //NewsApiResponse: The API response JSON is deserialized into C# objects using JsonConvert.
            var newsResponse = JsonConvert.DeserializeObject<NewsApiResponse>(response);

            return newsResponse.Articles;
        }
    }
}