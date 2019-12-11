namespace TextRazor.Net.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Response
    {
        /// <summary>
        ///     The ISO-639-2 language used to analyze this document, either explicitly provided as the
        ///     <see cref="AnalysisRequest.LanguageOverride" />, or as detected by the language detector.
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        ///     Boolean indicating whether the language detector was confident of its classification. This may be <c>false</c> for
        ///     shorter or ambiguous content.
        /// </summary>
        [JsonProperty("languageIsReliable")]
        public bool LanguageIsReliable { get; set; }

        /// <summary>
        ///     List of all the <see cref="Entity" /> across all sentences in the response.
        /// </summary>
        [JsonProperty("entities")]
        public IEnumerable<Entity> Entities { get; set; }

        /// <summary>
        ///     List of all <see cref="Entailment" /> across all sentences in the response.
        /// </summary>
        [JsonProperty("entailments")]
        public IEnumerable<Entailment> Entailments { get; set; }

        /// <summary>
        ///     List of all <see cref="Relation" /> across all sentences in the response.
        /// </summary>
        [JsonProperty("relations")]
        public IEnumerable<Relation> Relations { get; set; }

        /// <summary>
        /// List of all <see cref="Sentence"/> in the response.
        /// </summary>
        [JsonProperty("sentences")]
        public IEnumerable<Sentence> Sentences { get; set; }

        /// <summary>
        /// List of all the NounPhrase in the response.
        /// </summary>
        [JsonProperty("nounPhrases")]
        public IEnumerable<NounPhrase> NounPhrases { get; set; }

        /// <summary>
        /// List of all the coarse <see cref="Topic"/> in the response.
        /// </summary>
        [JsonProperty("coarseTopics")]
        public IEnumerable<Topic> CoarseTopics { get; set; }

        /// <summary>
        /// List of all the <see cref="Topic"/> in the response.
        /// </summary>
        [JsonProperty("topics")]
        public IEnumerable<Topic> Topics { get; set; }
    }
}