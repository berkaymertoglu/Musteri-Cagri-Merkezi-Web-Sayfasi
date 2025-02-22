using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using iwpProje.Services;

namespace iwpProje.Services
{
    public class NewsService
    {
        private readonly HttpClient _httpClient;

        public NewsService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<List<News>> GetLatestNewsAsync(int count)
        {
            // var response = await _httpClient.GetStringAsync("https://newsapi.org/v2/everything?q=apple&from=2024-12-14&to=2024-12-14&sortBy=popularity&apiKey=7cc388008b6f4cf6b3a316c6c8dd0bb9");

            // JSON verisini deserialize et
            var newsResponse = JsonConvert.DeserializeObject<NewsApiResponse>(response);
            return newsResponse.Articles; 
        }
    }

    // API'den gelen JSON yapısını model olarak tanımlayın
    public class NewsApiResponse
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<News> Articles { get; set; }
    }

    public class News
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public string SourceName { get; set; }
    }
}

