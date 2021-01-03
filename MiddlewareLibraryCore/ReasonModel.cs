using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace MiddlewareLibraryCore
{
    /// <summary>
    /// Object that contains the reason for cancelling/rejecting the document.
    /// </summary>
    [XmlType("reasons")]
    public class ReasonModel
    {
        /// <summary>
        /// Reason for cancelling/rejecting  the document.
        /// </summary>
        [XmlElement(ElementName = "reason")]
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
    }
}