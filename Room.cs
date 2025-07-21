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
        //list to store the room reserveation ...
        public static List<Reservation> RoomReservations = new List<Reservation>();

        //to hold the file path for saving room details ...
        public static string filePath = "rooms.txt";

        //======================================================================
        //2. class properties ...
        public double P_RoomDailyPrice
        {
            get { return RoomDailyPrice; }
            set
            {
                //to check if the room daily price is less than 100 or not ...
                bool FlagError = false; //to handle the error ...
                do
                {
                    FlagError = false; //to reset the error flag ...
                    if (value < 100)
                    {
                        Console.WriteLine("Room daily price must be > 100.");
                        value = Validation.DoubleValidation("daily price");
                        FlagError = true; //to handle the error ...
                    }
                    RoomDailyPrice = value;
                } while (FlagError);

            }
        }

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
            newRoom.P_RoomDailyPrice = Validation.DoubleValidation("daily price");
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
            }
            Additional.HoldScreen();//to hold the screen ...
        }
        //to print ...
        public override string ToString()
        {
            return $"Room Number: {RoomNumber}\n" +
                   $"Room Daily Price: {P_RoomDailyPrice}\n" +
                   $"Room Is Available: {IsAvailable}\n" +
                   $"------------------------------------------";
        }
        //to save the room details to a file ...
        public static void SaveRoomDetailsToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Room room in Program.HotelRooms)
                    {
                        writer.WriteLine(room.ToString());
                    }
                }
                Console.WriteLine("Hotel room details saved successfully.");
                Additional.HoldScreen();//just to hold second ...
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving room details: " + ex.Message);
                Additional.HoldScreen();//just to hold second ...
            }

        }
        //to load room details from a file ...
        public static void LoadRoomDetailsFromFile()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    //to clear the previous room details ...
                    Program.HotelRooms.Clear();
                    //int count = 0;
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line1 = reader.ReadLine(); // Room Number
                            string line2 = reader.ReadLine(); // Room Daily Price
                            string line3 = reader.ReadLine(); // IsAvailable
                            string separator = reader.ReadLine(); // Separator (e.g. "----")

                            if (line1 != null && line2 != null && line3 != null)
                            {
                                Room room = new Room();
                                room.RoomNumber = int.Parse(line1.Split(':')[1].Trim());
                                room.P_RoomDailyPrice = double.Parse(line2.Split(':')[1].Trim());
                                room.IsAvailable = bool.Parse(line3.Split(':')[1].Trim());

                                //code explaintion:
                                //parts[0] => "Room Number: 101"
                                //parts[0].Split(':') => ["Room Number", " 101"]
                                //parts[0].Split(':')[1] => " 101"
                                //parts[0].Split(':')[1].Trim() => "101" ... Trim() to remove any leading or trailing spaces

                                Program.HotelRooms.Add(room);
                                //count++;
                            }
                        }
                    }
                    Console.WriteLine("Hotel room details loaded successfully.");
                    Additional.HoldScreen();//just to hold second ...
                }
                else
                {
                    Console.WriteLine("No saved room details found.");
                    Additional.HoldScreen();//just to hold second ...
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading room details: " + ex.Message);
                Additional.HoldScreen();//just to hold second ...
            }
        }



        //=====================================================================
        //4. class constructors ...
        public Room() 
        {
            RoomCounter++;
            RoomNumber = RoomCounter + 100; // Assign a unique room number
        }
    }
}
