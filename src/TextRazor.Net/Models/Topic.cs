namespace TextRazor.Net.Models
{
    using Newtonsoft.Json;

    public class Topic : TextRazorEntity
    {
        /// <summary>
        ///     Label for this topic.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        ///     Link to Wikipedia for this topic, or None if this topic couldn't be linked to a Wikipedia page.
        /// </summary>
        [JsonProperty("wikiLink")]
        public string WikiLink { get; set; }

        /// <summary>
        ///     The disambiguated Wikidata QID for this topic, or None if either this topic could not be disambiguated, or a
        ///     Wikidata link doesn’t exist.
        /// </summary>
        [JsonProperty("wikidataId")]
        public string WikidataId { get; set; }

        /// <summary>
        ///     The relevance of this topic to the processed document. This score ranges from 0 to 1, with 1 representing the
        ///     highest relevance of the topic to the processed document.
        /// </summary>
        [JsonProperty("score")]
        public double Score { get; set; }
    }
}