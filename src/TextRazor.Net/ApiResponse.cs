namespace TextRazor.Net
{
    using System;
    using Newtonsoft.Json;
    using TextRazor.Net.Models;

    public class ApiResponse
    {
        /// <summary>
        ///     Total time in seconds TextRazor took to process this request. This does not include any time spent sending or
        ///     recieving the request/response.
        /// </summary>
        [JsonProperty("time")]
        public double Time { get; set; }

        /// <summary>
        ///     The output of the requested operation
        /// </summary>
        [JsonProperty("response")]
        public Response Response { get; set; }

        /// <summary>
        ///     <c>true</c> if TextRazor successfully analyzed your document, <c>false</c> if there was some error.
        /// </summary>
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        /// <summary>
        ///     Descriptive error message of any problems that may have occurred during analysis, or an empty string if there was
        ///     no error.
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }

        /// <summary>
        ///     Any warning or informational messages returned from the server, or an empty string if there was no message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }


        public override string ToString()
        {
            return $"Time: {Time}, OK: {Ok}{Environment.NewLine}{Response}";
        }
    }
}