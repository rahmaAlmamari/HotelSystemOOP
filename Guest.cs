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
        public string GuestPhoneNumber;
        public int NumberOfNights;
        public Room GuestRoom;
        //2. class properties ...
        //3. class methods ...
        //4. class constructors ...
        public Guest()
        {
            GuestID++;
        }
    }
}
