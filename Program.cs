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
                Console.WriteLine("7. Cancel a reservation by room number ");
                Console.WriteLine("0. Exit");
                Console.Write("Please select an option: ");

                //to get the user choice ...
                char choice = Validation.CharValidation("option");
                switch (choice)
                {
                    case '1':
                        Console.WriteLine("1");
                        Additional.HoldScreen();
                        //Room.AddRoom();
                        break;
                    case '2':
                        Console.WriteLine("2");
                        Additional.HoldScreen();
                        //Guest.AddGuest();
                        break;
                    case '3':
                        Console.WriteLine("3");
                        Additional.HoldScreen();
                        //Room.ShowRooms();
                        break;
                    case '4':
                        Console.WriteLine("4");
                        Additional.HoldScreen();
                        //Guest.ShowGuests();
                        break;
                    case '5':
                        Console.WriteLine("5");
                        Additional.HoldScreen();
                        //Room.ReserveRoom();
                        break;
                    case '6':
                        Console.WriteLine("6");
                        Additional.HoldScreen();
                        //Guest.SearchReservation();
                        break;
                    case '7':
                        Console.WriteLine("7");
                        Additional.HoldScreen();
                        //Room.CancelReservation();
                        break;
                    case '0':
                        exitFlag = true;
                        Console.WriteLine("Thank you for using the Hotel System. Goodbye!");
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
