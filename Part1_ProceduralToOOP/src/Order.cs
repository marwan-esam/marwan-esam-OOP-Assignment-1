using System.Reflection;
using System.Reflection.Metadata;
using System.Text;

namespace Part1_ProceduralToOOP;

public class Order
{
  public int Id {get;}
  public Customer Customer {get;}
  public DateTime Date {get;}
  public bool IsPaid {get; private set;}
  public List<OrderLine> Lines {get; private set;}
  public static decimal VipDiscount {get;} = 0.1m;

  public Order(int id, Customer customer, DateTime date)
  {
    Id = id;
    Customer = customer;
    Date = date;
    Lines = new List<OrderLine>();
  }

  public bool AddLine(Product product, int quantity)
  {
    if(IsPaid)
    {
      throw new InvalidOperationException("Cannot modify a paid order");
    }
    Lines.Add(new OrderLine(product, quantity));
    return true; 
  }

  public decimal CalculateTotal()
  {
    decimal sum = 0m;
    foreach(OrderLine line in Lines)
    {
      sum += line.LineTotal;
    }
    if(Customer.IsVip) sum -= (sum * VipDiscount);
    return sum;
  }

  public bool ReduceLinesStock()
  {
    foreach(OrderLine line in Lines)
    {
      if(!line.Product.ReduceStock(line.Quantity))
      {
        throw new InvalidOperationException($"Not enough stock for {line.Product.Name}!");
      }
    }
    return true;
  }

  public decimal Pay()
  {
    if(IsPaid)
    {
      throw new InvalidOperationException("Cannot pay an already paid Order");
    }
    ReduceLinesStock();
    IsPaid = true;
    return CalculateTotal();
  }

  public override string ToString()
  {
    string orderStatus = IsPaid ? "yes" : "no";
    StringBuilder res = new StringBuilder();
    res.AppendLine($"=== ORDER #{Id} ===\n" + 
           $"Date: {Date.ToString("yyyy-MM-dd")}\n" + 
           $"Customer: {Customer.Name} (${Customer.Id})\n" + 
           $"Paid: {orderStatus}\n" + 
           "Lines:");
    foreach(OrderLine line in Lines)
    {
      res.AppendLine(line.ToString());
    }
    res.AppendLine($"TOTAL: {CalculateTotal():F2}");
    return res.ToString();
  }

}