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

        public bool ValidateSelection(string input) 
        {
            bool selectionSuccess = false;
            for (int i = 0; i < inventory.Count; i++)
            {
                if(input == inventory[i].name)
                {                   
                    userSelectionIndex = i;
                    userSelection = input;
                    selectionSuccess = true;   
                }
            }
            return selectionSuccess;
        }

        public bool ValidatePayment(List<Coin> payment)
        {
            bool paymentSuccess = false;
            if (inventory[userSelectionIndex].Cost == UserInterface.CalculateTotal(payment))
            {
                CompleteTransaction(payment, userSelection);
            }

            if (inventory[userSelectionIndex].Cost > UserInterface.CalculateTotal(payment))
            {
                UserInterface.InsufficientFunds(payment);
                //then need to give money back
                //re-prompt for money (SelectCoins?)
            }

            if (inventory[userSelectionIndex].Cost < UserInterface.CalculateTotal(payment))
            {
                MakeChange(payment);
                CompleteTransaction(payment, userSelection);

            }

            // if too much money is passed in but there isn't sufficient change in register, transactionSuccess == false
            //money goes back to customer

            //if there isn't sufficient inventory for the sodas, don't complete the transaction and give money back

            return paymentSuccess;

        }

        public List<Coin> MakeChange(List<Coin> payment)
        {
            double changeAmount = UserInterface.CalculateTotal(payment) - inventory[userSelectionIndex].Cost;

            foreach (Quarter quarter in register)
            {
                if (changeAmount > quarter.Value)
                {
                    customerChange.Add(quarter);
                    register.Remove(quarter);
                    changeAmount -= quarter.Value;

                    continue;
                }
                else
                {
                    break;
                }
            }

            foreach (Dime dime in register)
            {
                if (changeAmount > dime.Value)
                {
                    customerChange.Add(dime);
                    register.Remove(dime);
                    changeAmount -= dime.Value;

                    continue;
                }
                else
                {
                    break;
                }

            }

            foreach (Nickel nickel in register)
            {
                if (changeAmount > nickel.Value)
                {
                    customerChange.Add(nickel);
                    register.Remove(nickel);
                    changeAmount -= nickel.Value;

                    continue;
                }
                else
                {
                    break;
                }

            }

            foreach (Penny penny in register)
            {
                if (changeAmount > penny.Value)
                {
                    customerChange.Add(penny);
                    register.Remove(penny);
                    changeAmount -= penny.Value;

                    continue;
                }
                else
                {
                    break;
                }

            }

            return customerChange;
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
            return inventory[index];


        }














    }
}
