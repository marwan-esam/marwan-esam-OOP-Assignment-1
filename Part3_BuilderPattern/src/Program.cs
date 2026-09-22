namespace Part3_BuilderPattern;

public class Program
{
  public static void Main(string[] args)
  {
    Invoice.Builder invoiceBuilder = new Invoice.Builder();
    Invoice invoice = invoiceBuilder
    .AddAddressCity("Aswan")
    .AddAddressCountry("Egypt")
    .AddAddressState("Aswan")
    .AddAddressStreet("Mahmoudia")
    .AddAddressZip("8511")
    .AddBillingCity("Aswan")
    .AddBillingCountry("Egypt")
    .AddBillingState("Aswan")
    .AddBillingStreet("Mahmoudia")
    .AddBillingZip("8511")
    .AddCustomerEmail("marwanesam60@gmail.com")
    .AddCustomerName("Marwan Mohmaed Esam")
    .AddCustomerPhone("0123456")
    .AddDiscount(12)
    .AddInvoiceId(Guid.NewGuid())
    .AddOrderDate(DateTime.Now)
    .AddPaymentMethod(PaymentMethod.APPLE_PAY)
    .AddSubTotal(500)
    .AddTax(12)
    .Build();
  }

}