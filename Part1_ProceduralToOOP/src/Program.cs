namespace Part1_ProceduralToOOP;

public class Program
{
  public static void Main(String[] args)
  {
    OrderSystem orderSystem = new OrderSystem();
    orderSystem.SeedSampleData();
    orderSystem.RunDemoScenario();

    orderSystem.PrintCustomers();
    orderSystem.PrintProducts();
    orderSystem.PrintAllOrders();

    orderSystem.RunInteractiveMenu();
  }
}