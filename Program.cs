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
            //to load the room details from the file ...
            Room.LoadRoomDetailsFromFile();
            //to list the main menu options ...
            bool exitFlag = false;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Add new room");
                Console.WriteLine("2. View all room");
                Console.WriteLine("3. Reserve a room for a guest");
                Console.WriteLine("4. View all reservations with total cost");
                Console.WriteLine("5. Search reservation by guest name");
                Console.WriteLine("6. Find the highest-paying guest");
                Console.WriteLine("7. Cancel a reservation by room number");
                Console.WriteLine("0. Exit");
                Console.Write("Please select an option: ");

                //to get the user choice ...
                char choice = Validation.CharValidation("option");
                switch (choice)
                {
                    case '1':
                        Room.AddNewRoom();
                        break;
                    case '2':
                        Room.ViewAllRooms();
                        break;
                    case '3':
                        Guest.ReserveRoomForGuest();
                        break;
                    case '4':
                        Guest.ViewAllReservations();
                        break;
                    case '5':
                        Guest.SearchReservationByGuestName();
                        break;
                    case '6':
                        Guest.FindHighestPayingGuest();
                        break;
                    case '7':
                        Guest.CancelReservationByRoomNumber();
                        break;
                    case '0':
                        exitFlag = true;
                        Console.WriteLine("Thank you for using the Hotel System. Goodbye!");
                        // Save room details to file before exiting ...
                        Room.SaveRoomDetailsToFile();
                        // Save guest details to file before exiting ...
                        Guest.SaveGuestDetailsToFile();
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        Additional.HoldScreen();
                        break;
                }
            } while (!exitFlag);

        }
    }
}
