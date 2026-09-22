namespace Part2_HotelReservationSystem;

public class Program
{
  public static void Main(string[] args)
  {
    Console.WriteLine("=== Hotel Reservation System ===");
    
    Hotel myHotel = new Hotel();
    
    Room room101 = new Room(101, RoomType.Double, 150.00m, false);
    myHotel.AddRoom(room101);
    
    Guest guest1 = new Guest(Guid.NewGuid(), "Marwan", "555-1234");
    myHotel.AddGuest(guest1);

    DateTime checkIn = DateTime.Now.AddDays(1);
    DateTime checkOut = DateTime.Now.AddDays(4);

    myHotel.BookRoom(guest1, room101, checkIn, checkOut);

    Console.WriteLine($"Successfully booked Room {room101.Number} for {guest1.FullName}!");
    Console.WriteLine($"Total Cost will be: ${myHotel.Reservations[0].TotalCost}");
  }
}