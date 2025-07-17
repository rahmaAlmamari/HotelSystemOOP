using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelSystemOOP
{
    //This class is used to hold additional methods that are used in the system ...
    class Additional
    {
        //1. To hoad the screen ...
        public static void HoldScreen()
        {
            Console.WriteLine("Press (Enter Kay) to continue");
            Console.ReadLine();
        }
        //2. To check of the string contains something other than letters like number and empty space(this methos return true or false)....
        public static bool IsAlpha(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z]+$");
        }
        //3. WelcomeMessage method ...
        public static void WelcomeMessage(string message)
        {
            Console.WriteLine($"Welcome to Codeline {message} System\nWe hope you have a pleasant time using our services " +
                              "(^0^)");
            HoldScreen();//to hold the screen ...
        }
        //4. ConfirmAction method ...
        public static bool ConfirmAction(string action)
        {
            //confirm process ...
            bool flag_action;//to know if the user enter choice or not
            char actionChoice = 'y';
            bool actionStatus;//to set the confirm action status true/false ...
            do
            {
                flag_action = false;
                try
                {
                    Console.WriteLine($"“Are you sure to {action} ? Y/N");
                    actionChoice = char.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please confirm your action");
                    flag_action = true;
                }
            } while (flag_action);

            if (actionChoice == 'Y' || actionChoice == 'y')
            {
                actionStatus = true;
            }
            else
            {
                actionStatus = false;
            }

            return actionStatus;
        }
    }
}
