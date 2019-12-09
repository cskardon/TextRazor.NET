namespace TextRazor.Net.Models
{
    using Newtonsoft.Json;

    public class EntailedTree
    {
        [JsonProperty("word")]
        public string Word { get; set; }
    }
}