using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystemOOP
{
    //This class is used to validate user input ...
    class Validation
    {
        //1. CharValidation method ...
        public static char CharValidation(string message)
        {
            bool CharFlag;//to handle user char error input ...
            char CharInput = '0';
            do
            {
                try
                {
                    CharFlag = false;
                    Console.WriteLine($"Enter your {message}:");
                    CharInput = char.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Your {message} not accepted due to: " + e.Message);
                    CharFlag = true;
                }

            } while (CharFlag);

            //to return tne char input ...
            return CharInput;
        }
        //2. StringNamingValidation method ...
        public static string StringNamingValidation(string message)
        {
            bool StringNamingFlag;//to handle user StringNaming error input ...
            string StringNamingInput = "null";
            do
            {
                StringNamingFlag = false;
                Console.WriteLine($"Enter your {message}:");
                StringNamingInput = Console.ReadLine();
                //to check if StringNamingInput has number or not ...
                bool check_StringNaming = Additional.IsAlpha(StringNamingInput);
                if (check_StringNaming == false)
                {
                    Console.WriteLine($"{message} can not contains number and con not be null ..." +
                                      "please prass enter key to try again");
                    Additional.HoldScreen();//just to hold a second ...
                    StringNamingFlag = true;
                }

            } while (StringNamingFlag);

            //to return tne char input ...
            return StringNamingInput;
        }
        //3. StringValidation method ...
        public static string StringValidation(string message)
        {
            bool StringFlag;//to handle user StringNaming error input ...
            string StringInput = "null";
            do
            {
                StringFlag = false;
                Console.WriteLine($"Enter your {message}:");
                StringInput = Console.ReadLine();
                // Check if StringInput null or empty
                if (string.IsNullOrWhiteSpace(StringInput))
                {
                    Console.WriteLine($"{message} cannot be empty.");
                    Additional.HoldScreen();//just to hoad second ...
                    StringFlag = true;
                }

            } while (StringFlag);

            //to return tne char input ...
            return StringInput;
        }
        //4. DoubleValidation method ...
        public static double DoubleValidation(string message)
        {
            bool DoubleFlag;//to handle user StringNaming error input ...
            double DoubleInput = 0;
            do
            {
                DoubleFlag = false;
                try
                {
                    Console.WriteLine($"Enter your {message}:");
                    DoubleInput = double.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{message} not accepted due to " + e.Message);
                    Console.WriteLine("please prass enter key to try again");
                    Additional.HoldScreen();//just to hold a second ...
                    DoubleFlag = true;
                }

            } while (DoubleFlag);
            //to return tne char input ...
            return DoubleInput;
        }
        //5. IntValidation method ...
        public static int IntValidation(string message)
        {
            bool IntFlag;//to handle user StringNaming error input ...
            int IntInput = 0;
            do
            {
                IntFlag = false;
                try
                {
                    Console.WriteLine($"Enter {message}:");
                    IntInput = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{message} not accepted due to " + e.Message);
                    Additional.HoldScreen();//just to hold a second ...
                    IntFlag = true;
                }

            } while (IntFlag);
            //to return tne char input ...
            return IntInput;
        }
        //6. DateTimeValidation method ...
        public static DateTime DateTimeValidation(string message)
        {
            bool DateTimeFlag; // to handle user DateTime error input
            DateTime DateTimeInput = DateTime.Now;

            do
            {
                DateTimeFlag = false;
                try
                {
                    Console.WriteLine($"Enter your {message} (format: MM/dd/yyyy):");
                    DateTimeInput = DateTime.Parse(Console.ReadLine());

                    //// Check if the date is in the future or today
                    //if (DateTimeInput.Date > DateTime.Now.Date)
                    //{
                    //    Console.WriteLine($"{message} should be a date valid.");
                    //    HoldScreen(); // just to hold a second
                    //    DateTimeFlag = true; // ask user again
                    //}
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{message} not accepted due to: " + e.Message);
                    Additional.HoldScreen(); // just to hold a second
                    DateTimeFlag = true; // ask user again
                }
            } while (DateTimeFlag);

            return DateTimeInput; // Return the validated input
        }
        //7. DateOnlyValidation method ...
        public static DateOnly DateOnlyValidation(string message)
        {
            bool DateTimeFlag; // to handle user DateTime error input
            DateOnly DateTimeInput = DateOnly.FromDateTime(DateTime.Now);

            do
            {
                DateTimeFlag = false;
                try
                {
                    Console.WriteLine($"Enter your {message} (format: MM/dd/yyyy):");
                    DateTimeInput = DateOnly.Parse(Console.ReadLine());

                    //// Check if the date is in the future or today
                    //if (DateTimeInput.Date > DateTime.Now.Date)
                    //{
                    //    Console.WriteLine($"{message} should be a date valid.");
                    //    HoldScreen(); // just to hold a second
                    //    DateTimeFlag = true; // ask user again
                    //}
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{message} not accepted due to: " + e.Message);
                    Additional.HoldScreen(); // just to hold a second
                    DateTimeFlag = true; // ask user again
                }
            } while (DateTimeFlag);

            return DateTimeInput; // Return the validated input
        }
    }
}
