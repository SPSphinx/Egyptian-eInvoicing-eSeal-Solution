using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace MiddlewareLibraryCore
{
    [XmlType("documents")]
    public class Documents
    {
        [JsonPropertyName("invoices")]
        [XmlArray(ElementName = "invoices")]
        [XmlArrayItem(ElementName = "invoice")]
        public List<Invoice> Invoices { get; set; }
    }

    /// <summary>
    /// The data structure of the invoice, credit note and debit note 
    /// </summary>
    [XmlType("invoice")]
    public class Invoice
    {
        /// <summary>
        /// Structure representing the receiver
        /// </summary>
        [Required]
        [XmlElement(ElementName = "receiver")]
        [JsonPropertyName("receiver")]
        public Receiver Receiver { get; set; }

        /// <summary>
        /// Document type name.
        /// i for invoice, c for credit notes, d for debit notes
        /// </summary>
        [Required]
        [XmlElement(ElementName = "documentType")]
        [JsonPropertyName("documentType")]
        public string DocumentType { get; set; }

        /// <summary>
        /// The date and time when the document was issued. Date and time cannot be in future. Time to be supplied in UTC timezone.
        /// </summary>
        [Required]
        [JsonPropertyName("dateTimeIssued")]
        [XmlElement(ElementName = "dateTimeIssued")]
        public DateTime DateTimeIssued { get; set; }

        /// <summary>
        /// Internal document ID used to link back to the ERP document number. Value defined by the submitter.
        /// </summary>
        [Required]
        [JsonPropertyName("internalId")]
        [XmlElement(ElementName = "internalId")]
        public string InternalId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("currency")]
        [XmlElement(ElementName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("currency_rate")]
        [XmlElement(ElementName = "currency_rate")]
        public decimal CurrencyRate { get; set; }

        /// <summary>
        /// Optional: reference to purchase order that this document is related to.
        /// </summary>
        [JsonPropertyName("purchaseOrderReference")]
        [XmlElement(ElementName = "purchaseOrderReference")]
        public string PurchaseOrderReference { get; set; }

        /// <summary>
        /// Optional: Additional information about the purchase order provided to the recipient of the document.
        /// </summary>
        [JsonPropertyName("purchaseOrderDescription")]
        [XmlElement(ElementName = "purchaseOrderDescription")]
        public string PurchaseOrderDescription { get; set; }

        /// <summary>
        /// Optional: Reference to the previous sales order for informational purposes.
        /// </summary>
        [JsonPropertyName("salesOrderReference")]
        [XmlElement(ElementName = "salesOrderReference")]
        public string SalesOrderReference { get; set; }

        /// <summary>
        /// Optional: Additional information about the sales order provided to the recipient of the document.
        /// </summary>
        [JsonPropertyName("salesOrderDescription")]
        [XmlElement(ElementName = "salesOrderDescription")]
        public string SalesOrderDescription { get; set; }

        /// <summary>
        /// Optional: Reference to the previous proforma invoice.
        /// </summary>
        [JsonPropertyName("proformaInvoiceNumber")]
        [XmlElement(ElementName = "proformaInvoiceNumber")]
        [StringLength(50)]
        public string ProformaInvoiceNumber { get; set; }

        /// <summary>
        /// Optional: References to previous invoices for which credit/debit note is being issued.
        /// </summary>
        [JsonPropertyName("references")]
        [XmlArray(ElementName = "references")]
        [XmlArrayItem(ElementName = "reference")]
        public List<string> References { get; set; }

        /// <summary>
        /// Optional: Structure containing fields providing information on how payments needs to be made.
        /// </summary>
        [JsonPropertyName("payment")]
        [XmlElement(ElementName = "payment")]
        public Payment Payment { get; set; }

        /// <summary>
        /// Optional: Structure containing fields providing information on how the delivery of goods
        /// </summary>
        [JsonPropertyName("delivery")]
        [XmlElement(ElementName = "delivery")]
        public Delivery Delivery { get; set; }

        /// <summary>
        /// Additional discount amount applied at the level of the overall document, not individual lines.
        /// </summary>
        [JsonPropertyName("extraDiscountAmount")]
        [XmlElement(ElementName = "extraDiscountAmount")]
        public decimal ExtraDiscountAmount { get; set; }

        /// <summary>
        /// Invoice lines of the invoice. Needs to have at least one invoice line.
        /// </summary>
        [JsonPropertyName("lines")]
        [XmlArray(ElementName = "lines")]
        [XmlArrayItem(ElementName = "line")]
        public List<InvoiceLine> Lines { get; set; }
    }

    /// <summary>
    /// Invoice lines of the invoice. Needs to have at least one invoice line.
    /// </summary>
    [XmlType("line")]
    public class InvoiceLine
    {
        /// <summary>
        /// Internal code used for the product being sold – can be used to simplify references back to existing solution.
        /// </summary>
        [Required]
        [JsonPropertyName("internalCode")]
        [XmlElement(ElementName = "internalCode")]
        public string InternalCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [JsonPropertyName("isGs1")]
        [XmlElement(ElementName = "isGs1")]
        public bool IsGs1 { get; set; } = false;

        /// <summary>
        /// Description of the item being sold.
        /// </summary>
        [Required]
        [JsonPropertyName("description")]
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Number of units of the defined unit type being sold. Number should be larger than 0.
        /// </summary>
        [Required]
        [JsonPropertyName("quantity")]
        [XmlElement(ElementName = "quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Price of unit of goods/services sold
        /// </summary>
        [Required]
        [JsonPropertyName("amount")]
        [XmlElement(ElementName = "amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Code of the unit type used
        /// </summary>
        [Required]
        [JsonPropertyName("unit")]
        [XmlElement(ElementName = "unit")]
        public string Unit { get; set; }

        /// <summary>
        /// Value difference when selling goods already taxed
        /// </summary>
        [Required]
        [JsonPropertyName("valueDifference")]
        [XmlElement(ElementName = "valueDifference")]
        public decimal ValueDifference { get; set; } = 0;


        /// <summary>
        ///  discount percentage rate applied, Must be from 0 to 100
        /// </summary>
        [JsonPropertyName("discount_rate")]
        [XmlElement(ElementName = "discount_rate")]
        [Range(0, 100)]
        public decimal Discount { get; set; } = 0;

        /// <summary>
        /// List of taxable items
        /// </summary>
        [Required]
        [JsonPropertyName("taxes_type")]
        [XmlArray(ElementName = "taxes_type")]
        [XmlArrayItem(ElementName = "type")]
        public List<string> Taxes { get; set; }

        /// <summary>
        /// List of taxable items rates
        /// </summary>
        [Required]
        [JsonPropertyName("taxes_rate")]
        [XmlArray(ElementName = "taxes_rate")]
        [XmlArrayItem(ElementName = "rate")]
        public List<decimal> TaxesRate { get; set; }

        /// <summary>
        /// List of taxable items
        /// </summary>
        [Required]
        [JsonPropertyName("taxes_subtype")]
        [XmlArray(ElementName = "taxes_subtype")]
        [XmlArrayItem(ElementName = "subtype")]
        public List<string> SubTaxes { get; set; }
    }

    /// <summary>
    /// Structure representing the receiver
    /// </summary>
    public class Receiver
    {
        /// <summary>
        /// Country represented by ISO-3166-2 2 symbol code of the countries. Must be EG for internal business issuers.
        /// Required if type not equal P
        /// </summary>
        [JsonPropertyName("country")]
        [XmlElement(ElementName = "country")]
        public string Country { get; set; }

        /// <summary>
        /// Governorate information as textual value
        /// Required if type not equal P
        /// </summary>
        [JsonPropertyName("governate")]
        [XmlElement(ElementName = "governate")]
        public string Governate { get; set; }

        /// <summary>
        /// Region and city information as textual value
        /// Required if type not equal P
        /// </summary>
        [JsonPropertyName("regionCity")]
        [XmlElement(ElementName = "regionCity")]
        public string RegionCity { get; set; }

        /// <summary>
        /// street information
        /// Required if type not equal P
        /// </summary>
        [JsonPropertyName("street")]
        [XmlElement(ElementName = "street")]
        public string Street { get; set; }

        /// <summary>
        /// building information (number, name or both)
        /// Required if type not equal P
        /// </summary>
        [JsonPropertyName("buildingNumber")]
        [XmlElement(ElementName = "buildingNumber")]
        public string BuildingNumber { get; set; }

        /// <summary>
        /// Optional: Postal code	
        /// </summary>
        [JsonPropertyName("postalCode")]
        [XmlElement(ElementName = "postalCode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Optional: the floor number	
        /// </summary>
        [JsonPropertyName("floor")]
        [XmlElement(ElementName = "floor")]
        public string Floor { get; set; }

        /// <summary>
        /// Optional: the room/flat number in the floor
        /// </summary>
        [JsonPropertyName("room")]
        [XmlElement(ElementName = "room")]
        public string Room { get; set; }

        /// <summary>
        /// Optional: nearest landmark to the address
        /// </summary>
        [JsonPropertyName("landmark")]
        [XmlElement(ElementName = "landmark")]
        public string Landmark { get; set; }

        /// <summary>
        /// Optional: any additional information to the address
        /// </summary>
        [JsonPropertyName("additionalInformation")]
        [XmlElement(ElementName = "additionalInformation")]
        public string AdditionalInformation { get; set; }

        /// <summary>
        /// Type of the issuer - supported values - B for business in Egypt, P for natural person, F for foreigner.
        /// </summary>
        [Required]
        [JsonPropertyName("type")]
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Registration number. For business in Egypt must be registration number. For residents must be national ID. For foreign buyers must be VAT ID of the foreign company. Optional if person buyer and invoice amount less than threshold limit defined. Receiver and issuer cannot be the same.
        /// </summary>
        [JsonPropertyName("id")]
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Registration name of the company or name and surname of the person. Optional if person buyer and invoice amount less than threshold limit defined.
        /// </summary>
        [JsonPropertyName("name")]
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// Structure containing fields providing information on how payments needs to be made
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Optional: Name of the bank of document issuer.
        /// </summary>
        [JsonPropertyName("bankName")]
        [XmlElement(ElementName = "bankName")]
        public string BankName { get; set; }

        /// <summary>
        /// Optional: Address of the bank of document issuer. Captured as single line of text, not a structure.
        /// </summary>
        [JsonPropertyName("bankAddress")]
        [XmlElement(ElementName = "bankAddress")]
        public string BankAddress { get; set; }

        /// <summary>
        /// Optional: Local bank account number in the bank
        /// </summary>
        [JsonPropertyName("bankAccountNo")]
        [XmlElement(ElementName = "bankAccountNo")]
        public string BankAccountNo { get; set; }

        /// <summary>
        /// Optional: International bank account number used primarily for international documents.
        /// </summary>
        [JsonPropertyName("bankAccountIBAN")]
        [XmlElement(ElementName = "bankAccountIBAN")]
        public string BankAccountIban { get; set; }

        /// <summary>
        /// Optional: International Swift code of the bank.
        /// </summary>
        [JsonPropertyName("swiftCode")]
        [XmlElement(ElementName = "swiftCode")]
        public string SwiftCode { get; set; }

        /// <summary>
        /// Optional: Description of the payment terms describing when and how payments needs to be made, for example.
        /// </summary>
        [JsonPropertyName("terms")]
        [XmlElement(ElementName = "terms")]
        public string Terms { get; set; }
    }

    /// <summary>
    /// Structure containing fields providing information on how the delivery of goods
    /// </summary>
    public class Delivery
    {
        /// <summary>
        /// Optional: Information on the approach for delivery used, means of transportation.
        /// </summary>
        [JsonPropertyName("approach")]
        [XmlElement(ElementName = "approach")]
        public string Approach { get; set; }

        /// <summary>
        /// Optional: Information on types of packages used when delivering the goods
        /// </summary>
        [JsonPropertyName("packaging")]
        [XmlElement(ElementName = "packaging")]
        public string Packaging { get; set; }

        /// <summary>
        /// Optional: Validity date for exported products.
        /// </summary>
        [JsonPropertyName("dateValidity")]
        [XmlElement(ElementName = "dateValidity")]
        public DateTime DateValidity { get; set; }

        /// <summary>
        /// Optional: Port exporting the goods.
        /// </summary>
        [JsonPropertyName("exportPort")]
        [XmlElement(ElementName = "exportPort")]
        public string ExportPort { get; set; }

        /// <summary>
        /// Optional: Country of origin of goods/services. Country represented by ISO-3166-2 2 symbol code of the countries.	
        /// </summary>
        [JsonPropertyName("countryOfOrigin")]
        [XmlElement(ElementName = "countryOfOrigin")]
        public string CountryOfOrigin { get; set; }

        /// <summary>
        /// Optional: Total weight of the goods delivered. Value in kilograms.
        /// </summary>
        [JsonPropertyName("grossWeight")]
        [XmlElement(ElementName = "grossWeight")]
        public decimal GrossWeight { get; set; }

        /// <summary>
        /// Optional: Net weight of the goods delivered. Value in kilograms.
        /// </summary>
        [JsonPropertyName("netWeight")]
        [XmlElement(ElementName = "netWeight")]
        public decimal NetWeight { get; set; }

        /// <summary>
        /// Optional: Delivery terms/shipping terms information.
        /// </summary>
        [JsonPropertyName("terms")]
        [XmlElement(ElementName = "terms")]
        public string Terms { get; set; }
    }
}
