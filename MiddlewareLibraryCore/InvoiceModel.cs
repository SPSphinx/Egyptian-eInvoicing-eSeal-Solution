using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MiddlewareLibraryCore
{
    /// <summary>
    /// Invoice data structure 
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Structure representing the receiver
        /// </summary>
        public Receiver Receiver { get; set; }

        /// <summary>
        /// The date and time when the document was issued. Date and time cannot be in future.
        /// </summary>
        public DateTime DateTimeIssued { get; set; }

        /// <summary>
        /// Internal document ID used to link back to the ERP document number. Value defined by the submitter.
        /// </summary>
        public string InternalId { get; set; }

        /// <summary>
        /// Currency code used from ISO 4217.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Exchange rate of the Egyptian bank on the day of invoicing used to convert currency sold to the value of currency EGP. Mandatory if currencySold is not EGP.
        /// </summary>
        [JsonPropertyName("currency_rate")]
        public decimal CurrencyRate { get; set; }

        /// <summary>
        /// Optional: reference to purchase order that this document is related to.
        /// </summary>
        public string PurchaseOrderReference { get; set; }

        /// <summary>
        /// Optional: Additional information about the purchase order provided to the recipient of the document.
        /// </summary>
        public string PurchaseOrderDescription { get; set; }

        /// <summary>
        /// Optional: Reference to the previous sales order for informational purposes.
        /// </summary>
        public string SalesOrderReference { get; set; }

        /// <summary>
        /// Optional: Additional information about the sales order provided to the recipient of the document.
        /// </summary>
        public string SalesOrderDescription { get; set; }

        /// <summary>
        /// Optional: Reference to the previous proforma invoice.
        /// </summary>
        [StringLength(50)]
        public string ProformaInvoiceNumber { get; set; }

        /// <summary>
        /// Optional: Structure containing fields providing information on how payments needs to be made.
        /// </summary>
        public Payment Payment { get; set; }

        /// <summary>
        /// Optional: Structure containing fields providing information on how the delivery of goods
        /// </summary>
        public Delivery Delivery { get; set; }

        /// <summary>
        /// Additional discount amount applied at the level of the overall document, not individual lines.
        /// </summary>
        public decimal ExtraDiscountAmount { get; set; } = 0.00000m;

        /// <summary>
        /// Invoice lines of the invoice. Needs to have at least one invoice line.
        /// </summary>
        public IList<InvoiceLine> Lines { get; set; }
    }

    /// <summary>
    /// Invoice lines of the invoice
    /// </summary>
    public class InvoiceLine
    {
        /// <summary>
        /// Internal code used for the product being sold
        /// </summary>
        public string InternalCode { get; set; }

        /// <summary>
        /// True to use GS1 code, otherwise use GPC code, Must be false for this version 
        /// </summary>
        public bool IsGs1 { get; set; } = false;

        /// <summary>
        /// Description of the item being sold.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Number of units of the defined unit type being sold. Number should be larger than 0.
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Price of unit of goods/services sold 
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Code of the unit type
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Value difference when selling goods already taxed
        /// </summary>
        public decimal ValueDifference { get; set; }

        /// <summary>
        /// Optional: the structure defining the discount applied on a single unit sold.
        /// </summary>
        [JsonPropertyName("discount_rate")]
        public decimal Discount { get; set; }

        /// <summary>
        /// Array of taxes applied on a single unit sold.
        /// </summary>
        [JsonPropertyName("taxes_type")]
        public IList<string> Taxes { get; set; }

        /// <summary>
        /// Array of taxes value applied on a single unit sold.
        /// </summary>
        [JsonPropertyName("taxes_rate")]
        public IList<decimal> TaxesRate { get; set; }

    }

    /// <summary>
    /// Representing the receiver information
    /// </summary>
    public class Receiver
    {
        /// <summary>
        /// Country represented by ISO-3166-2 2 symbol code of the countries. Must be EG for internal business issuers.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Governorate information as textual value
        /// </summary>
        public string Governate { get; set; }

        /// <summary>
        /// Region and city information as textual value
        /// </summary>
        public string RegionCity { get; set; }

        /// <summary>
        /// street information
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// building information (number, name or both)
        /// </summary>
        public string BuildingNumber { get; set; }

        /// <summary>
        /// Optional: Postal code
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Optional: the floor number
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Optional: the room/flat number in the floor
        /// </summary>
        public string Room { get; set; }

        /// <summary>
        /// Optional: nearest landmark to the address
        /// </summary>
        public string Landmark { get; set; }

        /// <summary>
        /// Optional: any additional information to the address
        /// </summary>
        public string AdditionalInformation { get; set; }

        /// <summary>
        /// Type of the issuer - supported values - B for business in Egypt, P for natural person, F for foreigner.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Registration number. For business in Egypt must be registration number. For residents must be national ID. For foreign buyers must be VAT ID of the foreign company. Optional if person buyer and invoice amount less than threshold limit defined. Receiver and issuer cannot be the same.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Registration name of the company or name and surname of the person. Optional if person buyer and invoice amount less than threshold limit defined.
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// Structure containing fields providing information on how payments needs to be made.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Optional: Name of the bank of document issuer.
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Optional: Address of the bank of document issuer. Captured as single line of text, not a structure.
        /// </summary>
        public string BankAddress { get; set; }

        /// <summary>
        /// Optional: Local bank account number in the bank
        /// </summary>
        public string BankAccountNo { get; set; }

        /// <summary>
        /// Optional: International bank account number used primarily for international documents.
        /// </summary>
        public string BankAccountIban { get; set; }

        /// <summary>
        /// Optional: International Swift code of the bank.
        /// </summary>
        public string SwiftCode { get; set; }

        /// <summary>
        /// Optional: Description of the payment terms describing when and how payments needs to be made, for example.
        /// </summary>
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
        public string Approach { get; set; }

        /// <summary>
        /// Optional: Information on types of packages used when delivering the goods
        /// </summary>
        public string Packaging { get; set; }

        /// <summary>
        /// Optional: Validity date for exported products.
        /// </summary>
        public DateTime? DateValidity { get; set; }

        /// <summary>
        /// Optional: Port exporting the goods.
        /// </summary>
        public string ExportPort { get; set; }

        /// <summary>
        /// Optional: Country of origin of goods/services. Country represented by ISO-3166-2 2 symbol code of the countries.
        /// </summary>
        public string CountryOfOrigin { get; set; }

        /// <summary>
        /// Optional: Total weight of the goods delivered. Value in kilograms.
        /// </summary>
        public decimal GrossWeight { get; set; }

        /// <summary>
        /// Optional: Net weight of the goods delivered. Value in kilograms.
        /// </summary>
        public decimal NetWeight { get; set; }

        /// <summary>
        /// Optional: Delivery terms/shipping terms information.
        /// </summary>
        public string Terms { get; set; }
    }
}
