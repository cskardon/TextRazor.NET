namespace TextRazor.Net.Models
{
    using Newtonsoft.Json;

    public class ScoredCategory
    {
        /// <summary>
        ///     The unique ID for this category within its classifier.
        /// </summary>
        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }

        /// <summary>
        ///     The human readable label for this category.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        ///     The score TextRazor has assigned to this category, between 0 and 1<br />
        ///     To avoid false positives you might want to ignore categories below a certain score - a good starting point would be
        ///     0.5. The best way to find an appropriate threshold is to run a sample set of your documents through the system and
        ///     manually inspect the results.
        /// </summary>
        [JsonProperty("score")]
        public double Score { get; set; }

        /// <summary>
        ///     The unique identifier for the classifier that matched this category.
        /// </summary>
        [JsonProperty("classifierId")]
        public string ClassifierId { get; set; }
    }
}