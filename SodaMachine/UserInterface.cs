using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public static class UserInterface
    {
        public static int GetUserInputInt(string prompt)
        {
            Console.WriteLine(prompt);
            int input = int.Parse(Console.ReadLine());
            return input;

        }
        public static string GetUserInputString(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            return input;
        }

        public static void ValidateUserInput()
        {
            // wait until everything is working before implementing. Assume all user input is perfectu
            // until then
        }

        public static int DisplayUserOptions()
        {
            Console.WriteLine("Welcome to the soda machine! What would you like to do?");
            Console.WriteLine("1. Display soda options");
            Console.WriteLine("2. Check wallet");
            Console.WriteLine("3. Select soda");
            int userInput = int.Parse(Console.ReadLine());
            return userInput;
        }
        
        
        public static void DisplaySodaInventory(List<Can> inventory)
        {

            
            for (int i = 0; i < inventory.Count; i++) // need to refactor to only show available types of sodas
            {
                if (i == 0)
                {
                    Console.WriteLine($"{inventory[i].name}\n");


                }
                else if (inventory[i].name != inventory[i - 1].name)
                {
                    Console.WriteLine($"{inventory[i].name}\n");

                }
                else
                {
                    continue;
                }
               

            }
            //List<string> names = inventory.Select(i => i.name).Distinct(); 


        }


    }
}
