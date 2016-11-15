namespace TextRazor.Net.Tests.Helpers
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Moq;

    public static class MockHelper
    {
        public enum JsonToLoad
        {
            DependencyTrees,
            Entailments,
            Entities,
            Phrases,
            Relations,
            Senses,
            Topics,
            Words
        }

        public static HttpResponseMessage GetHttpResponseMessage(string filename)
        {
            var content = File.ReadAllText(filename);
            var response = new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent(content)};

            return response;
        }

        public static Mock<IHttpClient> GetMockHttpClient(JsonToLoad jsonToLoad)
        {
            const string folderName = "ExampleResponses\\";
            const string extension = ".json";
            switch (jsonToLoad)
            {
                case JsonToLoad.DependencyTrees:
                case JsonToLoad.Entailments:
                case JsonToLoad.Entities:
                case JsonToLoad.Phrases:
                case JsonToLoad.Relations:
                case JsonToLoad.Senses:
                case JsonToLoad.Topics:
                case JsonToLoad.Words:
                    return GetMockHttpClient($"{folderName}{jsonToLoad}{extension}");
                default:
                    throw new ArgumentOutOfRangeException(nameof(jsonToLoad), jsonToLoad, null);
            }
        }

        public static Mock<IHttpClient> GetMockHttpClient(string filename)
        {
            Mock<IHttpClient> mockClient = new Mock<IHttpClient>();
            mockClient
                .Setup(c => c.Send(It.IsAny<FormUrlEncodedContent>()))
                .Returns(Task.FromResult(GetHttpResponseMessage(filename)));

            return mockClient;
        }
    }
}