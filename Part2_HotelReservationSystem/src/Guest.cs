using System.Diagnostics.Contracts;

namespace Part2_HotelReservationSystem;

public class Reservation {} // temporary
public class Guest
{
  private readonly List<Reservation> _reservations;
  public Guid Id {get;}
  public string FullName {get;}
  public string PhoneNumber {get;}
  public IReadOnlyList<Reservation> Reservations
  {
    get {
      return _reservations.AsReadOnly();    
    }
  }
  public Guest(Guid id, string? fullName, string? phoneNumber)
  {
    if(string.IsNullOrWhiteSpace(fullName))
    {
      throw new ArgumentException("Name must not be null or empty");
    }
    FullName = fullName;

    if(string.IsNullOrWhiteSpace(phoneNumber))
    {
      throw new ArgumentException("Phone Number must not be null or empty");
    }
    PhoneNumber = phoneNumber;

    Id = id;
    _reservations = [];
  }

  public void AddReservation(Reservation reservation)
  {
    _reservations.Add(reservation);
  }
}