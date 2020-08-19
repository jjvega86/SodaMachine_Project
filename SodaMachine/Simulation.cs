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

        public Simulation()
        {
            sodaMachine = new SodaMachine();
            customer = new Customer();
        }

        public void RunSimulation() 
        {
            //Customer looks at soda options and cost
            //Customer checks wallet for enough change
            //Customer picks coins, puts in hand(payment)
            //Customer puts payment in soda machine and selects soda
            //Soda Machine compares payment to cost of soda
            //If payment is enough, Soda Machine dispenses soda
            //Payment goes into register, change comes back
            //Customer takes change and puts into wallet
            //Customer takes soda and puts into bookbag

            UserInterface.DisplaySodaInventory(sodaMachine.inventory);
            UserInterface.DisplayCoins(customer.wallet.coins);
            customer.SelectCoins(customer.wallet);




        }
    }
}
