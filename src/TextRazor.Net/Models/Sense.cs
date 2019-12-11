namespace TextRazor.Net.Models
{
    using Newtonsoft.Json;

    public class Sense
    {
        [JsonProperty("synset")]
        public string Synset { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }
    }
}