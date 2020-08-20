using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        public Wallet wallet;
        public Backpack backpack;
        int intInput;
        string stringInput;

        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack();
            intInput = 0;
        }
        public int CheckCoinCount(string input)
        {
            int counter = 0;

            foreach (Coin coin in wallet.coins)
            {
                if (input == coin.name)
                {
                    counter++;
                }
            }


            return counter;

        }

        public List<Coin> SelectCoins(Wallet wallet)
        {
            bool choiceComplete = false;
            List<Coin> payment = new List<Coin>();           
            while(choiceComplete == false)
            {
                stringInput = UserInterface.GetUserInputString("Which type of coins would you like to use?");
                ValidateCoinSelectionInput(stringInput);
                intInput = UserInterface.GetUserInputInt("How many of those coins would you like to use?");
                
                for (int i = 0; i < intInput; i++)
                {
                    if (CheckCoinCount(stringInput) < intInput)
                    {
                        UserInterface.InsufficientFunds();
                        break;
                    }
                    else
                    {
                        foreach (Coin coin in wallet.coins)
                        {
                            if (stringInput == coin.name)
                            {
                                payment.Add(coin);
                                break;
                            }
                        }

                    }
                    


                }
                stringInput = UserInterface.GetUserInputString("Do you want to select again?");

                if (stringInput == "Yes")
                {
                    continue;
                }
                else
                {
                    choiceComplete = true;
                }


            }
            RemovePaymentFromWallet(payment);
            return payment;

        }

        

        public void ValidateCoinSelectionInput(string input)
        {
            bool inputValid = false;

            while (inputValid == false)
            {
                for (int i = 0; i < wallet.coins.Count; i++)
                {
                    if (wallet.coins[i].name == input)
                    {
                        inputValid = true;
                        stringInput = input;
                    }

                }
                if (inputValid == false)
                {
                    input = UserInterface.GetUserInputString("Invalid choice! Please select again!");
                    
                }
            }
        }

        private void RemovePaymentFromWallet(List<Coin> payment)
        {
            foreach (Coin coin in payment)
            {
                wallet.coins.Remove(coin);
            }

        }

        public void AddChangeToWallet(List<Coin> change)
        {
            foreach (Coin coin in change)
            {
                wallet.coins.Add(coin);
            }

        }

        
        public void AddSodaToBackpack(Can can)
        {
            backpack.cans.Add(can);
        }
 
    }
}
