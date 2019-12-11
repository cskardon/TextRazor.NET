namespace TextRazor.Net.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a Param to a specific Relation.
    /// </summary>
    /// <remarks>Request the "relations" extractor for this object.</remarks>
    public class RelationParam
    {
        /// <summary>
        ///     List of the positions of the words in this param within their sentence.
        /// </summary>
        [JsonProperty("wordPositions")]
        public IEnumerable<int> WordPositions { get; set; }

        /// <summary>
        ///     Relation of this param to the predicate. Valid Options: SUBJECT, OBJECT, OTHER
        /// </summary>
        [JsonProperty("relation")]
        public RelationType Relation { get; set; }
    }
}