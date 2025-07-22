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
