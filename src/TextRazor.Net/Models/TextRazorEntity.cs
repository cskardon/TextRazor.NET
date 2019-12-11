namespace TextRazor.Net.Models
{
    using Newtonsoft.Json;

    public abstract class TextRazorEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}