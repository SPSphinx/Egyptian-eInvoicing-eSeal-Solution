using System;
using System.Collections.Generic;
using MiddlewareLibraryCore;

namespace MiddlewareConsoleCore
{
    class Program
    {
        static void Main(string[] args)
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
                Lines = new List<InvoiceLine>{
                    new InvoiceLine{
                        Amount = 10m,
                        Description = "Computer1",
                        Discount = 7m,
                        InternalCode = "<InternalCode>",
                        IsGs1 = false,
                        Quantity = 5m,
                        Unit = "<Unit>",
                        ValueDifference = 7m,
                        Taxes = new string[]{
                            "T1", "T2", "T3"
                        },
                        TaxesRate = new decimal[]{
                            14, 12, 5
                        }
                    },  new InvoiceLine{
                        Amount = 5m,
                        Description = "Computer2",
                        Discount = 0,
                        InternalCode = "<InternalCode>",
                        IsGs1 = false,
                        Quantity = 7m,
                        Unit = "<Unit>",
                        ValueDifference = 6m,
                        Taxes = new string[]{
                            "T1", "T2", "T3"
                        },
                        TaxesRate = new decimal[]{
                            14, 12, 5
                        }
                    }
                }

            };

            IHttpClientHelper<Invoice> helper = new HttpClientHelper<Invoice>();

            var url = "<Middleware Ulr>";
            var result = default(ResponseModel);
            helper.PostAsync<ResponseModel>(url, invoice).ContinueWith(t => result = t.Result);

            Console.WriteLine(result);
        }
    }
}
