using Polly;

namespace Rest_Advanced.Services
{
    public class ResilienceService
    {
        private readonly HttpClient _httpClient;

        public ResilienceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAsync(string url)
        {
            var retryPolicy = Policy.Handle<HttpRequestException>().RetryAsync(3);
            var circuitBreakerPolicy = Policy.Handle<HttpRequestException>().CircuitBreakerAsync(2, TimeSpan.FromMinutes(1));

            return await retryPolicy.ExecuteAsync(async () =>
            {
                return await circuitBreakerPolicy.ExecuteAsync(async () =>
                {
                    var response = await _httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                });
            });
        }
    }
}
