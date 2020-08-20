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

        public static void InsufficientFunds(List<Coin> payment)
        {
            Console.WriteLine($"{UserInterface.CalculateTotal(payment)} is not enough!");
        }

        public static void DisplayBackPackContents(List<Can> cans)
        {
            for (int i = 0; i < cans.Count; i++)
            {
                Console.WriteLine("Here are the contents of your bookbag!");
                Console.WriteLine($"{cans[i].name}");
            }
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
                    Console.WriteLine($"{count}: {inventory[i].name} {inventory[i].Cost}\n");


                }
                else if (inventory[i].name != inventory[i - 1].name)
                {
                    count++;
                    Console.WriteLine($"{count}: {inventory[i].name} {inventory[i].Cost}\n");

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

        public static double CalculateTotal(List<Coin> coins)
        {
            double totalPayment = 0;

            foreach (Coin coin in coins)
            {
                totalPayment += coin.Value;
            }

            return totalPayment;

        }

        


    }
}
