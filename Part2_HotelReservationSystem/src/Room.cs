using System.Reflection.Metadata;

namespace Part2_HotelReservationSystem;

public enum RoomType
{
  Single,
  Double,
  Suite
}

public class Room
{
  public int Number {get;}
  public RoomType Type {get;}
  public decimal NightlyRate {get; private set;}
  public bool IsUnderMaintenance {get; private set;}

  public Room(int number, RoomType type, decimal nightlyRate, bool isUnderMaintenance)
  {
    Number = number;
    Type = type;

    if(nightlyRate <= 0)
    {
      throw new ArgumentException("Nightly rate must be a positive value");
    }
    NightlyRate = nightlyRate;

    IsUnderMaintenance = isUnderMaintenance;
  }

  public void ChangeNightlyRate(decimal price)
  {
    if(price <= 0)
    {
      throw new ArgumentException("Nightly rate must be a positive value");
    }
    NightlyRate = price;
  }

  public void StartMaintenance()
  {
    IsUnderMaintenance = true;
  }

  public void EndMaintenance()
  {
    IsUnderMaintenance = false;
  }
}