namespace TextRazor.Net
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using TextRazor.Net.Extensions;
    using TextRazor.Net.Models;

    public class AnalysisRequest
    {
        public AnalysisRequest()
        {
            Cleanup = new CleanupRequest();
            Entities = new EntitiesRequest();
            Download = new DownloadRequest();
        }

        /// <summary>
        ///     Up to 200kb of UTF-8 encoded raw text to be analyzed. Either "text" or "url" must be part of your request.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Sets a list of “Extractors”, which tells TextRazor which analysis functions to perform on your text.For optimal
        ///     performance, only select the extractors that are explicitly required by your application.
        ///     Valid Options: <c>entities, topics, words, phrases, dependency-trees, relations, entailments, senses</c>
        /// </summary>
        public ExtratorsType Extractors { get; set; }

        /// <summary>
        ///     BETA: The publicly accessible URL to fetch content from. Either "text" or "url" must be part of your request.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        ///     String containing Prolog logic. All rules matching an extractor name listed in the request will be evaluated and
        ///     all matching param combinations linked in the response.
        /// </summary>
        public string Rules { get; set; }

        public CleanupRequest Cleanup { get; }
        public DownloadRequest Download { get; }

        /// <summary>
        ///     When set to a ISO-639-2 language code, force TextRazor to analyze content with this language. If not set TextRazor
        ///     will use the automatically identified language.
        /// </summary>
        public string LanguageOverride { get; set; }

        public EntitiesRequest Entities { get; }

        /// <summary>
        ///     Sets a list of classifiers to evaluate against your document. Each entry should be a string ID corresponding to
        ///     either one of TextRazor's default classifiers, or one you have previously configured through the ClassifierManager
        ///     interface.
        /// </summary>
        /// <remarks>
        ///     Valid Options:<br />
        ///     <list type="bullet">
        ///         <item>
        ///             <c>textrazor_iab</c> Score against the Internet Advertising Bureau QAG segments - approximately 400 high
        ///             level categories arranged into two tiers.
        ///         </item>
        ///         <item>
        ///             <c>textrazor_newscodes</c> Score against the IPTC newscodes - approximately 1400 high level categories
        ///             organized into a three level tree.
        ///         </item>
        ///         <item>
        ///             <c>custom classifier name</c> Score against a custom classifier, previously created through the
        ///             Classifier Manager interface.
        ///         </item>
        ///     </list>
        /// </remarks>
        public string Classifiers { get; set; }

        internal IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var output = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(Text)) output.Add("text", Text);
            if (!string.IsNullOrWhiteSpace(Url)) output.Add("url", Url);
            output.Add("extractors", Extractors.ToString().Replace(" ", "").ToLowerInvariant());
            if (!string.IsNullOrWhiteSpace(Rules)) output.Add("rules", Rules);
            if (!string.IsNullOrWhiteSpace(LanguageOverride)) output.Add("languageOverride", LanguageOverride);
            if (!string.IsNullOrWhiteSpace(Classifiers)) output.Add("classifiers", Classifiers);

            output.AddRange(Entities.ToKeyValuePairs());
            output.AddRange(Cleanup.ToKeyValuePairs());
            output.AddRange(Download.ToKeyValuePairs());

            return output;
        }

        /// <summary>Generates the <see cref="FormUrlEncodedContent" /> required to send to TextRazor.</summary>
        /// <returns>The <see cref="FormUrlEncodedContent" /> required to send to TextRazor</returns>
        /// <exception cref="InvalidOperationException">
        ///     Thrown if <see cref="Text" /> and <see cref="Url" /> properties are both
        ///     set.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     Thrown if neither <see cref="Text" /> or <see cref="Url" /> properties are
        ///     set.
        /// </exception>
        /// <exception cref="InvalidOperationException">Thrown if the <see cref="Extractors" /> property is not set.</exception>
        public FormUrlEncodedContent ToFormUrlEncodedContent()
        {
            if (!string.IsNullOrWhiteSpace(Text) && !string.IsNullOrWhiteSpace(Url))
                throw new InvalidOperationException($"You can only set '{nameof(Text)}' OR '{nameof(Url)}' parameters, not both.");

            if (string.IsNullOrWhiteSpace(Text) && string.IsNullOrWhiteSpace(Url))
                throw new InvalidOperationException($"You must set the '{nameof(Text)}' OR '{nameof(Url)}' parameters.");

            if (Extractors == ExtratorsType.None)
                throw new InvalidOperationException($"You must set the {nameof(Extractors)} property.");

            var keyValues = new List<KeyValuePair<string, string>>(ToKeyValuePairs());
            return new FormUrlEncodedContent(keyValues);
        }

        public class CleanupRequest
        {
            private const string Prefix = "cleanup";

            /// <summary>
            ///     Controls the preprocessing cleanup mode that TextRazor will apply to your content before analysis. For all options
            ///     aside from "raw" any position offsets returned will apply to the final cleaned text, not the raw HTML. If the
            ///     cleaned text is required please see the cleanup_return_cleaned option.
            /// </summary>
            /// <remarks>
            ///     Valid Options:<br />
            ///     <list type="bullet">
            ///         <item><c>raw</c>: Content is analyzed "as-is", with no preprocessing.</item>
            ///         <item>
            ///             <c>stripTags</c>: All Tags are removed from the document prior to analysis.This will remove all HTML, XML
            ///             tags, but the content of headings, menus will remain.This is a good option for analysis of HTML pages that
            ///             aren't long form documents.
            ///         </item>
            ///         <item>
            ///             <c>cleanHTML</c>: Boilerplate HTML is removed prior to analysis, including tags, comments, menus, leaving
            ///             only the body of the article.
            ///         </item>
            ///     </list>
            /// </remarks>
            public string Mode { get; set; }

            /// <summary>
            ///     When True, the TextRazor response will contain the cleaned_text property, the text it analyzed after preprocessing.
            ///     To save bandwidth, only set this to True if you need it in your application. Defaults to False.
            /// </summary>
            public bool? ReturnCleaned { get; set; }

            /// <summary>
            ///     When return_raw is True, the TextRazor response will contain the raw_text property, the original text TextRazor
            ///     received or downloaded before cleaning. To save bandwidth, only set this to True if you need it in your
            ///     application. Defaults to False.
            /// </summary>
            public bool? ReturnRaw { get; set; }

            /// <summary>
            ///     BETA: When use_metadata is True, TextRazor will use metadata extracted from your document to help in the
            ///     disambiguation/extraction process. This include HTML titles and metadata, and can significantly improve results for
            ///     shorter documents without much other content.
            ///     This option has no effect when cleanup_mode is 'raw'. Defaults to True
            /// </summary>
            public bool? UseMetadata { get; set; }


            internal IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
            {
                var output = new List<KeyValuePair<string, string>>();

                if (!string.IsNullOrWhiteSpace(Mode)) output.Add($"{Prefix}.mode", Mode);
                if (ReturnCleaned == true) output.Add($"{Prefix}.returnCleaned", ReturnCleaned.ToString());
                if (ReturnRaw == true) output.Add($"{Prefix}.returnRaw", ReturnRaw.ToString());
                if (UseMetadata == true) output.Add($"{Prefix}.useMetadata", UseMetadata.ToString());

                return output;
            }
        }

        public class DownloadRequest
        {
            private const string Prefix = "download";

            /// <summary>
            ///     BETA: Sets the User-Agent header to be used when downloading over HTTP. This should be a descriptive string
            ///     identifying your application, or an end user's browser user agent if you are performing live requests from a given
            ///     user
            ///     Defaults to <c>"TextRazor Downloader (https://www.textrazor.com)"</c>
            /// </summary>
            public string UserAgent { get; set; }

            internal IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
            {
                var output = new List<KeyValuePair<string, string>>();

                if (!string.IsNullOrWhiteSpace(UserAgent)) output.Add($"{Prefix}.userAgent", UserAgent);

                return output;
            }
        }

        public class EntitiesRequest
        {
            private const string Prefix = "entities";

            /// <summary>
            ///     BETA: Sets a list of the custom entity dictionaries to match against your content. Each item should be a string ID
            ///     corresponding to dictionaries you have previously configured through the DictionaryManager interface.
            /// </summary>
            public string Dictionaries { get; set; }

            /// <summary>
            ///     List of DBPedia types. All returned entities must match at least one of these types. For more information on
            ///     TextRazor's type filtering, see http://www.textrazor.com/types. To account for inconsistencies in DBPedia and
            ///     Freebase type information we recommend you filter on multiple types across both sources where possible.
            /// </summary>
            public string FilterDbpediaTypes { get; set; }

            /// <summary>
            ///     List of Freebase types. All returned entities must match at least one of these types. For more information on
            ///     TextRazor's type filtering, see http://www.textrazor.com/types. To account for inconsistencies in DBPedia and
            ///     Freebase type information we recommend you filter on multiple types across both sources where possible.
            /// </summary>
            public string FilterFreebaseTypes { get; set; }

            /// <summary>
            ///     When True entities in the response may overlap. When False, the "best" entity is found such that none overlap.
            ///     Defaults to True.
            /// </summary>
            public bool? AllowOverlap { get; set; }

            /// <summary>
            ///     Set a list of "Enrichment Queries", used to enrich the entity response with structured linked data. The syntax for
            ///     these queries is documented at https://www.textrazor.com/enrichment
            /// </summary>
            public string EnrichmentQueries { get; set; }

            internal IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
            {
                var output = new List<KeyValuePair<string, string>>();

                if (!string.IsNullOrWhiteSpace(Dictionaries)) output.Add($"{Prefix}.dictionaries", Dictionaries);
                if (!string.IsNullOrWhiteSpace(FilterDbpediaTypes)) output.Add($"{Prefix}.filterDbpediaTypes", Dictionaries);
                if (!string.IsNullOrWhiteSpace(FilterFreebaseTypes)) output.Add($"{Prefix}.filterFreebaseTypes", Dictionaries);
                if (AllowOverlap == true) output.Add($"{Prefix}.allowOverlap", AllowOverlap.ToString());
                if (!string.IsNullOrWhiteSpace(EnrichmentQueries)) output.Add($"{Prefix}.enrichmentQueries", Dictionaries);

                return output;
            }
        }
    }
}