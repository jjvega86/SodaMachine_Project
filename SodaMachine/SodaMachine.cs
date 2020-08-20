using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        public List<Coin> register;
        public List<Can> inventory;
        string userSelection;
        int userSelectionIndex;
        public List<Coin> customerChange;

        public SodaMachine()
        {
            register = new List<Coin>();
            AddInitialCoinsToRegister(new Quarter(), 20);
            AddInitialCoinsToRegister(new Dime(), 10);
            AddInitialCoinsToRegister(new Nickel(), 20);
            AddInitialCoinsToRegister(new Penny(), 50);           
            inventory = new List<Can>();
            AddInitialCansToInventory(new Cola(), 25);
            AddInitialCansToInventory(new OrangeSoda(), 25);
            AddInitialCansToInventory(new RootBeer(), 25);

            userSelection = "";
            userSelectionIndex = 0;
            customerChange = new List<Coin>();
        }

        private void AddInitialCoinsToRegister(Coin coin, int count)
        {
            for (int i = 0; i < count; i++)
            {
                register.Add(coin);
            }
        }

        private void AddInitialCansToInventory(Can can, int count)
        {
            for (int i = 0; i < count; i++)
            {
                inventory.Add(can);
            }

        }

        private void AddPaymentToRegister(List<Coin> payment)
        {
            for (int j = 0; j < payment.Count; j++)
            {
                register.Add(payment[j]);

            }
        }
        public string SelectSoda()
        {
            string stringInput = UserInterface.GetUserInputString("Please pick the soda you would like!");

            bool inputValid = false;

            while (inputValid == false)
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].name == stringInput)
                    {
                        inputValid = true;
                        break;
                    }

                }
                if (inputValid == false)
                {
                    stringInput = UserInterface.GetUserInputString("Choice invalid! Do you want to select again?");

                }
            }
            return stringInput;
        }

        public bool ValidateSodaSelection(string input) 
        {            
            bool selectionSuccess = false;
            while (selectionSuccess == false)
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (input == inventory[i].name)
                    {
                        userSelectionIndex = i;
                        userSelection = input;
                        selectionSuccess = true;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                    
                }
            }
            
            return selectionSuccess;
        }

        public bool ValidateUserPayment(List<Coin> payment)
        {
            bool paymentSuccess = false;
            if (register.Count == 0)
            {
                UserInterface.InsufficientChange();
                GiveMoneyBack(payment);


            }           
            else if (inventory[userSelectionIndex].Cost > UserInterface.CalculateTotal(payment))
            {
                GiveMoneyBack(payment);
                UserInterface.InsufficientFunds();
                UserInterface.DisplayCoins(customerChange);

            }
            else if (inventory[userSelectionIndex].Cost == UserInterface.CalculateTotal(payment))
            {
                CompleteTransaction(payment, userSelection);
                paymentSuccess = true;
            }

            else if (inventory[userSelectionIndex].Cost < UserInterface.CalculateTotal(payment))
            {
                MakeChange(payment);
                CompleteTransaction(payment, userSelection);
                paymentSuccess = true;

            }

            


            return paymentSuccess;

        }

        public List<Coin> MakeChange(List<Coin> payment)
        {
            double changeAmount = UserInterface.CalculateTotal(payment) - inventory[userSelectionIndex].Cost;

            for (int i = 0; i < register.Count; i++)
            {
                if (changeAmount == 0)
                {
                    break;
                }
                else if (changeAmount > register[i].Value)
                {
                    customerChange.Add(register[i]);
                    changeAmount -= register[i].Value;

                }                              
                else
                {
                    continue;
                }


            }
            RemoveChangeFromRegister(customerChange);
            return customerChange;
        }

        public void GiveMoneyBack(List<Coin> payment)
        {
            foreach (Coin coin in payment)
            {
                customerChange.Add(coin);
            }
        }

        private void RemoveChangeFromRegister(List<Coin> change)
        {
            foreach (Coin coin in change)
            {
                register.Remove(coin);
            }
        }
 

        public void CompleteTransaction(List<Coin> payment, string input)
        {
            AddPaymentToRegister(payment);
            userSelection = input;
        }


        

        public Can DispenseSoda(bool transactionSuccess)
        {
            int index = 0;
            if (transactionSuccess == true)
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].name.Contains(userSelection))
                    {
                        
                        inventory.RemoveAt(i);
                        index = i;
                        break;
                        
                        
                    }
                    

                }
                

            }
            else
            {
                UserInterface.InsufficientInventory();
            }

            return inventory[index];


        }














    }
}
