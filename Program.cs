namespace HotelSystemOOP
{
    internal class Program
    {
        //1. HotelRooms to hold the rooms in the hotel ...
        public static List<Room> HotelRooms = new List<Room>();
        //2. HotelGuests to hold the guests in the hotel ...
        public static List<Guest> HotelGuests = new List<Guest>();
        static void Main(string[] args)
        {
            //to call welcome message method ...
            Additional.WelcomeMessage("Hotel");

        }
    }
}
