namespace TextRazor.Net.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Entity : TextRazorEntity
    {

        [JsonProperty("type")]
        public IEnumerable<string> Type { get; set; }

        [JsonProperty("matchingTokens")]
        public IEnumerable<int> MatchingTokens { get; set; }

        [JsonProperty("entityId")]
        public string EntityId { get; set; }

        [JsonProperty("freebaseTypes")]
        public IEnumerable<string> FreebaseTypes { get; set; }

        [JsonProperty("confidenceScore")]
        public double ConfidenceScore { get; set; }

        /// <summary>
        ///     Link to Wikipedia for this topic, or None if this topic couldn't be linked to a Wikipedia page.
        /// </summary>
        [JsonProperty("wikiLink")]
        public string WikiLink { get; set; }

        [JsonProperty("matchedText")]
        public string MatchedText { get; set; }

        [JsonProperty("freebaseId")]
        public string FreebaseId { get; set; }

        [JsonProperty("relevanceScore")]
        public double RelevanceScore { get; set; }

        [JsonProperty("entityEnglishId")]
        public string EntityEnglishId { get; set; }

        [JsonProperty("startingPos")]
        public int StartingPos { get; set; }

        [JsonProperty("endingPos")]
        public int EndingPos { get; set; }

        /// <summary>
        ///     The disambiguated Wikidata QID for this topic, or None if either this topic could not be disambiguated, or a
        ///     Wikidata link doesn’t exist.
        /// </summary>
        [JsonProperty("wikidataId")]
        public string WikidataId { get; set; }
    }
}