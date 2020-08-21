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
            bool inputSuccess = false;
            int input = 0;

            while (inputSuccess == false)
            {
                Console.WriteLine(prompt);
                inputSuccess = int.TryParse(Console.ReadLine(), out input);
                if (inputSuccess == false)
                {
                    Console.WriteLine("I didn't recognize that input. Please try again!\n");

                }
            }

            return input;

        }
        public static string GetUserInputString(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            return input;
        }

        public static void InsufficientFunds()
        {
            Console.WriteLine($"You don't have enough funds!\n");
        }

        public static void InsufficientInventory()
        {
            Console.WriteLine("There is not enough of your soda choice in our inventory! So sorry.\n");
        }

        public static void DisplayBackPackContents(List<Can> cans)
        {
            for (int i = 0; i < cans.Count; i++)
            {
                Console.WriteLine("Here are the contents of your bookbag!\n");
                Console.WriteLine($"{cans[i].name}\n");
            }
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
                    coinTypes += coin.name + ",";
                }

            }

            Console.WriteLine($"You have ${totalAvailable} in your wallet\n");
            Console.WriteLine($"Coin Types: {coinTypes}\n");

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

        public static bool ValidateTwoSelections(bool one, bool two)
        {
            bool bothTrue = false;
            if (one == true && two == true)
            {
                bothTrue = true;
            }
            else
            {
                Console.WriteLine("Oh no! Your selections are invalid. Please try again!\n");
            }

            return bothTrue;
        }

        public static void InsufficientChange()
        {
            Console.WriteLine("Oh no! We're out of change. Transaction unsuccessful.\n");
        }

        public static void TransactionFailed()
        {
            Console.WriteLine("Transaction failed! Please try again.");
        }

      



    }
}
