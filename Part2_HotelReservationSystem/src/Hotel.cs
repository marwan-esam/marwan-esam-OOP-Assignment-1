using System.ComponentModel;
using System.ComponentModel.Design;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Threading.Channels;

namespace Part2_HotelReservationSystem;

public class Hotel
{
  private readonly List<Room> _rooms;
  private readonly List<Guest> _guests;
  private readonly List<Reservation> _reservations;

  public IReadOnlyList<Room> Rooms => _rooms.AsReadOnly();
  public IReadOnlyList<Guest> Guests => _guests.AsReadOnly();
  public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
  public Hotel()
  {
    _rooms = [];
    _guests = [];
    _reservations = [];
  }

  public void BookRoom(Guest guest, Room room, DateTime checkIn, DateTime checkOut) {
    ArgumentNullException.ThrowIfNull(guest);
    ArgumentNullException.ThrowIfNull(room);

    foreach(Reservation reservation in _reservations)
    {
      if(reservation.Status != ReservationStatus.Cancelled &&
         reservation.Status != ReservationStatus.CheckedOut &&
         reservation.Room.Number == room?.Number &&
         checkIn < reservation.CheckedOutDate && checkOut > reservation.CheckedInDate)
      {
         throw new InvalidOperationException("Room is already booked for those dates");
      }
    }
    Reservation newReservation = new Reservation(Guid.NewGuid(), checkIn, checkOut, room);
    guest.AddReservation(newReservation);
    AddReservation(newReservation);
  }

  public void AddGuest(Guest guest)
  {
    ArgumentNullException.ThrowIfNull(guest);
    
    if(_guests.Contains(guest))
    {
      throw new InvalidOperationException("Cannot add the same guest twice");
    }
    _guests.Add(guest);

  }
  public void AddRoom(Room room)
  {
    ArgumentNullException.ThrowIfNull(room);

    if(_rooms.Contains(room))
    {
      throw new InvalidOperationException("Cannot add the same room twice");
    }
    _rooms.Add(room);
  }
  public void AddReservation(Reservation reservation)
  {
    ArgumentNullException.ThrowIfNull(reservation);

    if(_reservations.Contains(reservation))
    {
      throw new InvalidOperationException("Cannot add the same reservation twice");
    }
    _reservations.Add(reservation);
  }
}