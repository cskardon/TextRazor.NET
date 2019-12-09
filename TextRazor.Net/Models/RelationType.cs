namespace TextRazor.Net.Models
{
    using Newtonsoft.Json;

    public enum RelationType
    {
        [JsonProperty("SUBJECT")]
        Subject,
        [JsonProperty("OBJECT")]
        Object,
        [JsonProperty("OTHER")]
        Other
    }
}