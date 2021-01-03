using MiddlewareLibraryCore;
using System;
using System.Collections.Generic;

namespace MiddlewareConsoleCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetJsonDocumentDetail();
            //GetXmlDocumentDetail();

            //CancelJsonDocument();
            //CancelXmlDocument();

            //RejectJsonDocument();
            //RejectXmlDocument();

            /*
             * Submit Document For Invoice/Credit/Debit
             *
             * Change the DocumentType as follow
             * i -- Invoice
             * c -- Credit Note
             * d -- Debit Note
             *
             */
            //SubmitJsonDocument();
            //SubmitXmlDocument();

            /*
             * Submit Documents For Invoice/Credit/Debit
             *
             * Change the DocumentType as follow
             * i -- Invoice
             * c -- Credit Note
             * d -- Debit Note
             *
             */
            //SubmitJsonDocuments();
            //SubmitXmlDocuments();
        }

        private static void SubmitJsonDocument()
        {
            var invoice = new Invoice
            {
                Receiver = new Receiver
                {
                    AdditionalInformation = "beside Townhall",
                    BuildingNumber = "Bldg. 0",
                    Country = "EG",
                    Floor = "1",
                    Governate = "Egypt",
                    Id = "313717919",
                    Landmark = "7660 Melody Trail",
                    Name = "Receiver",
                    PostalCode = "68030",
                    RegionCity = "Mufazat al Ismlyah",
                    Room = "123",
                    Street = "580 Clementina Key",
                    Type = "B"
                },
                Currency = "EUR",
                CurrencyRate = 18.94m,
                DateTimeIssued = DateTime.UtcNow,
                InternalId = "IID001",
                ExtraDiscountAmount = 5,
                ProformaInvoiceNumber = "SomeValue",
                PurchaseOrderDescription = "purchase Order description",
                PurchaseOrderReference = "P-233-A6375",
                SalesOrderDescription = "Sales Order description",
                SalesOrderReference = "1231",
                Delivery = new Delivery
                {
                    Approach = "SomeValue",
                    Packaging = "SomeValue",
                    DateValidity = DateTime.UtcNow.AddMonths(1),
                    ExportPort = "SomeValue",
                    CountryOfOrigin = "EG",
                    GrossWeight = 10.5m,
                    NetWeight = 20.5m,
                    Terms = "SomeValue",
                },
                Payment = new Payment
                {
                    BankName = "SomeValue",
                    BankAddress = "SomeValue",
                    BankAccountNo = "SomeValue",
                    BankAccountIban = "",
                    SwiftCode = "",
                    Terms = "SomeValue"
                },
                Lines = new List<InvoiceLine>
                {
                    new InvoiceLine
                    {
                        Amount = 10m,
                        Description = "Computer1",
                        Discount = 7m,
                        InternalCode = "<InternalCode>",
                        IsGs1 = false,
                        Quantity = 5m,
                        Unit = "<Unit>",
                        ValueDifference = 7m,
                        Taxes = new List<string>
                        {
                            "T1"
                        },
                        TaxesRate = new List<decimal>
                        {
                            14
                        },
                        SubTaxes = new List<string>
                        {
                            "V009"
                        }
                    },
                    new InvoiceLine
                    {
                        Amount = 5m,
                        Description = "Computer2",
                        Discount = 0,
                        InternalCode = "<InternalCode>",
                        IsGs1 = false,
                        Quantity = 7m,
                        Unit = "<Unit>",
                        ValueDifference = 6m,
                        Taxes = new List<string>
                        {
                            "T1"
                        },
                        TaxesRate = new List<decimal>
                        {
                            14
                        },
                        SubTaxes = new List<string>
                        {
                            "V009"
                        }
                    }
                }
            };


            var helper =
                new JsonMiddlewareHelper<Invoice>(new JsonHttpClientHelper<Invoice>());

            var url = $"<SubmitDocument URL>";
            var result = helper.SubmitDocument<ResponseModel>(url, invoice);
        }

        private static void SubmitXmlDocument()
        {
            var invoice = new Invoice
            {
                Receiver = new Receiver
                {
                    AdditionalInformation = "beside Townhall",
                    BuildingNumber = "Bldg. 0",
                    Country = "EG",
                    Floor = "1",
                    Governate = "Egypt",
                    Id = "313717919",
                    Landmark = "7660 Melody Trail",
                    Name = "Receiver",
                    PostalCode = "68030",
                    RegionCity = "Mufazat al Ismlyah",
                    Room = "123",
                    Street = "580 Clementina Key",
                    Type = "B"
                },
                Currency = "EUR",
                CurrencyRate = 18.94m,
                DateTimeIssued = DateTime.UtcNow,
                InternalId = "IID001",
                ExtraDiscountAmount = 5,
                ProformaInvoiceNumber = "SomeValue",
                PurchaseOrderDescription = "purchase Order description",
                PurchaseOrderReference = "P-233-A6375",
                SalesOrderDescription = "Sales Order description",
                SalesOrderReference = "1231",
                Delivery = new Delivery
                {
                    Approach = "SomeValue",
                    Packaging = "SomeValue",
                    DateValidity = DateTime.UtcNow.AddMonths(1),
                    ExportPort = "SomeValue",
                    CountryOfOrigin = "EG",
                    GrossWeight = 10.5m,
                    NetWeight = 20.5m,
                    Terms = "SomeValue",
                },
                Payment = new Payment
                {
                    BankName = "SomeValue",
                    BankAddress = "SomeValue",
                    BankAccountNo = "SomeValue",
                    BankAccountIban = "",
                    SwiftCode = "",
                    Terms = "SomeValue"
                },
                Lines = new List<InvoiceLine>
                {
                    new InvoiceLine
                    {
                        Amount = 10m,
                        Description = "Computer1",
                        Discount = 7m,
                        InternalCode = "<InternalCode>",
                        IsGs1 = false,
                        Quantity = 5m,
                        Unit = "<Unit>",
                        ValueDifference = 7m,
                        Taxes = new List<string>
                        {
                            "T1"
                        },
                        TaxesRate = new List<decimal>
                        {
                            14
                        },
                        SubTaxes = new List<string>
                        {
                            "V009"
                        }
                    },
                    new InvoiceLine
                    {
                        Amount = 5m,
                        Description = "Computer2",
                        Discount = 0,
                        InternalCode = "<InternalCode>",
                        IsGs1 = false,
                        Quantity = 7m,
                        Unit = "<Unit>",
                        ValueDifference = 6m,
                        Taxes = new List<string>
                        {
                            "T1"
                        },
                        TaxesRate = new List<decimal>
                        {
                            14
                        },
                        SubTaxes = new List<string>
                        {
                            "V009"
                        }
                    }
                }
            };


            var helper =
                new XmlMiddlewareHelper<Invoice>(new XmlHttpClientHelper<Invoice>());

            var url = $"<SubmitDocument URL>";
            var result = helper.SubmitDocument<ResponseModel>(url, invoice);
        }

        private static void SubmitJsonDocuments()
        {
            var documents = new Documents
            {
                Invoices = new List<Invoice>
                {
                    new Invoice
                    {
                        Receiver = new Receiver
                        {
                            AdditionalInformation = "beside Townhall",
                            BuildingNumber = "Bldg. 0",
                            Country = "EG",
                            Floor = "1",
                            Governate = "Egypt",
                            Id = "313717919",
                            Landmark = "7660 Melody Trail",
                            Name = "Receiver",
                            PostalCode = "68030",
                            RegionCity = "Mufazat al Ismlyah",
                            Room = "123",
                            Street = "580 Clementina Key",
                            Type = "B"
                        },
                        Currency = "EUR",
                        CurrencyRate = 18.94m,
                        DateTimeIssued = DateTime.UtcNow,
                        InternalId = "IID001",
                        ExtraDiscountAmount = 5,
                        ProformaInvoiceNumber = "SomeValue",
                        PurchaseOrderDescription = "purchase Order description",
                        PurchaseOrderReference = "P-233-A6375",
                        SalesOrderDescription = "Sales Order description",
                        SalesOrderReference = "1231",
                        Delivery = new Delivery
                        {
                            Approach = "SomeValue",
                            Packaging = "SomeValue",
                            DateValidity = DateTime.UtcNow.AddMonths(1),
                            ExportPort = "SomeValue",
                            CountryOfOrigin = "EG",
                            GrossWeight = 10.5m,
                            NetWeight = 20.5m,
                            Terms = "SomeValue",
                        },
                        Payment = new Payment
                        {
                            BankName = "SomeValue",
                            BankAddress = "SomeValue",
                            BankAccountNo = "SomeValue",
                            BankAccountIban = "",
                            SwiftCode = "",
                            Terms = "SomeValue"
                        },
                        Lines = new List<InvoiceLine>
                        {
                            new InvoiceLine
                            {
                                Amount = 10m,
                                Description = "Computer1",
                                Discount = 7m,
                                InternalCode = "<InternalCode>",
                                IsGs1 = false,
                                Quantity = 5m,
                                Unit = "<Unit>",
                                ValueDifference = 7m,
                                Taxes = new List<string>
                                {
                                    "T1"
                                },
                                TaxesRate = new List<decimal>
                                {
                                    14
                                },
                                SubTaxes = new List<string>
                                {
                                    "V009"
                                }
                            },
                            new InvoiceLine
                            {
                                Amount = 5m,
                                Description = "Computer2",
                                Discount = 0,
                                InternalCode = "<InternalCode>",
                                IsGs1 = false,
                                Quantity = 7m,
                                Unit = "<Unit>",
                                ValueDifference = 6m,
                                Taxes = new List<string>
                                {
                                    "T1"
                                },
                                TaxesRate = new List<decimal>
                                {
                                    14
                                },
                                SubTaxes = new List<string>
                                {
                                    "V009"
                                }
                            }
                        }
                    }
                }
            };


            var helper =
                new JsonMiddlewareHelper<Documents>(new JsonHttpClientHelper<Documents>());

            var url = $"<SubmitDocuments URL>";
            var result = helper.SubmitDocuments<List<ResponseModel>>(url, documents);
        }

        private static void SubmitXmlDocuments()
        {
            var documents = new Documents
            {
                Invoices = new List<Invoice>
                {
                    new Invoice
                    {
                        Receiver = new Receiver
                        {
                            AdditionalInformation = "beside Townhall",
                            BuildingNumber = "Bldg. 0",
                            Country = "EG",
                            Floor = "1",
                            Governate = "Egypt",
                            Id = "313717919",
                            Landmark = "7660 Melody Trail",
                            Name = "Receiver",
                            PostalCode = "68030",
                            RegionCity = "Mufazat al Ismlyah",
                            Room = "123",
                            Street = "580 Clementina Key",
                            Type = "B"
                        },
                        Currency = "EUR",
                        CurrencyRate = 18.94m,
                        DateTimeIssued = DateTime.UtcNow,
                        InternalId = "IID001",
                        ExtraDiscountAmount = 5,
                        ProformaInvoiceNumber = "SomeValue",
                        PurchaseOrderDescription = "purchase Order description",
                        PurchaseOrderReference = "P-233-A6375",
                        SalesOrderDescription = "Sales Order description",
                        SalesOrderReference = "1231",
                        Delivery = new Delivery
                        {
                            Approach = "SomeValue",
                            Packaging = "SomeValue",
                            DateValidity = DateTime.UtcNow.AddMonths(1),
                            ExportPort = "SomeValue",
                            CountryOfOrigin = "EG",
                            GrossWeight = 10.5m,
                            NetWeight = 20.5m,
                            Terms = "SomeValue",
                        },
                        Payment = new Payment
                        {
                            BankName = "SomeValue",
                            BankAddress = "SomeValue",
                            BankAccountNo = "SomeValue",
                            BankAccountIban = "",
                            SwiftCode = "",
                            Terms = "SomeValue"
                        },
                        Lines = new List<InvoiceLine>
                        {
                            new InvoiceLine
                            {
                                Amount = 10m,
                                Description = "Computer1",
                                Discount = 7m,
                                InternalCode = "<InternalCode>",
                                IsGs1 = false,
                                Quantity = 5m,
                                Unit = "<Unit>",
                                ValueDifference = 7m,
                                Taxes = new List<string>
                                {
                                    "T1"
                                },
                                TaxesRate = new List<decimal>
                                {
                                    14
                                },
                                SubTaxes = new List<string>
                                {
                                    "V009"
                                }
                            },
                            new InvoiceLine
                            {
                                Amount = 5m,
                                Description = "Computer2",
                                Discount = 0,
                                InternalCode = "<InternalCode>",
                                IsGs1 = false,
                                Quantity = 7m,
                                Unit = "<Unit>",
                                ValueDifference = 6m,
                                Taxes = new List<string>
                                {
                                    "T1"
                                },
                                TaxesRate = new List<decimal>
                                {
                                    14
                                },
                                SubTaxes = new List<string>
                                {
                                    "V009"
                                }
                            }
                        }
                    }
                }
            };

            var helper =
                new XmlMiddlewareHelper<Documents>(new XmlHttpClientHelper<Documents>());

            var url = $"<SubmitDocuments URL>";
            var result = helper.SubmitDocuments<List<ResponseModel>>(url, documents);
        }

        private static void CancelJsonDocument()
        {
            var helper = new JsonMiddlewareHelper<ReasonModel>(new JsonHttpClientHelper<ReasonModel>());

            var url = $"<CancelDocument URL>";
            var result = helper.CancelDocument<bool>(url, "<uuid>", new ReasonModel
            {
                Reason = "reason message"
            });
        }

        private static void CancelXmlDocument()
        {
            var helper = new XmlMiddlewareHelper<ReasonModel>(new XmlHttpClientHelper<ReasonModel>());

            var url = $"<DocumentDetail URL>";
            var result = helper.CancelDocument<bool>(url, "<uuid>", new ReasonModel
            {
                Reason = "reason message"
            });
        }

        private static void RejectJsonDocument()
        {
            var helper = new JsonMiddlewareHelper<ReasonModel>(new JsonHttpClientHelper<ReasonModel>());

            var url = $"<RejectDocument URL>";
            var result = helper.RejectDocument<bool>(url, "<uuid>", new ReasonModel
            {
                Reason = "reason message"
            });
        }

        private static void RejectXmlDocument()
        {
            var helper = new XmlMiddlewareHelper<ReasonModel>(new XmlHttpClientHelper<ReasonModel>());

            var url = $"<RejectDocument URL>";
            var result = helper.RejectDocument<bool>(url, "<uuid>", new ReasonModel
            {
                Reason = "reason message"
            });
        }

        private static void GetJsonDocumentDetail()
        {
            var helper =
                new JsonMiddlewareHelper<DocumentDetailModel>(
                    new XmlHttpClientHelper<DocumentDetailModel>());

            var url = $"<DocumentDetail URL>";
            var result = helper.GetDocumentDetails(url, "<uuid>");
        }

        private static void GetXmlDocumentDetail()
        {
            var helper =
                new XmlMiddlewareHelper<DocumentDetailModel>(
                    new XmlHttpClientHelper<DocumentDetailModel>());

            var url = $"<DocumentDetail URL>";
            var result = helper.GetDocumentDetails(url, "<uuid>");
        }
    }
}