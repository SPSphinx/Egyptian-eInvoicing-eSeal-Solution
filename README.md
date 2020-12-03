# Egyptian eInvoicing eSeal Solution Provider

SP01 Middleware (e-Seal Solution) is a smart service to deliver the eInvoice from the taxpayers ERP business to the Egyptian Tax Authority (ETA) with high efficiency and short time, it will do all the calculation, serialization, signing of their invoices and send all to (ETA) system.

### How to use

**MiddlwareLibraryCore** is the main library to communicate with the SP01 Middleware (e-Seal Solution)

- Initialize a new _Invoice_ type by using object initializers.

```
var invoice = new Invoice ();
```

- Collect the invoice information from your ERP or your Database

```
invoice. DateTimeIssued = DateTime.UtcNow;
invoice.InternalId = "IID001";
invoice.ExtraDiscountAmount = 5;
```

- Initialize a new generic _HttpClientHelper_ type of type _Invoice_ by using object initializers.

```
IHttpClientHelper<Invoice> helper = new HttpClientHelper<Invoice>();
```

- Pass the URL of the SP01 Middleware (e-Seal Solution) as the first _Parameter_ and the initalized **invoice** to generic _PostAsync_ method.

```
var url = "<Middleware Ulr>";
var result = default(ResponseModel);
helper.PostAsync<ResponseModel>(url, invoice).ContinueWith(t => result = t.Result);
```
