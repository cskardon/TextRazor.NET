namespace TextRazor.Net.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class NounPhrase : TextRazorEntity
    {
        /// <summary>
        /// List of the positions of the words in this phrase within their sentence.
        /// </summary>
        [JsonProperty("wordPositions")]
        public IEnumerable<int> WordPositions { get; set; }
    }
}