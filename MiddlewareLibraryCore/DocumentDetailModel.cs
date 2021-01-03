using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace MiddlewareLibraryCore
{
    public class DocumentDetailInnerErrorModel
    {
        [XmlElement(ElementName = "propertyName")]
        [JsonPropertyName("propertyName")]
        public string PropertyName { get; set; }

        [XmlElement(ElementName = "propertyPath")]
        [JsonPropertyName("propertyPath")]
        public string PropertyPath { get; set; }

        [XmlElement(ElementName = "errorCode")]
        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; }

        [XmlElement(ElementName = "error")]
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [XmlElement(ElementName = "innerError")]
        [JsonPropertyName("innerError")]
        public object InnerError { get; set; }
    }

    public class DocumentDetailErrorModel
    {
        [XmlElement(ElementName = "propertyName")]
        [JsonPropertyName("propertyName")]
        public object PropertyName { get; set; }

        [XmlElement(ElementName = "propertyPath")]
        [JsonPropertyName("propertyPath")]
        public object PropertyPath { get; set; }

        [XmlElement(ElementName = "errorCode")]
        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; }

        [XmlElement(ElementName = "error")]
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [XmlArray(ElementName = "innerErrors")]
        [XmlArrayItem(ElementName = "innerError")]
        [JsonPropertyName("innerError")]
        public List<DocumentDetailInnerErrorModel> InnerError { get; set; }
    }

    public class DocumentDetailValidationStepModel
    {
        [XmlElement(ElementName = "status")]
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [XmlElement(ElementName = "error")]
        [JsonPropertyName("error")]
        public DocumentDetailErrorModel Error { get; set; }

        [XmlElement(ElementName = "stepName")]
        [JsonPropertyName("stepName")]
        public string StepName { get; set; }

        [XmlElement(ElementName = "stepId")]
        [JsonPropertyName("stepId")]
        public string StepId { get; set; }
    }

    public class DocumentDetailValidationResultsModel
    {
        [XmlElement(ElementName = "status")]
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [XmlArray(ElementName = "validationSteps")]
        [XmlArrayItem(ElementName = "validationStep")]
        [JsonPropertyName("validationSteps")]
        public List<DocumentDetailValidationStepModel> ValidationSteps { get; set; }
    }

    public class DocumentDetailModel
    {
        [XmlElement(ElementName = "submissionUUID")]
        [JsonPropertyName("submissionUUID")]
        public string SubmissionUuid { get; set; }

        [XmlElement(ElementName = "dateTimeRecevied")]
        [JsonPropertyName("dateTimeRecevied")]
        public DateTime DateTimeRecevied { get; set; }

        [XmlElement(ElementName = "validationResults")]
        [JsonPropertyName("validationResults")]
        public DocumentDetailValidationResultsModel ValidationResults { get; set; }

        [XmlElement(ElementName = "status")]
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [XmlElement(ElementName = "uuid")]
        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        [XmlElement(ElementName = "publicUrl")]
        [JsonPropertyName("publicUrl")]
        public string PublicUrl { get; set; }

        [XmlElement(ElementName = "internalID")]
        [JsonPropertyName("internalID")]
        public string InternalId { get; set; }

        [XmlElement(ElementName = "dateTimeIssued")]
        [JsonPropertyName("dateTimeIssued")]
        public DateTime DateTimeIssued { get; set; }

        [XmlElement(ElementName = "documentTypeVersion")]
        [JsonPropertyName("documentTypeVersion")]
        public string DocumentTypeVersion { get; set; }

        [XmlElement(ElementName = "documentType")]
        [JsonPropertyName("documentType")]
        public string DocumentType { get; set; }
    }
}