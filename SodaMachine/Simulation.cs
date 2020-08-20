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
            sodaSelection = customer.SelectSoda();
            paymentSuccess = sodaMachine.ValidatePayment(payment);
            selectionSuccess = sodaMachine.ValidateSelection(sodaSelection);

            if(paymentSuccess = true && selectionSuccess == true)
            {
                transactionSuccess = true;
            }

            customer.AddSodaToBackpack(sodaMachine.DispenseSoda(transactionSuccess));
            UserInterface.DisplayBackPackContents(customer.backpack.cans);

        }
    }
}
