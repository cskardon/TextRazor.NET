namespace TextRazor.Net
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using TextRazor.Net.Models;

    public class TextRazorClient : IDisposable
    {
        private readonly IHttpClient _httpClient; 
        public TextRazorClient(Uri textRazorUri, string apiKey) : this(new HttpClientWrapper(textRazorUri, apiKey))
        {}

        public TextRazorClient(IHttpClient client)
        {
            _httpClient = client;
        }

        public TextRazorClient(string textRazorUri, string apiKey)
            : this(new Uri(textRazorUri), apiKey)
        {}

        public async Task<ApiResponse> Analyze(string words, ExtratorsType extrators,string rules = null)
        {
            if ((extrators == ExtratorsType.DependencyTrees && extrators != ExtratorsType.Words) ||
                (extrators == ExtratorsType.Senses && extrators != ExtratorsType.Words))
                throw new ArgumentException($"To use the Dependency Trees or Senses extractors, you need to also supply the 'Words' extractor");

            var request = new AnalysisRequest
            {
                Text = words,
                Extractors = extrators,
                Rules = rules
            };

            //if there are some custom prolog rules, add them here
            if (rules != null)
            {
                request.Rules = rules;
            }

            var response = await _httpClient.Send(request.ToFormUrlEncodedContent());

            return JsonConvert.DeserializeObject<ApiResponse>(await response.Content.ReadAsStringAsync());
        }

        

        protected virtual void Dispose(bool isDisposing)
        {
            if (!isDisposing) return;

            _httpClient?.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}