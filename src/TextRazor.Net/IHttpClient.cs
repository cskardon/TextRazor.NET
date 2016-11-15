namespace TextRazor.Net
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IHttpClient : IDisposable
    {
        Task<HttpResponseMessage> Send(HttpRequestMessage message);
        Task<HttpResponseMessage> Send(FormUrlEncodedContent content);
    }
}