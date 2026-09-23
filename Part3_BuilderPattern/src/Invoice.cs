namespace Part3_BuilderPattern;

public class Invoice
{
  public Guid Id {get; private set;}

  public string CustomerName {get; private set;}
  public string CustomerEmail {get; private set;}
  public string CustomerPhone {get; private set;}

  public Address ShippingAdress {get; private set;}
  public Address BillingAddress {get; private set;}
  public OrderInfo OrderDetails {get; private set;}

  private Invoice() {}

  public class Builder
  {
    private readonly Invoice _invoice;
    public Builder()
    {
      _invoice = new Invoice();
    }

    public Builder AddInvoiceId(Guid id)
    {
      _invoice.Id = id;
      return this;
    }
    public Builder AddCustomerName(string name)
    {
      _invoice.CustomerName = name;
      return this;
    }
    public Builder AddCustomerEmail(string email)
    {
      _invoice.CustomerEmail = email;
      return this;
    }
    public Builder AddCustomerPhone(string phone)
    {
      _invoice.CustomerPhone = phone;
      return this;
    }

    public Builder AddShippingAddress(Address shippingAddress)
    {
      _invoice.ShippingAdress = shippingAddress;
      return this;
    }
    public Builder AddBillingAddress(Address billingAddress)
    {
      _invoice.BillingAddress = billingAddress;
      return this;
    }
    public Builder AddOrderDetails(OrderInfo orderDetails)
    {
      _invoice.OrderDetails = orderDetails;
      return this;
    }
    public Invoice Build()
    {
      ArgumentException.ThrowIfNullOrWhiteSpace(_invoice.CustomerName, nameof(_invoice.CustomerName));
      ArgumentException.ThrowIfNullOrWhiteSpace(_invoice.CustomerEmail, nameof(_invoice.CustomerEmail));
      ArgumentException.ThrowIfNullOrWhiteSpace(_invoice.CustomerPhone, nameof(_invoice.CustomerPhone));
      ArgumentNullException.ThrowIfNull(_invoice.ShippingAdress);
      ArgumentNullException.ThrowIfNull(_invoice.BillingAddress);
      ArgumentNullException.ThrowIfNull(_invoice.OrderDetails);
      return _invoice;
    }
  }
}