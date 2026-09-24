namespace Part3_BuilderPattern;
public class OrderInfo
{
  public PaymentMethod PaymentMethod {get; private set;}
  public DateTime OrderDate {get; private set;}
  public decimal SubTotal {get; private set;}
  public decimal Tax {get; private set;}
  public decimal Discount {get; private set;}
  public decimal Total => Math.Max(SubTotal + Tax - Discount, 0);

  private OrderInfo() {}

  public class Builder
  {
    private readonly OrderInfo _orderInfo;
    public Builder()
    {
      _orderInfo = new OrderInfo();
    }

    public Builder AddPaymentMethod(PaymentMethod paymentMethod)
    {
      _orderInfo.PaymentMethod = paymentMethod;
      return this;
    }
    public Builder AddOrderDate(DateTime orderDate)
    {
      _orderInfo.OrderDate = orderDate;
      return this;
    }
    public Builder AddSubTotal(decimal subTotal)
    {
      _orderInfo.SubTotal = subTotal;
      return this;
    }
    public Builder AddTax(decimal tax)
    {
      _orderInfo.Tax = tax;
      return this;
    }
    public Builder AddDiscount(decimal discount)
    {
      _orderInfo.Discount = discount;
      return this;
    }
    public OrderInfo Build()
    {
      return _orderInfo;
    }

  }
}