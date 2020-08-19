using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public static class UserInterface
    {
        
        public static int DisplayUserOptions()
        {
            Console.WriteLine("Welcome to the soda machine! What would you like to do?");
            Console.WriteLine("1. Display soda options");
            Console.WriteLine("2. Check wallet");
            Console.WriteLine("3. Select soda");
            int userInput = int.Parse(Console.ReadLine());
            return userInput;
        }
        public static void GetUserInput()
        {

        }
        public static void ValidateUserInput() // UserInterface
        {

        }

    }
}
