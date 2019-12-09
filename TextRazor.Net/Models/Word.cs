namespace TextRazor.Net.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Word
    {
        /// <summary>
        /// Position of this word in its sentence.
        /// </summary>
        [JsonProperty("position")]
        public int Position { get; set; }

        /// <summary>
        /// Position of the grammatical parent of this word, or None if this word is either at the root of the sentence or the “dependency-trees” extractor was not requested.
        /// </summary>
        [JsonProperty("parentPosition")]
        public int ParentPosition { get; set; }

        /// <summary>
        /// Start offset in the input text for this token. Note that this offset applies to the original Unicode string passed in to the api, TextRazor treats multi byte UTF8 charaters as a single position.
        /// </summary>
        [JsonProperty("startingPos")]
        public int StartingPos { get; set; }

        /// <summary>
        /// End offset in the input text for this token. Note that this offset applies to the original Unicode string passed in to the api, TextRazor treats multi byte UTF8 charaters as a single position.
        /// </summary>
        [JsonProperty("endingPos")]
        public int EndingPos { get; set; }

        /// <summary>
        /// Stem of this word.
        /// </summary>
        [JsonProperty("stem")]
        public string Stem { get; set; }

        /// <summary>
        /// Morphological root of this word, see http://en.wikipedia.org/wiki/Lemma_(morphology) for details.
        /// </summary>
        [JsonProperty("lemma")]
        public string Lemma { get; set; }

        /// <summary>
        /// Raw token string that matched this word in the source text.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// Part of Speech that applies to this word. We use the Penn treebank tagset, as detailed here: http://www.comp.leeds.ac.uk/ccalas/tagsets/upenn.html
        /// </summary>
        [JsonProperty("partOfSpeech")]
        public string PartOfSpeech { get; set; }

        /// <summary>
        /// List of (synset, score) tuples representing scores of each Wordnet sense this this word may be a part of.
        /// </summary>
        [JsonProperty("senses")]
        public IEnumerable<Sense> Senses { get; set; }

        /// <summary>
        /// Grammatical relation between this word and it’s parent, or None if this word is either at the root of the sentence or the “dependency-trees” extractor was not requested. TextRazor parses into the Stanford uncollapsed dependencies, as detailed at: http://nlp.stanford.edu/software/dependencies_manual.pdf
        /// </summary>
        [JsonProperty("relationToParent")]
        public string RelationToParent { get; set; }
    }
}