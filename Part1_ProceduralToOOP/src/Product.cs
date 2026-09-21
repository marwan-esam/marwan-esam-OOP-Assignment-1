using System.Diagnostics;
using System.Security;

namespace Part1_ProceduralToOOP;

public class Product
{
  public int Id {get;}
  public string Name {get; private set;}
  public decimal Price {get; private set;}
  public int Stock {get; private set;}

  public Product(int id, string name, decimal price, int stock)
  {
    Id = id;
    
    if(string.IsNullOrWhiteSpace(name))
    {
      throw new ArgumentException("Name cannot be empty");
    }
    Name = name;

    if(price < 0m)
    {
      throw new ArgumentException("Price shouldn't be negative");
    }
    Price = price;

    if(stock < 0)
    {
      throw new ArgumentException("Stock cannnot be negative");
    }
    Stock = stock;
  }

  public bool ReduceStock(int quantity)
  {
    if(quantity <= 0)
    {
      throw new ArgumentException("Quantity to reduce must be positive");
    }
    int stockAfterReduction = Stock - quantity;
    if(stockAfterReduction >= 0)
    {
      Stock = stockAfterReduction;
      return true;
    } 
    return false;
  }

  public override string ToString()
  {
    return $"#{Id}  {Name}  price={Price:F2}  stock={Stock}";
  }
}