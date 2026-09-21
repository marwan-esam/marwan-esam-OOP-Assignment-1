namespace Part1_ProceduralToOOP;

public class OrderLine
{
  public Product Product {get;}
  public int Quantity {get; private set;}

  public decimal LineTotal => Product.Price * Quantity;
  
  public OrderLine(Product product, int quantity)
  {
    if(quantity <= 0)
    {
      throw new ArgumentException("Quantity of an order line must be positive");
    }
    Quantity = quantity;

    Product = product;
  }
}