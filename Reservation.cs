using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystemOOP
{
    class Reservation
    {
        //1. class Reservation feild ...
        public static int ReservationCounter = 0; //to hold the reservation counter ...
        public int ReservationId;
        public int GuestID;
        public DateOnly CheckIn;
        public DateOnly CheckOut;

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
