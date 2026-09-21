using System;
using System.Collections.Generic;

namespace Part1_ProceduralToOOP;

public class OrderSystem
{
    private List<Customer> _customers = new List<Customer>();
    private List<Product> _products = new List<Product>();
    private List<Order> _orders = new List<Order>();

    private Customer? GetCustomerById(int id)
    {
        foreach (var c in _customers)
        {
            if (c.Id == id) return c;
        }
        return null;
    }

    private Product? GetProductById(int id)
    {
        foreach (var p in _products)
        {
            if (p.Id == id) return p;
        }
        return null;
    }

    private Order? GetOrderById(int id)
    {
        foreach (var o in _orders)
        {
            if (o.Id == id) return o;
        }
        return null;
    }

    public void AddCustomer(int id, string name, string email, string city, bool isVip)
    {
        if (GetCustomerById(id) != null)
        {
            Console.WriteLine($"ERROR: customer id {id} already exists.");
            return;
        }
        try
        {
            _customers.Add(new Customer(id, name, email, city, isVip));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void PrintCustomers()
    {
        Console.WriteLine($"\n=== CUSTOMERS ({_customers.Count}) ===");
        foreach (var c in _customers)
        {
            Console.WriteLine(c.ToString());
        }
    }

    public void AddProduct(int id, string name, decimal price, int stock)
    {
        if (GetProductById(id) != null)
        {
            Console.WriteLine($"ERROR: product id {id} already exists.");
            return;
        }
        try
        {
            _products.Add(new Product(id, name, price, stock));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void PrintProducts()
    {
        Console.WriteLine($"\n=== PRODUCTS ({_products.Count}) ===");
        foreach (var p in _products)
        {
            Console.WriteLine(p.ToString());
        }
    }

    public void CreateOrder(int orderId, int customerId, string dateString)
    {
        if (GetOrderById(orderId) != null)
        {
            Console.WriteLine($"ERROR: order id {orderId} already exists.");
            return;
        }

        var customer = GetCustomerById(customerId);
        if (customer == null)
        {
            Console.WriteLine($"ERROR: customer id {customerId} not found.");
            return;
        }

        if (!DateTime.TryParse(dateString, out DateTime date))
        {
            Console.WriteLine("ERROR: Invalid date format.");
            return;
        }

        try
        {
            _orders.Add(new Order(orderId, customer, date));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void AddLineToOrder(int orderId, int productId, int quantity)
    {
        var order = GetOrderById(orderId);
        if (order == null)
        {
            Console.WriteLine($"ERROR: order id {orderId} not found.");
            return;
        }

        var product = GetProductById(productId);
        if (product == null)
        {
            Console.WriteLine($"ERROR: product id {productId} not found.");
            return;
        }

        try
        {
            order.AddLine(product, quantity);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void MarkOrderPaid(int orderId)
    {
        var order = GetOrderById(orderId);
        if (order == null)
        {
            Console.WriteLine($"ERROR: order id {orderId} not found.");
            return;
        }

        if (order.Lines.Count == 0)
        {
            Console.WriteLine("ERROR: cannot pay an empty order.");
            return;
        }

        try
        {
            order.Pay();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void PrintOrder(int orderId)
    {
        var order = GetOrderById(orderId);
        if (order == null)
        {
            Console.WriteLine($"ERROR: order id {orderId} not found.");
            return;
        }
        Console.Write(order.ToString());
    }

    public void PrintAllOrders()
    {
        Console.WriteLine($"\n=== ALL ORDERS ({_orders.Count}) ===");
        foreach (var o in _orders)
        {
            Console.Write(o.ToString());
        }
    }

    public decimal TotalSalesPaidOnly()
    {
        decimal total = 0m;
        foreach (var o in _orders)
        {
            if (o.IsPaid)
            {
                total += o.CalculateTotal();
            }
        }
        return total;
    }

    public void SeedSampleData()
    {
        AddCustomer(1, "Mona Ali", "mona@example.com", "Cairo", true);
        AddCustomer(2, "Omar Hassan", "omar@example.com", "Alexandria", false);
        AddCustomer(3, "Sara Nabil", "sara@example.com", "Giza", false);

        AddProduct(101, "USB Cable", 50.0m, 100);
        AddProduct(102, "Wireless Mouse", 250.0m, 40);
        AddProduct(103, "Mechanical Keyboard", 1200.0m, 15);
        AddProduct(104, "Laptop Stand", 400.0m, 25);
    }

    public void RunDemoScenario()
    {
        CreateOrder(1001, 1, "2026-09-15");
        AddLineToOrder(1001, 101, 2);
        AddLineToOrder(1001, 102, 1);
        MarkOrderPaid(1001);

        CreateOrder(1002, 2, "2026-09-15");
        AddLineToOrder(1002, 103, 1);
        AddLineToOrder(1002, 104, 1);

        CreateOrder(1003, 3, "2026-09-16");
        AddLineToOrder(1003, 101, 5);
        MarkOrderPaid(1003);
    }

    private void PrintMenu()
    {
        Console.WriteLine("\n---------- MENU ----------");
        Console.WriteLine("1) Print customers");
        Console.WriteLine("2) Print products");
        Console.WriteLine("3) Print all orders");
        Console.WriteLine("4) Print one order by id");
        Console.WriteLine("5) Create order");
        Console.WriteLine("6) Add line to order");
        Console.WriteLine("7) Mark order paid");
        Console.WriteLine("8) Show paid sales total");
        Console.WriteLine("0) Exit");
        Console.Write("Choice: ");
    }

    public void RunInteractiveMenu()
    {
        int choice = -1;
        while (choice != 0)
        {
            PrintMenu();
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                choice = -1;
            }

            if (choice == 1) PrintCustomers();
            else if (choice == 2) PrintProducts();
            else if (choice == 3) PrintAllOrders();
            else if (choice == 4)
            {
                Console.Write("Order id: ");
                if (int.TryParse(Console.ReadLine(), out int orderId))
                    PrintOrder(orderId);
            }
            else if (choice == 5)
            {
                Console.Write("Order id: ");
                int.TryParse(Console.ReadLine(), out int orderId);
                Console.Write("Customer id: ");
                int.TryParse(Console.ReadLine(), out int customerId);
                Console.Write("Date (YYYY-MM-DD): ");
                string date = Console.ReadLine()!;
                CreateOrder(orderId, customerId, date);
            }
            else if (choice == 6)
            {
                Console.Write("Order id: ");
                int.TryParse(Console.ReadLine(), out int orderId);
                Console.Write("Product id: ");
                int.TryParse(Console.ReadLine(), out int productId);
                Console.Write("Quantity: ");
                int.TryParse(Console.ReadLine(), out int quantity);
                AddLineToOrder(orderId, productId, quantity);
            }
            else if (choice == 7)
            {
                Console.Write("Order id: ");
                int.TryParse(Console.ReadLine(), out int orderId);
                MarkOrderPaid(orderId);
            }
            else if (choice == 8)
            {
                Console.WriteLine($"Paid sales total: {TotalSalesPaidOnly():F2}");
            }
            else if (choice == 0)
            {
                Console.WriteLine("Bye.");
            }
            else
            {
                Console.WriteLine("Unknown choice.");
            }
        }
    }
}
