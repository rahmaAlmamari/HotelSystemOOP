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
        public int RoomNumber = 0;
        public double RoomDailyPrice;
        public bool IsAvailable = true;
        //2. class properties ...
        //3. class methods ...
        //to add a new room ...
        public static void AddNewRoom()
        {
            Room newRoom = new Room();
            newRoom.RoomDailyPrice = Validation.DoubleValidation("daily price");
            Program.HotelRooms.Add(newRoom);
            Console.WriteLine($"Room {newRoom.RoomNumber} added successfully with daily price {newRoom.RoomDailyPrice}");
            Additional.HoldScreen();//to hold the screen ...
        }
        //4. class constructors ...
        public Room()
        {
            RoomNumber++;
        }
    }
}
