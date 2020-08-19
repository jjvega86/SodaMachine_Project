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
            customer.ChooseSoda(sodaMachine); //choose the soda first. 
            customer.SelectCoins(customer.wallet); //then, pick the money used to pay for the soda




        }
    }
}
