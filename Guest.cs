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
        //3. class methods ...
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
            Program.HotelGuests.Add(newGuest);
            Console.WriteLine($"Room {newGuest.GuestRoom.RoomNumber} reserved for {newGuest.GuestName} successfully.");
            Additional.HoldScreen();//to hold the screen ...
        }
        //4. class constructors ...
        public Guest()
        {
            GuestID++;
        }
    }
}
