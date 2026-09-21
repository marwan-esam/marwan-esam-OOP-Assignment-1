using System.Net.Mail;

namespace Part1_ProceduralToOOP;

public class Customer
{
  public int Id {get; private set;}
  public string Name {get; private set;}
  public string Email {get; private set;}
  public string City {get; private set;}
  public bool IsVip {get; private set;}

  public Customer(int id, string name, string email, string city, bool isVip)
  {
    Id = id;

    if(string.IsNullOrWhiteSpace(name))
    {
      throw new ArgumentException("Name cannot be empty");
    }
    Name = name;

    try
    {
      var mailAddress = new MailAddress(email);
      Email = mailAddress.Address;
    } catch(FormatException e)
    {
      throw new ArgumentException(e.Message);
    }
    City = city;
    IsVip = isVip;
  }

  public override string ToString()
  {
    string vipStatus = IsVip ? "yes" : "no";
    return $"#{Id}  {Name}  <{Email}>  {City}  vip={vipStatus}";
  }
}