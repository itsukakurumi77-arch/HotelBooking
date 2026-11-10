var rooms = new List<Room>
{
    new Room { Number = 101, Price = 50 },
    new Room { Number = 102, Price = 50 },
    new Room { Number = 201, Price = 80 },
    new Room { Number = 202, Price = 120 },
};

while (true)
{
    Console.WriteLine("\n--- Hotel Booking ---");
    Console.WriteLine("1. View rooms");
    Console.WriteLine("2. Book a room");
    Console.WriteLine("3. Cancel a booking");
    Console.WriteLine("0. Exit");
    Console.Write("Choose: ");
    string? choice = Console.ReadLine();

    if (choice == "0") break;

    if (choice == "1")
    {
        foreach (var r in rooms)
            Console.WriteLine($"Room {r.Number} - ${r.Price}/night - " +
                              (r.Guest == null ? "Available" : $"Booked by {r.Guest}"));
    }
    else if (choice == "2" || choice == "3")
    {
        Console.Write("Room number: ");
        int.TryParse(Console.ReadLine(), out int number);
        var room = rooms.Find(r => r.Number == number);

        if (room == null)
            Console.WriteLine("Room not found.");
        else if (choice == "2")
        {
            if (room.Guest != null)
                Console.WriteLine("Sorry, that room is already booked.");
            else
            {
                Console.Write("Your name: ");
                room.Guest = Console.ReadLine();
                Console.WriteLine("Room booked!");
            }
        }
        else
        {
            room.Guest = null;
            Console.WriteLine("Booking cancelled.");
        }
    }
    else
    {
        Console.WriteLine("Invalid choice.");
    }
}

class Room
{
    public int Number { get; set; }
    public int Price { get; set; }
    public string? Guest { get; set; }
}