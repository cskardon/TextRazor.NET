namespace TextRazor.Net.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a grammatical relation between words. Typically owns a number of <see cref="RelationParam" />,
    ///     representing the SUBJECT and OBJECT of the relation.
    /// </summary>
    /// <remarks>Request the "relations" extractor for this object.<br /></remarks>
    public class Relation : TextRazorEntity
    {
        /// <summary>
        ///     List of the TextRazor <see cref="RelationParam" /> of this relation.
        /// </summary>
        [JsonProperty("params")]
        public IEnumerable<RelationParam> Params { get; set; }

        /// <summary>
        ///     List of the positions of the predicate words in this relation within their sentence.
        /// </summary>
        [JsonProperty("wordPositions")]
        public IEnumerable<int> WordPositions { get; set; }
    }
}