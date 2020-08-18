using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public abstract class Can
    {
        protected double cost;
        public double Cost { get; } //same principles as Coin class. User can access cost of Can object but can't change its protected value. Children inherit.
        public string name;

        public Can()
        {
            cost = 0;
            name = "Can";

        }
    }
}
