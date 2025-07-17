using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystemOOP
{
    class Room
    {
        //1. class fields ...
        private static int RoomCounter = 0;
        public int RoomNumber;
        public double RoomDailyPrice;
        public bool IsAvailable = true;

        //======================================================================
        //2. class properties ...

        //======================================================================
        //3. class methods ...
        //to check if their are rooms in the system or not ...
        public static bool AreRoomsAvailable()
        {
            //to check if there are no rooms available ...
            if (Program.HotelRooms.Count == 0)
            {
                Console.WriteLine("No rooms available in the system yet.");
                return false;
            }
            return true;
        }
        //to add a new room ...
        public static void AddNewRoom()
        {
            Room newRoom = new Room();
            newRoom.RoomDailyPrice = Validation.DoubleValidation("daily price");
            Program.HotelRooms.Add(newRoom);
            //Console.WriteLine($"Room {newRoom.RoomNumber} added successfully with daily price {newRoom.RoomDailyPrice}");
            Console.WriteLine("Room add successfully with following details:");
            Console.WriteLine(newRoom.ToString());
            Additional.HoldScreen();//to hold the screen ...
        }
        //to view all rooms ...
        public static void ViewAllRooms()
        {
            //to check if there are no rooms available ...
            if(!AreRoomsAvailable())
            {
                Additional.HoldScreen();//to hold the screen ...
                return;
            }
            //to list all rooms ...
            //to book memory place for the room details ...
            Room RoomDetails;
            Console.WriteLine("List of all rooms:");
            //to loop through all rooms in the hotel ...
            for (int i = 0; i < Program.HotelRooms.Count; i++)
            {
                RoomDetails = Program.HotelRooms[i];
                //Console.WriteLine($"Room Number: {Program.HotelRooms[i].RoomNumber}\n" +
                //                  $"Room Daily Price: {Program.HotelRooms[i].RoomDailyPrice}\n" +
                //                  $"Room Is Available: {Program.HotelRooms[i].IsAvailable}\n");
                //Console.WriteLine("--------------------------------------------------");
                //to print the room details ...
                Console.WriteLine(RoomDetails.ToString());
                Console.WriteLine("--------------------------------------------------");
            }
            Additional.HoldScreen();//to hold the screen ...
        }
        //to print ...
        public override string ToString()
        {
            return $"Room Number: {RoomNumber}\n" +
                   $"Room Daily Price: {RoomDailyPrice}\n" +
                   $"Room Is Available: {IsAvailable}\n";
        }

        //=====================================================================
        //4. class constructors ...
        public Room() 
        {
            RoomCounter++;
            RoomNumber = RoomCounter; // Assign a unique room number
        }
    }
}
