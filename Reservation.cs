using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystemOOP
{
    class  Reservation
    {
        //1. class Reservation feild ...
        public static int ReservationCounter = 0; //to hold the reservation counter ...
        public int ReservationId;
        public int GuestID;
        public DateOnly CheckIn;
        public DateOnly CheckOut;

        //to hold file path for saving reservation details ...
        public static string filePath = "reservation.txt";

        //2. class Reservation properity ...
        //3. class Reservation method ...
        //to print the reservation details ...
        public override string ToString()
        {
            return $"Reservation Id: {ReservationId}\n" +
                   $"Guest ID: {GuestID}\n" +
                   $"Check In Date: {CheckIn}\n" +
                   $"Check Out Date: {CheckOut}\n" +
                   $"-----------------------------------------------";
        }
        //to save Reservation to file ...
        public static void SaveReservationDetailsToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Room room in Program.HotelRooms)
                    {
                        foreach (Reservation reservation in room.RoomReservations)
                        {
                            writer.WriteLine(reservation.ToString());
                        }
                    }
                }
                Console.WriteLine("Reservation details saved to file successfully.");
                Additional.HoldScreen();//just to hold second ...
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving Reservation details to file: {ex.Message}");
                Additional.HoldScreen();//just to hold second ...
            }

        }
        //to load Reservation details from file ...
        public static void LoadReservationDetailsFromFile()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    Program.HotelRooms.Clear();
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line1 = reader.ReadLine(); // Reservation Id
                            string line2 = reader.ReadLine(); // Guest ID
                            string line3 = reader.ReadLine(); // Check In Date
                            string line4 = reader.ReadLine(); // Check Out Date
                            string separator = reader.ReadLine(); // Separator (e.g. "----")
                            if (line1 != null && line2 != null && line3 != null && line4 != null)
                            {
                                Reservation reservation = new Reservation();
                                reservation.ReservationId = int.Parse(line1.Split(':')[1].Trim());
                                reservation.GuestID = int.Parse(line2.Split(':')[1].Trim());
                                reservation.CheckIn = DateOnly.Parse(line3.Split(':')[1].Trim());
                                reservation.CheckOut = DateOnly.Parse(line4.Split(':')[1].Trim());
                                // Add the reservation to the corresponding room's reservations list
                                Guest guest = Program.HotelGuests.FirstOrDefault(r => r.GuestID == reservation.GuestID);
                                if (guest != null)
                                {
                                    Room room = Program.HotelRooms.FirstOrDefault(r => r.RoomNumber == guest.GuestRoom.RoomNumber);
                                    room.RoomReservations.Add(reservation);
                                }
                            }
                        }
                    }
                    Console.WriteLine("Reservation details loaded from file successfully.");
                    Additional.HoldScreen();//just to hold second ...
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Reservation details from file: {ex.Message}");
                Additional.HoldScreen();//just to hold second ...
            }
        }
        public void PrintReservationDetails()
        {
            Console.WriteLine($"Reservation ID: {ReservationId}\n" +
                              $"Guest ID: {GuestID}\n" +
                              $"Check-In Date: {CheckIn}\n" +
                              $"Check-Out Date: {CheckOut}\n" +
                              $"---------------------------------------");

        }
        //4. class Reservation constructor ...
        public Reservation()
        {
            ReservationCounter++;
            ReservationId = ReservationCounter;
        }
    }
}
