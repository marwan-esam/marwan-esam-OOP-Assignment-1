using System.Reflection.Metadata;

namespace Part2_HotelReservationSystem;

public enum ReservationStatus
{
  Pending,
  Confirmed,
  CheckedIn,
  CheckedOut,
  Cancelled
}
public class Reservation
{
  public Guid Id {get;}
  public DateTime CheckedInDate {get;}
  public DateTime CheckedOutDate {get;}
  public Room Room {get;}
  public ReservationStatus Status {get; private set;}
  public decimal TotalCost => (CheckedOutDate - CheckedInDate).Days * Room.NightlyRate;

  public Reservation(Guid id, DateTime checkedInDate, DateTime checkedOutDate, Room? room)
  {
    if(checkedOutDate <= checkedInDate)
    {
      throw new ArgumentException("Checkout date cannot be set before or at the same time with check in date");
    }
    CheckedInDate = checkedInDate;
    CheckedOutDate = checkedOutDate;

    if(room == null)
    {
      throw new ArgumentException("Cannot book a reservation without specifying a room");
    }
    if(room.IsUnderMaintenance)
    {
      throw new ArgumentException("Cannot book a room under maintenance");
    }
    Room = room;
    
    Id = id;
    Status = ReservationStatus.Pending;
  }

  public void Confirm()
  {
    if(Status != ReservationStatus.Pending)
    {
      throw new InvalidOperationException("Cannot confirm. Reservation must be Pending first");
    }
    Status = ReservationStatus.Confirmed;
  }

  public void CheckIn()
  {
    if(Status != ReservationStatus.Confirmed)
    {
      throw new InvalidOperationException("Cannot check in. Reservation must be Confirmed first");
    }
    Status = ReservationStatus.CheckedIn;
  }

  public void CheckOut()
  {
    if(Status != ReservationStatus.CheckedIn)
    {
      throw new InvalidOperationException("Cannot check out. Reservation must be Check In first");
    }
    Status = ReservationStatus.CheckedOut;
  }

  public void Cancel()
  {
    if(Status != ReservationStatus.Pending && Status != ReservationStatus.Confirmed)
    {
      throw new InvalidOperationException("Cannot cancel. Reservation must be Pending or Confirmed first");
    }
    Status = ReservationStatus.Cancelled;
  }
}