using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MiddlewareLibraryCore
{
    public class ResponseModel
    {
        [JsonPropertyName("responseSource")]
        public string ResponseSource { get; set; } = "Middleware";

        [JsonPropertyName("submissionId")]
        public string SubmissionId { get; set; }

        [JsonPropertyName("acceptedDocuments")]
        public IList<DocumentAcceptedModel> AcceptedDocuments { get; set; } = new List<DocumentAcceptedModel>();

        [JsonPropertyName("rejectedDocuments")]
        public IList<DocumentRejectedModel> RejectedDocuments { get; set; } = new List<DocumentRejectedModel>();



    }

    /// <summary>
    /// List of documents that are not accepted together with their internal IDs and error information.
    /// </summary>
    public class DocumentRejectedModel
    {
        [JsonPropertyName("internalId")]
        public string InternalId { get; set; }

        [JsonPropertyName("error")]
        public ErrorResponseModel Error { get; set; }
    }

    /// <summary>
    /// Error information detailing why the document was not accepted in this submission
    /// </summary>
    public class ErrorResponseModel
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("target")]
        public string Target { get; set; }

        [JsonPropertyName("propertyPath")]
        public string PropertyPath { get; set; }

        [JsonPropertyName("details")]
        public IList<ErrorResponseModel> Details { get; set; }
    }

    /// <summary>
    /// List of documents that are accepted together with their internal IDs and newly assigned IDs.
    /// </summary>
    public class DocumentAcceptedModel
    {
        [JsonPropertyName("uuid")]
        public string UUID { get; set; }

        [JsonPropertyName("longId")]
        public string LongId { get; set; }

        [JsonPropertyName("internalId")]
        public string InternalId { get; set; }

        [JsonPropertyName("hashKey")]
        public string HashKey { get; set; }
    }
}