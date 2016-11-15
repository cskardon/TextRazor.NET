namespace TextRazor.Net.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Entailment : TextRazorEntity
    {
        [JsonProperty("wordPositions")]
        public IEnumerable<int> WordPositions { get; set; }

        [JsonProperty("entailedWords")]
        public IEnumerable<string> EntailedWords { get; set; }

        [JsonProperty("entailedTree")]
        public EntailedTree EntailedTree { get; set; }

        [JsonProperty("priorScore")]
        public double PriorScore { get; set; }

        [JsonProperty("contextScore")]
        public double ContextScore { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }
    }
}