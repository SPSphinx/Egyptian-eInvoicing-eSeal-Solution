using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace MiddlewareLibraryCore
{
    public class ResponseModel
    {
        [XmlElement(ElementName = "internalId")]
        [JsonPropertyName("internalId")]
        public string InternalId { get; set; }

        [XmlElement(ElementName = "submissionUuid")]
        [JsonPropertyName("submissionUuid")]
        public string SubmissionUuid { get; set; }

        [XmlElement(ElementName = "uuid")]
        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        [XmlElement(ElementName = "status")]
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("errors")]
        [XmlArray(ElementName = "errors")]
        [XmlArrayItem(ElementName = "error")]
        public List<ResponseErrorModel> Errors { get; set; }
    }

    public class ResponseErrorModel
    {
        [XmlElement(ElementName = "code")]
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [XmlElement(ElementName = "message")]
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [XmlElement(ElementName = "target")]
        [JsonPropertyName("target")]
        public string Target { get; set; }
    }
}