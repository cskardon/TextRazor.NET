namespace TextRazor.Net.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Sentence
    {
        [JsonProperty("position")]
        public int Position { get; set; }

        /// <summary>
        /// List of all the <see cref="Word"/> in this sentence.
        /// </summary>
        [JsonProperty("words")]
        public IEnumerable<Word> Words { get; set; }
    }
}