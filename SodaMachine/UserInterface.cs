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
        public static void DisplaySodaInventory(List<Can> inventory)
        {
            int count = 0;
            
            for (int i = 0; i < inventory.Count; i++) 
            {
                if (i == 0)
                {
                    count++;
                    Console.WriteLine($"{count}: {inventory[i].name}\n");


                }
                else if (inventory[i].name != inventory[i - 1].name)
                {
                    count++;
                    Console.WriteLine($"{count}: {inventory[i].name}\n");

                }
                else
                {
                    continue;
                }
               

            }
            // List<string> names = inventory.Select(i => i.name).Distinct();
            // see page re: Language-Integrated Query (from David DM)

        }

        public static void DisplayCoins(List<Coin> coins)
        {
            //As a customer, I want to see all of the coins in my wallet. How many of each, and total money
            // available
            double totalAvailable = 0;
            string coinTypes = "";
            
            foreach (Coin coin in coins)
            {
                totalAvailable += coin.Value;
                if (coinTypes.Contains(coin.name) == false)
                {
                    coinTypes += coin.name + "," + "";
                }

            }

            Console.WriteLine($"You have ${totalAvailable} in your wallet");
            Console.WriteLine($"In {coinTypes} .");

        }


    }
}
