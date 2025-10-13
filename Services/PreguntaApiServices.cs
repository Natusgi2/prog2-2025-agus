using System.Text.Json;
using Bibliote.Interface;

namespace Bibliote.Services
{
    public class PreguntaApiService : IPreguntaService
    {
        private HttpClient _httpClient;

        public PreguntaApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Pregunta>> GetPreguntasAsync()
        {
            var response = await _httpClient.GetStringAsync("https://opentdb.com/api.php?amount=10&category=18&type=boolean");
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse>(response);
            return apiResponse.results;
        }
    }

    public class ApiResponse
    {
        public int response_code { get; set; }
        public List<Pregunta> results { get; set; }
    }
}