namespace Part3_BuilderPattern;

public enum PaymentMethod
{
  VISA,
  MASTERCARD,
  PAYPAL,
  GOOGLE_PAY,
  APPLE_PAY
}

public sealed class Invoice_Task32
{
  public Guid Id {get; private set;}

  public string? CustomerName {get; private set;}
  public string? CustomerEmail {get; private set;}
  public string? CustomerPhone {get; private set;}

  public string? BillingStreet {get; private set;}
  public string? BillingCity {get; private set;}
  public string? BillingState {get; private set;}
  public string? BillingZip {get; private set;}
  public string? BillingCountry {get; private set;}

  public string? AddressStreet {get; private set;}
  public string? AddressCity {get; private set;}
  public string? AddressState {get; private set;}
  public string? AddressZip {get; private set;}
  public string? AddressCountry {get; private set;}

  public PaymentMethod PaymentMethod {get; private set;}
  public DateTime OrderDate {get; private set;}
  public decimal SubTotal {get; private set;}
  public decimal Tax {get; private set;}
  public decimal Discount {get; private set;}
  public decimal Total => Math.Max(SubTotal + Tax - Discount, 0);

  private Invoice_Task32() {}

  /*
    I defined the builder class (which is right below this comment) as a nested builder class.
    Even though this is considered tight coupling, it is not the bad kind. The reason for this 
    is because this specific builder's entire purpose is to build an invoice object and so 
    it has no reason to be defined independently. A further proof of this is that if you
    wanted to add a property, you would have to update both the the invoice and the builder classes.
  */
  public class Builder
  {
    private readonly Invoice_Task32 _invoice;
    public Builder()
    {
      _invoice = new Invoice_Task32();
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
  
  public Builder AddBillingStreet(string billingStreet)
  {
    _invoice.BillingStreet = billingStreet;
    return this;
  }
  public Builder AddBillingCity(string billingCity)
  {
    _invoice.BillingCity = billingCity;
    return this;
  }
  public Builder AddBillingState(string billingState)
  {
    _invoice.BillingState = billingState;
    return this;
  }
  public Builder AddBillingZip(string billingZip)
  {
    _invoice.BillingZip = billingZip;
    return this;
  }
  public Builder AddBillingCountry(string billingCountry)
  {
    _invoice.BillingCountry = billingCountry;
    return this;
  }
  
  public Builder AddAddressStreet(string addressStreet)
  {
    _invoice.AddressStreet = addressStreet;
    return this;
  }
  public Builder AddAddressCity(string addressCity)
  {
    _invoice.AddressCity = addressCity;
    return this;
  }
  public Builder AddAddressState(string addressState)
  {
    _invoice.AddressState = addressState;
    return this;
  }
  public Builder AddAddressZip(string addressZip)
  {
    _invoice.AddressZip = addressZip;
    return this;
  }
  public Builder AddAddressCountry(string addressCountry)
  {
    _invoice.AddressCountry = addressCountry;
    return this;
  }

  public Builder AddPaymentMethod(PaymentMethod paymentMethod)
  {
    _invoice.PaymentMethod = paymentMethod;
    return this;
  }
  public Builder AddOrderDate(DateTime orderDate)
  {
    _invoice.OrderDate = orderDate;
    return this;
  }
  public Builder AddSubTotal(decimal subTotal)
  {
    _invoice.SubTotal = subTotal;
    return this;
  }
  public Builder AddTax(decimal tax)
  {
    _invoice.Tax = tax;
    return this;
  }
  public Builder AddDiscount(decimal discount)
  {
    _invoice.Discount = discount;
    return this;
  }

  public Invoice_Task32 Build()
  {
    ArgumentException.ThrowIfNullOrWhiteSpace(_invoice.AddressCity, nameof(_invoice.AddressCity));
    ArgumentException.ThrowIfNullOrWhiteSpace(_invoice.AddressCountry, nameof(_invoice.AddressCountry));
    ArgumentException.ThrowIfNullOrWhiteSpace(_invoice.AddressState, nameof(_invoice.AddressState));
    ArgumentException.ThrowIfNullOrWhiteSpace(_invoice.AddressStreet, nameof(_invoice.AddressStreet));
    ArgumentException.ThrowIfNullOrWhiteSpace(_invoice.AddressZip, nameof(_invoice.AddressZip));
    ArgumentException.ThrowIfNullOrWhiteSpace(_invoice.BillingCity, nameof(_invoice.BillingCity));
    ArgumentException.ThrowIfNullOrWhiteSpace(_invoice.BillingCountry, nameof(_invoice.BillingCountry));
    ArgumentException.ThrowIfNullOrWhiteSpace(_invoice.BillingState, nameof(_invoice.BillingState));
    ArgumentException.ThrowIfNullOrWhiteSpace(_invoice.BillingStreet, nameof(_invoice.BillingStreet));
    ArgumentException.ThrowIfNullOrWhiteSpace(_invoice.BillingZip, nameof(_invoice.BillingZip));
    ArgumentException.ThrowIfNullOrWhiteSpace(_invoice.CustomerEmail, nameof(_invoice.CustomerEmail));
    ArgumentException.ThrowIfNullOrWhiteSpace(_invoice.CustomerName, nameof(_invoice.CustomerName));
    ArgumentException.ThrowIfNullOrWhiteSpace(_invoice.CustomerPhone, nameof(_invoice.CustomerPhone));
    return _invoice;
  }
  }
}