using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Simulation
    {
        public SodaMachine sodaMachine;
        public Customer customer;
        List<Coin> payment;
        string sodaSelection;
        bool transactionSuccess;
        bool paymentSuccess;
        bool selectionSuccess;
        

        public Simulation()
        {
            sodaMachine = new SodaMachine();
            customer = new Customer();
            payment = new List<Coin>();
            sodaSelection = "";
            transactionSuccess = false;
            paymentSuccess = false;
            selectionSuccess = false;
        }

        public void RunSimulation() 
        {
            UserInterface.DisplaySodaInventory(sodaMachine.inventory);
            UserInterface.DisplayCoins(customer.wallet.coins);
            payment = customer.SelectCoins(customer.wallet);
            sodaSelection = sodaMachine.SelectSoda();
            selectionSuccess = sodaMachine.ValidateSodaSelection(sodaSelection);
            paymentSuccess = sodaMachine.ValidateUserPayment(payment);

            
            transactionSuccess = UserInterface.ValidateTwoSelections(selectionSuccess, paymentSuccess);

            if (transactionSuccess == true)
            {
                customer.AddChangeToWallet(sodaMachine.customerChange);
                customer.AddSodaToBackpack(sodaMachine.DispenseSoda());
                UserInterface.DisplayBackPackContents(customer.backpack.cans);
                RunSimulation();

            }
            else
            {
                UserInterface.TransactionFailed();
                RunSimulation();

            }


        }
    }
}
