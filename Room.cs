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
        //4. class constructors ...
        public Room()
        {
            RoomNumber++;
        }
    }
}
