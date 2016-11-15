namespace TextRazor.Net.Models
{
    using System;
    using Newtonsoft.Json;

    [Flags]
    public enum ExtratorsType : byte
    {
        None = 0,
        [JsonProperty("entities")]
        Entities = 1 << 0,
        [JsonProperty("topics")]
        Topics = 1 << 1,
        [JsonProperty("words")]
        Words = 1 << 2,
        [JsonProperty("phrases")]
        Phrases = 1 << 3,
        [JsonProperty("dependency-trees")]
        DependencyTrees = 1 << 4,
        [JsonProperty("relations")]
        Relations = 1 << 5,
        [JsonProperty("entailments")]
        Entailments = 1 << 6,
        [JsonProperty("senses")]
        Senses = 1 << 7
    }
}