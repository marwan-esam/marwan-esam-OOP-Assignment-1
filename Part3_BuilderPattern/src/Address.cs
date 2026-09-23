using System.Runtime.Loader;

namespace Part3_BuilderPattern;


public class Address
{
  public string Street {get; private set;}
  public string City {get; private set;}
  public string State {get; private set;}
  public string Zip {get; private set;}
  public string Country {get; private set;}

  private Address() {}

  public class Builder
  {
    private readonly Address _address;

    public Builder()
    {
      _address = new Address();
    }
    public Builder AddStreet(string street)
    {
      _address.Street = street;
      return this;
    }
    public Builder AddCity(string city)
    {
      _address.City = city;
      return this;
    }
    public Builder AddState(string state)
    {
      _address.State = state;
      return this;
    }
    public Builder AddZip(string zip)
    {
      _address.Zip = zip;
      return this;
    }
    public Builder AddCountry(string country)
    {
      _address.Country = country;
      return this;
    }

    public Address Build()
    {
      ArgumentException.ThrowIfNullOrWhiteSpace(_address.City, nameof(_address.City));
      ArgumentException.ThrowIfNullOrWhiteSpace(_address.Country, nameof(_address.Country));
      ArgumentException.ThrowIfNullOrWhiteSpace(_address.State, nameof(_address.State));
      ArgumentException.ThrowIfNullOrWhiteSpace(_address.Street, nameof(_address.Street));
      return _address;
    }
  }

}