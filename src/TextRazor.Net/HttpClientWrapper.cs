namespace TextRazor.Net
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    internal sealed class HttpClientWrapper : IHttpClient
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private string ApiKey { get; }
        private Uri Uri { get; }
        internal HttpClientWrapper(Uri uri, string apiKey)
        {
            if(string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("ApiKey cannot be null, empty or whitespace.", nameof(apiKey));

            if(uri == null)
                throw new ArgumentNullException(nameof(uri), "Uri needs to be supplied.");

            ApiKey = apiKey;
            Uri = uri;
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        public Task<HttpResponseMessage> Send(HttpRequestMessage message)
        {
            message.Headers.Add("X-TextRazor-Key", ApiKey);

            return _httpClient.SendAsync(message);
        }

        public Task<HttpResponseMessage> Send(FormUrlEncodedContent content)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Uri) {Content = content};
            return Send(request);
        }
    }
}