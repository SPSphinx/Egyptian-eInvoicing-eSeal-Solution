# Egyptian eInvoicing eSeal Solution Provider

SP01 Middleware (e-Seal Solution) is a smart service to deliver the eInvoice from the taxpayers ERP business to the Egyptian Tax Authority (ETA) with high efficiency and short time, it will do all the calculation, serialization, signing of their invoices and send all to (ETA) system.

### How to use

**MiddlwareLibraryCore** is the main library to communicate with the SP01 Middleware (e-Seal Solution)

- Create new instant from _Invoice_ class

```

var invoice = new Invoice ();

```

- Collect the invoice information from your ERP or your Database
