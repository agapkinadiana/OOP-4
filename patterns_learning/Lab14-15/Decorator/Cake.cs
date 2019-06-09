using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_15.Decorator
{
    abstract class Cake
    {
        public Cake(string n)
        {
            this.Name = n;
        }

        public string Name { get; protected set; }
        public abstract int GetCost();
    }
}
