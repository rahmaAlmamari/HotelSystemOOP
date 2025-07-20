using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystemOOP
{
    //this class deals with the guest details and reservations in the hotel system ...
    class Guest
    {
        //1. class fields ...
        public static int GuestID = 0;
        public string GuestName;
        public int GuestPhoneNumber;
        public int NumberOfNights;
        public Room GuestRoom;
        public double TotalCosts;

        //to hold file path for saving guest details ...
        public static string filePath = "guests.txt";

        //=======================================================
        //2. class properties ...
        public int P_GuestPhoneNumber
        {
            get { return GuestPhoneNumber; }
            set
            {
                bool FalgError = false; //to handle the error ...
                do
                {
                    FalgError = false; //to reset the error flag ...
                    //to check if the phone number is 8 digits or not ...
                    if (value.ToString().Length == 8)
                    {
                        GuestPhoneNumber = value;
                    }   
                    else
                    {
                        Console.WriteLine("Phone number must be 8 digits.");
                        value = Validation.IntValidation("guest phone number");
                        FalgError = true; //to handle the error ...
                    }
                        
                } while (FalgError);

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
                Additional.HoldScreen();//to hold the screen ...
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
            Guest foundGuest = Program.HotelGuests.Find(g => g.GuestName.ToLower() == guestName.ToLower());
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
        //to cancel a reservation by room number ...
        public static void CancelReservationByRoomNumber()
        {
            //to check if there are no reserve available ...
            if (!GetReserve())
            {
                Additional.HoldScreen();//to hold the screen ...
                return;
            }
            //to get the room number to cancel reservation for ...
            int roomNumber = Validation.IntValidation("room number to cancel reservation for");
            //to find the guest by room number ...
            Guest foundGuest = Program.HotelGuests.Find(g => g.GuestRoom.RoomNumber == roomNumber);
            if (foundGuest != null)
            {
                //to confirm the cancellation ...
                if (Additional.ConfirmAction("cancel reservation"))
                {
                    foundGuest.GuestRoom.IsAvailable = true; //to make the room available again
                    Program.HotelGuests.Remove(foundGuest); //to remove the guest from the list
                    Console.WriteLine($"Reservation for {foundGuest.GuestName} in room {roomNumber} cancelled successfully.");
                }
                else
                {
                    Console.WriteLine("Cancel process stoped.");
                }
            }
            else
            {
                Console.WriteLine("No reservation found for this room number.");
            }
            Additional.HoldScreen();//to hold the screen ...
        }
        //to print ...
        public override string ToString()
        {
            return $"Guest ID: {GuestID}\n" +
                   $"Guest Name: {GuestName}\n" +
                   $"Guest Phone Number: {GuestPhoneNumber}\n" +
                   $"Guest Number Of Nights: {NumberOfNights}\n" +
                   $"Guest Room Number: {GuestRoom.RoomNumber}\n" +
                   $"Guset Total Cost: {TotalCosts}\n" +
                   $"-----------------------------------------------";
        }
        //to save the guest details to a file ...
        public static void SaveGuestDetailsToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Guest guest in Program.HotelGuests)
                    {
                        writer.WriteLine(guest.ToString());
                    }
                }
                Console.WriteLine("Guest details saved to file successfully.");
                Additional.HoldScreen();//just to hold second ...
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving guest details to file: {ex.Message}");
                Additional.HoldScreen();//just to hold second ...
            }

        }
        //to load the guest details from a file ...
        public static void LoadGuestDetailsFromFile()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    //int count = 0;
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line1 = reader.ReadLine(); // Guest ID
                            string line2 = reader.ReadLine(); // Guest Name
                            string line3 = reader.ReadLine(); // Guest Phone Number
                            string line4 = reader.ReadLine(); // Guest Number Of Nights
                            string line5 = reader.ReadLine(); // Guest Room Number
                            string line6 = reader.ReadLine(); // IGuset Total Cost
                            string separator = reader.ReadLine(); // Separator (e.g. "----")

                            if (line1 != null && line2 != null && line3 != null && line4 != null && line5 != null && line6 != null)
                            {
                                Guest guest = new Guest();
                                guest.GuestID = int.Parse(line1.Split(':')[1].Trim());
                                guest.GuestName = line2.Split(':')[1].Trim();
                                guest.P_GuestPhoneNumber = int.Parse(line3.Split(':')[1].Trim());
                                guest.NumberOfNights = int.Parse(line4.Split(':')[1].Trim());
                                int roomNumber = int.Parse(line5.Split(':')[1].Trim());
                                guest.GuestRoom = Program.HotelRooms.Find(r => r.RoomNumber == roomNumber);
                                if (guest.GuestRoom != null)
                                {
                                    // Mark the room as reserved
                                    guest.GuestRoom.IsAvailable = false; 
                                    int index = Program.HotelRooms.IndexOf(guest.GuestRoom);
                                    //to update the room in the list ...
                                    Program.HotelRooms[index].IsAvailable = false; // Mark the room as reserved

                                }
                                guest.TotalCosts = double.Parse(line6.Split(':')[1].Trim());
                                Program.HotelGuests.Add(guest); // Add the guest to the list
                            }
                        }
                    }
                    Console.WriteLine("Hotel guests details loaded successfully.");
                    Additional.HoldScreen();//just to hold second ...
                }
                else
                {
                    Console.WriteLine("No saved guests details found.");
                    Additional.HoldScreen();//just to hold second ...
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading guests details: " + ex.Message);
                Additional.HoldScreen();//just to hold second ...
            }
        }

        //========================================================
        //4. class constructors ...
        public Guest()
        {
            GuestID++;
        }
    }
}
