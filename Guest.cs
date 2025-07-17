using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystemOOP
{
    class Guest
    {
        //1. class fields ...
        public int GuestID = 0;
        public string GuestName;
        public int GuestPhoneNumber;
        public int NumberOfNights;
        public Room GuestRoom;
        public double TotalCosts;

        //=======================================================
        //2. class properties ...
        public int P_GuestPhoneNumber
        {
            get { return GuestPhoneNumber; }
            set
            {
                //to check if the phone number is 8 digits or not ...
                if (value.ToString().Length == 8)
                    GuestPhoneNumber = value;
                else
                    Console.WriteLine("Phone number must be 8 digits.");
            }
        }

        //=======================================================
        //3. class methods ...
        //to check if their are reserve in the system or not ...
        public static bool GetReserve()
        {
            //to check if there are no reserve available ...
            if (Program.HotelGuests.Count == 0)
            {
                Console.WriteLine("No reserve available in the system yet.");
                return false;
            }
            return true;
        }
        //to reserve a room for a guest ...
        public static void ReserveRoomForGuest()
        {
            //to check if there are no rooms available ...
            if (!Room.AreRoomsAvailable())
            {
                Additional.HoldScreen();//to hold the screen ...
                return;
            }
            else //to list all rooms in the hotel ...
            {
                Room.ViewAllRooms();
            }

            //to book memory place for the guest details ...
            Guest newGuest = new Guest();
            //to get the guest details ...
            newGuest.GuestName = Validation.StringNamingValidation("guest name");
            newGuest.P_GuestPhoneNumber = Validation.IntValidation("guest phone number");
            newGuest.NumberOfNights = Validation.IntValidation("number of nights");
            int roomNumber = Validation.IntValidation("room number");
            //to find the room by room number ...
            newGuest.GuestRoom = Program.HotelRooms.Find(r => r.RoomNumber == roomNumber);
            if (newGuest.GuestRoom == null || !newGuest.GuestRoom.IsAvailable)
            {
                Console.WriteLine("Room not found or not available.");
                return;
            }
            
            //to reserve the room for the guest ...
            newGuest.GuestRoom.IsAvailable = false;
            //to get total cost ...
            newGuest.TotalCosts = newGuest.NumberOfNights * newGuest.GuestRoom.RoomDailyPrice;
            //to save the reserve to HotelGuest list ...
            Program.HotelGuests.Add(newGuest);
            Console.WriteLine($"Room {newGuest.GuestRoom.RoomNumber} reserved for {newGuest.GuestName} successfully\n" +
                              $"with total cost: {newGuest.TotalCosts}");
            Additional.HoldScreen();//to hold the screen ...
        }
        //to view all reservations with total cost
        public static void ViewAllReservations()
        {
            //to check if there are no reserve available ...
            if (!GetReserve())
            {
                Additional.HoldScreen();//to hold the screen ...
                return;
            }
            //to list all reservations ...
            Console.WriteLine("List of all reservations:");
            //to book memory place for the guest details ...
            Guest guestDetails;
            //to loop through all guests in the hotel ...
            for (int i = 0; i < Program.HotelGuests.Count; i++) 
            {
                guestDetails = Program.HotelGuests[i];
                Console.WriteLine(guestDetails.ToString());
                Console.WriteLine("--------------------------------------------------");
            }
            Additional.HoldScreen();//to hold the screen ...
        }
        //to search reservation by guest name ...
        public static void SearchReservationByGuestName()
        {
            //to check if there are no reserve available ...
            if (!GetReserve())
            {
                Additional.HoldScreen();//to hold the screen ...
                return;
            }
            //to get the guest name to search for ...
            string guestName = Validation.StringNamingValidation("guest name to search for");
            //to find the guest by name ...
            Guest foundGuest = Program.HotelGuests.Find(g => g.GuestName == guestName);
            if (foundGuest != null)
            {
                Console.WriteLine(foundGuest.ToString());
            }
            else
            {
                Console.WriteLine("No reservation found for this guest.");
            }
            Additional.HoldScreen();//to hold the screen ...
        }
        //to find the highest-paying guest ...
        public static void FindHighestPayingGuest()
        {
            //to check if there are no reserve available ...
            if (!GetReserve())
            {
                Additional.HoldScreen();//to hold the screen ...
                return;
            }
            //to find the highest-paying guest ...
            Guest highestPayingGuest = Program.HotelGuests.OrderByDescending(g => g.TotalCosts).FirstOrDefault();
            //.OrderByDescending(g => g.TotalCosts) ... to orders the guests by their total cost, from highest to lowest.
            //.FirstOrDefault() ... to get the first guest in the ordered list, which is the highest-paying guest.
            //this line of code will not change the order of the guests in the HotelGuests list.
            if (highestPayingGuest != null)
            {
                Console.WriteLine($"Highest paying guest is: {highestPayingGuest.GuestName} with total cost: {highestPayingGuest.TotalCosts}");
            }
            else
            {
                Console.WriteLine("No reservations found.");
            }
            Additional.HoldScreen();//to hold the screen ...
        }
        //to print ...
        public override string ToString()
        {
            return $"GuestID: {GuestID}\n" +
                   $"Guest Name: {GuestName}\n" +
                   $"Guest Phone Number: {GuestPhoneNumber}\n" +
                   $"Guest Number Of Nights: {NumberOfNights}\n" +
                   $"Guest Room Number: {GuestRoom.RoomNumber}\n" +
                   $"Guset Total Cost: {TotalCosts}";
        }

        //========================================================
        //4. class constructors ...
        public Guest()
        {
            GuestID++;
        }
    }
}
