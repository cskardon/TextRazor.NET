namespace TextRazor.Net.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.Extensions.Configuration;
    using Moq;
    using TextRazor.Net.Models;
    using TextRazor.Net.Tests.Helpers;
    using Xunit;

    public class TextRazorClientTests
    {
        /*
         * To run these tests, you must add test.config.json to your project
         * with the Endpoint and ApiKeys defined, and make sure it's set to copy on build
         */
        private readonly IConfigurationRoot _config;
        public TextRazorClientTests()
        {
            _config = new ConfigurationBuilder()
           .SetBasePath(AppContext.BaseDirectory)
           .AddJsonFile("tests.config.json", false)
           .Build();

        }

            [Fact]
            public async Task ParsesEntitiesCorrectly()
            {
                var trc = new TextRazorClient(this._config["Endpoint"],_config["ApiKey"]);
                var response = await trc.Analyze("Anything", ExtratorsType.Entities);
                response.Response.Entities.Count().Should().BeGreaterThan(0);
            }

            [Fact]
            public async Task ParsesEntailmentsCorrectly()
            {
                var mockClient = MockHelper.GetMockHttpClient(MockHelper.JsonToLoad.Entailments);

                var trc = new TextRazorClient(_config["Endpoint"],_config["ApiKey"]);;
                var response = await trc.Analyze("Anything", ExtratorsType.Entailments);
                response.Response.Entailments.Count().Should().BeGreaterThan(0);
            }

            [Fact]
            public async Task ParsesDependencyTreesCorrectly()
            {
                var mockClient = MockHelper.GetMockHttpClient(MockHelper.JsonToLoad.DependencyTrees);

                var trc = new TextRazorClient(_config["Endpoint"],_config["ApiKey"]);;
                var response = await trc.Analyze("Anything", ExtratorsType.DependencyTrees | ExtratorsType.Words);
                response.Response.Sentences.Count().Should().BeGreaterThan(0);
            }

            [Fact]
            public async Task ParsesWordsCorrectly()
            {
                var mockClient = MockHelper.GetMockHttpClient(MockHelper.JsonToLoad.Words);

                var trc = new TextRazorClient(_config["Endpoint"],_config["ApiKey"]);;
                var response = await trc.Analyze("Anything", ExtratorsType.Words);
                response.Response.Sentences.Count().Should().BeGreaterThan(0);
            }

            [Fact]
            public async Task ParsesSensesCorrectly()
            {
                var mockClient = MockHelper.GetMockHttpClient(MockHelper.JsonToLoad.Senses);

                var trc = new TextRazorClient(_config["Endpoint"],_config["ApiKey"]);;
                var response = await trc.Analyze("Anything", ExtratorsType.Senses | ExtratorsType.Words);
                response.Response.Sentences.Count().Should().BeGreaterThan(0);
            }

            [Fact]
            public async Task ParsesTopicsCorrectly()
            {
                var mockClient = MockHelper.GetMockHttpClient(MockHelper.JsonToLoad.Topics);

                var trc = new TextRazorClient(_config["Endpoint"],_config["ApiKey"]);;
                var response = await trc.Analyze("Anything", ExtratorsType.Topics);
                response.Response.CoarseTopics.Count().Should().BeGreaterThan(0);
                response.Response.Topics.Count().Should().BeGreaterThan(0);
            }

            [Fact]
            public async Task ParsesPhrasesCorrectly()
            {
                var mockClient = MockHelper.GetMockHttpClient(MockHelper.JsonToLoad.Phrases);

                var trc = new TextRazorClient(_config["Endpoint"],_config["ApiKey"]);;
                var response = await trc.Analyze("Anything", ExtratorsType.Phrases);
                response.Response.NounPhrases.Count().Should().BeGreaterThan(0);
            }

            [Fact]
            public async Task ParsesRelationsCorrectly()
            {
                var mockClient = MockHelper.GetMockHttpClient(MockHelper.JsonToLoad.Relations);

                var trc = new TextRazorClient(_config["Endpoint"],_config["ApiKey"]);
            var response = await trc.Analyze("Anything", ExtratorsType.Relations);
                response.Response.Relations.Count().Should().BeGreaterThan(0);
            }

            [Fact]
            public async Task ThrowsArgumentException_WhenDependencyTrees_ButNoWords()
            { 
                var trc = new TextRazorClient(_config["Endpoint"], _config["ApiKey"]);
            await Assert.ThrowsAsync<ArgumentException>( () => trc.Analyze("Anything", ExtratorsType.DependencyTrees));
            }

            [Fact]
            public async Task ThrowsArgumentException_WhenSenses_ButNoWords()
            {
                var trc = new TextRazorClient(_config["Endpoint"], _config["ApiKey"]);
            await Assert.ThrowsAsync<ArgumentException>(() => trc.Analyze("Anything", ExtratorsType.Senses));
            }

  
        protected static IHttpClient EmptyHttpClient => new Mock<IHttpClient>().Object;
    }
}