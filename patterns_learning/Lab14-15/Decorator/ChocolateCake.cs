using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_15.Decorator
{
    class ChocolateCake : Cake
    {
        public ChocolateCake()
            : base("Шоколадный пирог")
        { }
        public override int GetCost()
        {
            return 10;
        }
    }
}
